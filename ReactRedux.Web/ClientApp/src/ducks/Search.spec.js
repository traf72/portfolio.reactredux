import reducer, {
    SEARCH, FETCH_START, FETCH_SUCCESS, FETCH_FAILED, allActions as actions,
    searchSaga,
} from './Search';
import { showErrorAlert } from './Alert';
import { put, call, all } from 'redux-saga/effects';
import { searchForPersons } from '../api';
import deepFreeze from 'deep-freeze';
import RequestError from '../RequestError';

const error = new RequestError(new Error('Bad request'), 'Request error');
const testData = [
    { id: 754, firstName: 'Ivan', lastName: 'Ivanov' },
    { id: 234, firstName: 'Petr', lastName: 'Petrov' },
];

describe('reducer', () => {
    let initialState;

    beforeEach(() => {
        initialState = {
            loading: false,
            loadComplete: false,
            data: [],
            error: '',
        };
    });

    it('should reduce fetchStart action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchStart();

        expect(reducer(state, actions.fetchStart())).toEqual({
            ...initialState,
            loading: true,
        });
    });

    it('should reduce fetchSuccess action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchSuccess(testData);

        expect(reducer(state, action)).toEqual({
            ...initialState,
            loadComplete: true,
            data: action.payload.data,
        });
    });

    it('should reduce fetchFailed action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchFailed(error);

        expect(reducer(state, action)).toEqual({
            ...initialState,
            loadComplete: true,
            error: action.error.message,
        });
    });

    it('should reduce unknown action', () => {
        const state = deepFreeze({ ...initialState, data: testData });
        const action = { type: 'UNKNOWN', payload: 'UNKNOWN' };

        expect(reducer(state, action)).toBe(state);
    });
});

describe('actions', () => {
    it('should create search action', () => {
        const criteria = { name: 'Ivan' };

        expect(actions.search(criteria)).toEqual({
            type: SEARCH,
            payload: { criteria },
        });
    });

    it('should create fetchStart action', () => {
        expect(actions.fetchStart()).toEqual({
            type: FETCH_START,
        });
    });

    it('should create fetchSuccess action', () => {
        expect(actions.fetchSuccess(testData)).toEqual({
            type: FETCH_SUCCESS,
            payload: { data: testData },
        });
    });

    it('should create fetchFailed action', () => {
        expect(actions.fetchFailed(error)).toEqual({
            type: FETCH_FAILED,
            error,
        });
    });
});

describe('sagas', () => {
    describe('searchSaga', () => {
        const criteria = { id: 2 };
        const action = actions.search(criteria);

        it(`should send success if no error occured`, () => {
            const gen = searchSaga(action);

            expect(gen.next()).toEqual({ done: false, value: put(actions.fetchStart()) });
            expect(gen.next()).toEqual({ done: false, value: call(searchForPersons, criteria) });

            const fakeResponse = { data: { Name: 'test' } }

            expect(gen.next(fakeResponse)).toEqual({ done: false, value: put(actions.fetchSuccess(fakeResponse.data)) });
            expect(gen.next()).toEqual({ done: true });
        });

        it(`should send failed if error occured`, () => {
            const gen = searchSaga(action);

            expect(gen.next()).toEqual({ done: false, value: put(actions.fetchStart()) });
            expect(gen.next()).toEqual({ done: false, value: call(searchForPersons, criteria) });

            const reqErr = new RequestError(error, `При поиске произошла ошибка`);

            expect(gen.throw(error)).toEqual({
                done: false,
                value: all([
                    put(actions.fetchFailed(reqErr)),
                    put(showErrorAlert(reqErr.message))
                ])
            });

            expect(gen.next()).toEqual({ done: true });
        });
    });
});