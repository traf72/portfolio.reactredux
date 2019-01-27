import reducer, {
    NEW_PERSON, FETCH_REQUEST, FETCH_START, FETCH_SUCCESS, FETCH_FAILED, SAVE_REQUEST,
    SAVE_START, SAVE_SUCCESS, SAVE_FAILED, allActions as actions, fetchPersonCatalogsSaga,
    fetchPersonSaga, allPersonCatalogs
} from './Person';
import { fetchCatalog } from './Catalog';
import { showErrorAlert } from './Alert';
import { put, call, all } from 'redux-saga/effects';
import { getPerson } from '../api';
import { now } from '../utils';
import deepFreeze from 'deep-freeze';
import RequestError from '../RequestError';

jest.mock('../utils');

const error = new RequestError(new Error('Bad request'), 'Request error');
const loadTime = new Date();
const testData = { id: 754, firstName: 'Ivan', lastName: 'Ivanov' };

describe('reducer', () => {
    let initialState;

    beforeEach(() => {
        initialState = {
            loading: false,
            loadComplete: false,
            loadTime: new Date(0),
            saving: false,
            id: null,
            data: [],
            error: '',
        };
    });

    it('should reduce fetchStart action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchStart(10);

        expect(reducer(state, action)).toEqual({
            ...initialState,
            loading: true,
            id: action.payload.id,
        });
    });

    it('should reduce fetchSuccess action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchSuccess(testData, loadTime);

        expect(reducer(state, action)).toEqual({
            ...initialState,
            loadComplete: true,
            loadTime,
            id: action.payload.data.id,
            data: action.payload.data,
        });
    });

    it('should reduce fetchFailed action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchFailed(10, error, loadTime);

        expect(reducer(state, action)).toEqual({
            ...initialState,
            loadComplete: true,
            loadTime,
            id: action.payload.id,
            error: action.error.message,
        });
    });

    it('should reduce saveStart action', () => {
        const state = deepFreeze({ ...initialState, id: 856, data: testData });
        const action = actions.saveStart(10);

        expect(reducer(state, action)).toEqual({
            ...state,
            saving: true,
            id: action.payload.id,
        });
    });

    it('should reduce saveSuccess action', () => {
        const state = deepFreeze({ ...initialState, data: { id: 875, name: 'test' }, saving: true });
        const action = actions.saveSuccess(testData, loadTime);

        expect(reducer(state, action)).toEqual({
            ...initialState,
            loadComplete: true,
            loadTime,
            id: action.payload.data.id,
            data: action.payload.data,
        });
    });

    it('should reduce saveFailed action', () => {
        const state = deepFreeze({ ...initialState, data: testData, saving: true });
        const action = actions.saveFailed(10, error, loadTime);

        expect(reducer(state, action)).toEqual({
            ...state,
            saving: false,
            loadTime,
            id: action.payload.id,
            error: action.error.message,
        });
    });

    it('should reduce unknown action', () => {
        const state = deepFreeze(initialState);
        const action = { type: 'UNKNOWN', payload: 'UNKNOWN' };

        expect(reducer(state, action)).toBe(state);
    });
});

describe('actions', () => {
    it('should create newPerson action', () => {
        expect(actions.newPerson()).toEqual({
            type: NEW_PERSON,
        });
    });

    it('should create fetchRequest action', () => {
        expect(actions.fetchPerson(10)).toEqual({
            type: FETCH_REQUEST,
            payload: { id: 10 },
        });
    });

    it('should create fetchStart action', () => {
        expect(actions.fetchStart(10)).toEqual({
            type: FETCH_START,
            payload: { id: 10 },
        });
    });

    it('should create fetchSuccess action', () => {
        expect(actions.fetchSuccess(testData, loadTime)).toEqual({
            type: FETCH_SUCCESS,
            payload: { data: testData, loadTime },
        });
    });

    it('should create fetchFailed action', () => {
        expect(actions.fetchFailed(10, error, loadTime)).toEqual({
            type: FETCH_FAILED,
            payload: { id: 10, loadTime },
            error,
        });
    });

    it('should create saveRequest action', () => {
        expect(actions.savePerson(testData)).toEqual({
            type: SAVE_REQUEST,
            payload: { person: testData },
        });
    });

    it('should create saveStart action', () => {
        expect(actions.saveStart(10)).toEqual({
            type: SAVE_START,
            payload: { id: 10 },
        });
    });

    it('should create saveSuccess action', () => {
        expect(actions.saveSuccess(testData, loadTime)).toEqual({
            type: SAVE_SUCCESS,
            payload: { data: testData, loadTime },
        });
    });

    it('should create saveFailed action', () => {
        expect(actions.saveFailed(10, error, loadTime)).toEqual({
            type: SAVE_FAILED,
            payload: { id: 10, loadTime },
            error,
        });
    });
});

describe('sagas', () => {
    describe('fetchPersonCatalogsSaga', () => {
        it('should fetch all person catalogs', () => {
            const gen = fetchPersonCatalogsSaga();

            expect(gen.next()).toEqual({
                done: false,
                value: all(allPersonCatalogs.map(c => put(fetchCatalog(c))))
            });

            expect(gen.next()).toEqual({ done: true });
        });
    });

    describe('fetchPersonSaga', () => {
        now.mockResolvedValue(new Date());
        const personId = 1;
        const action = actions.fetchPerson(personId);

        it(`should send success if no error occured`, () => {
            const gen = fetchPersonSaga(action);

            expect(gen.next()).toEqual({ done: false, value: call(fetchPersonCatalogsSaga) });
            expect(gen.next()).toEqual({ done: false, value: put(actions.fetchStart(personId)) });
            expect(gen.next()).toEqual({ done: false, value: call(getPerson, personId) });

            const fakeResponse = { data: { Name: 'test' } }

            expect(gen.next(fakeResponse)).toEqual({ done: false, value: put(actions.fetchSuccess(fakeResponse.data, now())) });
            expect(gen.next()).toEqual({ done: true });
        });

        it(`should send failed if error occured`, () => {
            const gen = fetchPersonSaga(action);

            expect(gen.next()).toEqual({ done: false, value: call(fetchPersonCatalogsSaga) });
            expect(gen.next()).toEqual({ done: false, value: put(actions.fetchStart(personId)) });
            expect(gen.next()).toEqual({ done: false, value: call(getPerson, personId) });

            const reqErr = new RequestError(error, `При загрузке сотрудника произошла ошибка`);

            expect(gen.throw(error)).toEqual({
                done: false,
                value: all([
                    put(actions.fetchFailed(personId, reqErr, now())),
                    put(showErrorAlert(reqErr.message))
                ])
            });

            expect(gen.next()).toEqual({ done: true });
        });
    });
});