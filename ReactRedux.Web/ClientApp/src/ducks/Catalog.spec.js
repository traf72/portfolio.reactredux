import reducer, { FETCH_REQUEST, FETCH_START, FETCH_SUCCESS, FETCH_FAILED, FEDERAL_DISTRICTS, IDENTITY_DOCUMENTS, allActions as actions } from './Catalog';
import { indexArray } from '../utils';
import deepFreeze from 'deep-freeze';
import RequestError from '../RequestError';

const error = new RequestError(new Error('Bad request'), 'Request error');
const params = { id: 2 };

describe('reducer', () => {
    let initialCatalogState;
    let initialState;

    beforeEach(() => {
        initialCatalogState = {
            loading: false,
            loadComplete: false,
            data: [],
            indexedData: {},
            error: '',
        };

        initialState = {
            [FEDERAL_DISTRICTS]: initialCatalogState,
            [IDENTITY_DOCUMENTS]: initialCatalogState,
        }
    });

    it('should reduce fetchStart action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchStart(FEDERAL_DISTRICTS, params);

        expect(reducer(state, action)).toEqual({
            [FEDERAL_DISTRICTS]: { ...initialCatalogState, loading: true, params },
            [IDENTITY_DOCUMENTS]: initialCatalogState,
        });
    });

    it('should reduce fetchSuccess action', () => {
        const state = deepFreeze(initialState);
        const data = [{ one: '1' }, { two: '2' }];
        const action = actions.fetchSuccess(FEDERAL_DISTRICTS, data, params);

        expect(reducer(state, action)).toEqual({
            [FEDERAL_DISTRICTS]: {
                ...initialCatalogState,
                loadComplete: true,
                data: action.payload.data,
                indexedData: indexArray(action.payload.data),
                params,
            },
            [IDENTITY_DOCUMENTS]: initialCatalogState,
        });
    });

    it('should reduce fetchFailed action', () => {
        const state = deepFreeze(initialState);
        const action = actions.fetchFailed(FEDERAL_DISTRICTS, error, params);

        expect(reducer(state, action)).toEqual({
            [FEDERAL_DISTRICTS]: { ...initialCatalogState, loadComplete: true, error: action.error.message, params },
            [IDENTITY_DOCUMENTS]: initialCatalogState,
        });
    });

    it('should reduce unknown action', () => {
        const state = deepFreeze(initialState);
        const action = { type: 'UNKNOWN', payload: 'UNKNOWN' };

        expect(reducer(state, action)).toBe(state);
    });
});

describe('actions', () => {
    it('should create fetchRequest action', () => {
        expect(actions.fetchCatalog(FEDERAL_DISTRICTS, params)).toEqual({
            type: FETCH_REQUEST,
            payload: { catalogName: FEDERAL_DISTRICTS, params },
        });
    });

    it('should create fetchStart action', () => {
        expect(actions.fetchStart(FEDERAL_DISTRICTS, params)).toEqual({
            type: FETCH_START,
            payload: { catalogName: FEDERAL_DISTRICTS, params },
        });
    });

    it('should create fetchSuccess action', () => {
        const data = [{ one: '1' }, { two: '2' }];

        expect(actions.fetchSuccess(FEDERAL_DISTRICTS, data, params)).toEqual({
            type: FETCH_SUCCESS,
            payload: { catalogName: FEDERAL_DISTRICTS, data, params },
        });
    });

    it('should create fetchFailed action', () => {
        expect(actions.fetchFailed(FEDERAL_DISTRICTS, error, params)).toEqual({
            type: FETCH_FAILED,
            payload: { catalogName: FEDERAL_DISTRICTS, params },
            error,
        });
    });
});