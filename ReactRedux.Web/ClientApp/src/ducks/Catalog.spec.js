import reducer, {
    FETCH_REQUEST, FETCH_START, FETCH_SUCCESS, FETCH_FAILED, FEDERAL_DISTRICTS,
    IDENTITY_DOCUMENTS, allActions as actions, fetchCatalogSaga
} from './Catalog';
import { showErrorAlert } from './Alert';
import { put, call, select, all } from 'redux-saga/effects';
import { getCatalog } from '../api';
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

describe('sagas', () => {
    describe('fetchCatalogSaga', () => {
        const action = actions.fetchCatalog(FEDERAL_DISTRICTS, params);

        it(`should return if catalog is loading`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { loading: true, params }
                }
            }

            expect(gen.next(state)).toEqual({ done: true });
        });

        it(`should return if catalog is loaded without error`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { loadComplete: true, params }
                }
            }

            expect(gen.next(state)).toEqual({ done: true });
        });

        it(`should continue if catalog is loaded with error`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { loadComplete: true, params, error: 'error' }
                }
            }

            expect(gen.next(state).done).toBe(false);
        });

        it(`should continue if params are different`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { params: { id: 6 } }
                }
            }

            expect(gen.next(state).done).toBe(false);
        });

        it(`should send success if request is actual`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { params }
                }
            }

            expect(gen.next(state)).toEqual({ done: false, value: put(actions.fetchStart(FEDERAL_DISTRICTS, params)) });
            expect(gen.next()).toEqual({ done: false, value: call(getCatalog, FEDERAL_DISTRICTS, params) });

            const fakeResponse = { data: { Name: 'test' } };

            expect(gen.next(fakeResponse)).toEqual({ done: false, value: select() });
            expect(gen.next(state)).toEqual({ done: false, value: put(actions.fetchSuccess(FEDERAL_DISTRICTS, fakeResponse.data, params)) });
            expect(gen.next()).toEqual({ done: true });
        });

        it(`should return if request is not actual`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { params }
                }
            }

            expect(gen.next(state)).toEqual({ done: false, value: put(actions.fetchStart(FEDERAL_DISTRICTS, params)) });
            expect(gen.next()).toEqual({ done: false, value: call(getCatalog, FEDERAL_DISTRICTS, params) });

            const fakeResponse = { data: { Name: 'test' } };

            expect(gen.next(fakeResponse)).toEqual({ done: false, value: select() });

            const newState = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { id: 2 }
                }
            };

            expect(gen.next(newState)).toEqual({ done: true });
        });

        it(`should send failed on error if request is actual`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { params }
                }
            }

            expect(gen.next(state)).toEqual({ done: false, value: put(actions.fetchStart(FEDERAL_DISTRICTS, params)) });
            expect(gen.next()).toEqual({ done: false, value: call(getCatalog, FEDERAL_DISTRICTS, params) });

            expect(gen.throw(error)).toEqual({ done: false, value: select() });

            const reqErr = new RequestError(error, `При загрузке справочника "${FEDERAL_DISTRICTS}" произошла ошибка`);
            expect(gen.next(state)).toEqual({
                done: false,
                value: all([
                    put(actions.fetchFailed(FEDERAL_DISTRICTS, reqErr, params)),
                    put(showErrorAlert(reqErr.message))
                ])
            });

            expect(gen.next()).toEqual({ done: true });
        });

        it(`should return on error if request is not actual`, () => {
            const gen = fetchCatalogSaga(action);

            expect(gen.next()).toEqual({ done: false, value: select() });

            const state = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { params }
                }
            }

            expect(gen.next(state)).toEqual({ done: false, value: put(actions.fetchStart(FEDERAL_DISTRICTS, params)) });
            expect(gen.next()).toEqual({ done: false, value: call(getCatalog, FEDERAL_DISTRICTS, params) });

            expect(gen.throw(error)).toEqual({ done: false, value: select() });

            const newState = {
                catalogs: {
                    [FEDERAL_DISTRICTS]: { id: 2 }
                }
            };

            expect(gen.next(newState)).toEqual({ done: true });
        });
    });
});