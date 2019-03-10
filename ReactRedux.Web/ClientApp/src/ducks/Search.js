import { appName } from '../constants';
import { searchForPersons } from '../api';
import { createSelector } from 'reselect';
import { takeLatest, put, call, all } from 'redux-saga/effects';
import { showErrorAlert } from './Alert';
import RequestError from '../RequestError';
import { getFullBirthDate } from '../utils';
import { sex as sexEnum } from '../enums';
import {
    FEDERAL_DISTRICTS, REGIONS, IDENTITY_DOCUMENTS, EDUCATIONAL_LEVELS, INDUSTRIES, WORK_AREAS,
    MANAGEMENT_LEVELS, MANAGEMENT_EXPERIENCES, EMPLOYEES_NUMBERS, SEX,
} from './Catalog';

const moduleName = 'search';
export const SEARCH = `${appName}/${moduleName}/SEARCH`;
export const FETCH_START = `${appName}/${moduleName}/FETCH_START`;
export const FETCH_SUCCESS = `${appName}/${moduleName}/FETCH_SUCCESS`;
export const FETCH_FAILED = `${appName}/${moduleName}/FETCH_FAILED`;

export const personalInfoBlockCatalogs = [FEDERAL_DISTRICTS, REGIONS, IDENTITY_DOCUMENTS, SEX];
export const educationBlockCatalogs = [EDUCATIONAL_LEVELS];
export const workInfoBlockCatalogs = [INDUSTRIES, WORK_AREAS, MANAGEMENT_LEVELS, MANAGEMENT_EXPERIENCES, EMPLOYEES_NUMBERS];

export const allSearchCatalogs = [...personalInfoBlockCatalogs, ...educationBlockCatalogs, ...workInfoBlockCatalogs];

const initialState = {
    loading: false,
    loadComplete: false,
    data: [],
    error: '',
};

export default function reducer(state = initialState, action) {
    const { type, payload, error } = action;
    switch (type) {
        case FETCH_START:
            return {
                ...state,
                loading: true,
                loadComplete: false,
                error: '',
            };

        case FETCH_SUCCESS:
            return {
                ...initialState,
                loadComplete: true,
                data: payload.data,
            };

        case FETCH_FAILED:
            return {
                ...initialState,
                loadComplete: true,
                error: error.message,
            };

        default:
            return state;
    }
};

export const search = criteria => {
    return {
        type: SEARCH,
        payload: { criteria },
    }
}

export const fetchStart = () => {
    return {
        type: FETCH_START,
    }
}

export const fetchSuccess = data => {
    return {
        type: FETCH_SUCCESS,
        payload: { data },
    }
}

export const fetchFailed = error => {
    return {
        type: FETCH_FAILED,
        error,
    }
}

export const allActions = {
    search, fetchStart, fetchSuccess, fetchFailed
};

export const searchSaga = function* (action) {
    yield put(fetchStart());

    const { criteria } = action.payload;
    try {
        const response = yield call(searchForPersons, criteria);
        const result = response.data;
        yield put(fetchSuccess(result));
    } catch (error) {
        const reqError = new RequestError(error, 'При поиске произошла ошибка');
        yield all([
            put(fetchFailed(reqError)),
            put(showErrorAlert(reqError.message))
        ]);
    }
}

export const saga = function* () {
    yield takeLatest(SEARCH, searchSaga);
}

const getSearch = state => state.search;
const getCatalogs = state => state.catalogs;

export const searchSelector = createSelector(
    getSearch,
    search => {
        return {
            loadComplete: search.loadComplete,
            data: search.data.map(x => ({
                id: x.id,
                fio: `${x.lastName} ${x.firstName} ${x.middleName}`,
                sex: sexEnum[x.sex],
                birthDate: x.birthDate && getFullBirthDate(new Date(x.birthDate)),
                residence: x.region,
                phone: x.phone,
                email: x.email,
                educationLevel: x.educationLevel,
                university: x.university,
                currentCompany: x.currentCompany,
                currentPosition: x.currentPosition,
                industry: x.industry,
                managementLevel: x.managementLevel,
                managementExperience: x.managementExperience,
                photoId: x.photoId,
            })),
        }
    }
);

export const catalogsSelector = createSelector(
    getCatalogs,
    catalogs => {
        return allSearchCatalogs.reduce((obj, name) => {
            obj[name] = catalogs[name];
            return obj;
        }, {});
    }
);
