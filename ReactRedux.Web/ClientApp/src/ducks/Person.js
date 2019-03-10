import { appName } from '../constants';
import { getPerson, createOrEditPerson } from '../api';
import { createSelector } from 'reselect';
import { takeEvery, takeLatest, takeLeading, put, call, select, all } from 'redux-saga/effects';
import { person as personRoute } from '../routes';
import { push } from 'connected-react-router';
import { showErrorAlert } from './Alert';
import {
    FEDERAL_DISTRICTS, REGIONS, IDENTITY_DOCUMENTS, EDUCATIONAL_LEVELS, INDUSTRIES, WORK_AREAS,
    MANAGEMENT_LEVELS, MANAGEMENT_EXPERIENCES, EMPLOYEES_NUMBERS, LANGUAGES, LANGUAGE_LEVELS, SOCIAL_NETWORKS,
    COUNTRIES, SEX, FAMILY_STATUS, fetchCatalog,
} from './Catalog';
import { now } from '../utils';
import uuid from 'uuid/v1';
import RequestError from '../RequestError';

const moduleName = 'person';
export const NEW_PERSON = `${appName}/${moduleName}/NEW_PERSON`;
export const FETCH_REQUEST = `${appName}/${moduleName}/FETCH_REQUEST`;
export const FETCH_START = `${appName}/${moduleName}/FETCH_START`;
export const FETCH_SUCCESS = `${appName}/${moduleName}/FETCH_SUCCESS`;
export const FETCH_FAILED = `${appName}/${moduleName}/FETCH_FAILED`;
export const SAVE_REQUEST = `${appName}/${moduleName}/SAVE_REQUEST`;
export const SAVE_START = `${appName}/${moduleName}/SAVE_START`;
export const SAVE_SUCCESS = `${appName}/${moduleName}/SAVE_SUCCESS`;
export const SAVE_FAILED = `${appName}/${moduleName}/SAVE_FAILED`;

const defaultDocumentCode = '21'; // Паспорт
const defaultSocialNetworks = ['facebook', 'vk', 'ok', 'twitter'];

export const personalInfoBlockCatalogs = [FEDERAL_DISTRICTS, REGIONS, IDENTITY_DOCUMENTS, SEX];
export const educationBlockCatalogs = [EDUCATIONAL_LEVELS];
export const workInfoBlockCatalogs = [INDUSTRIES, WORK_AREAS, MANAGEMENT_LEVELS, MANAGEMENT_EXPERIENCES, EMPLOYEES_NUMBERS];
export const languagesBlockCatalogs = [LANGUAGES, LANGUAGE_LEVELS];
export const socialNetworksBlockCatalogs = [SOCIAL_NETWORKS, FAMILY_STATUS];
export const foreignerBlockCatalogs = [COUNTRIES];

export const allPersonCatalogs = [...personalInfoBlockCatalogs, ...educationBlockCatalogs, ...workInfoBlockCatalogs,
...languagesBlockCatalogs, ...socialNetworksBlockCatalogs, ...foreignerBlockCatalogs
];

const initialState = {
    loading: false,
    loadComplete: false,
    loadTime: new Date(0),
    saving: false,
    id: null,
    data: [],
    error: '',
};

export default function reducer(state = initialState, action) {
    const { type, payload, error } = action;
    switch (type) {
        case FETCH_START:
            return {
                ...initialState,
                loading: true,
                id: payload.id,
            };

        case FETCH_SUCCESS:
        case SAVE_SUCCESS:
            return {
                ...initialState,
                loadComplete: true,
                loadTime: payload.loadTime,
                id: payload.data.id,
                data: payload.data,
            };

        case FETCH_FAILED:
            return {
                ...initialState,
                loadComplete: true,
                loadTime: payload.loadTime,
                id: payload.id,
                error: error.message,
            };

        case SAVE_START:
            return {
                ...state,
                saving: true,
                id: payload.id,
            };

        case SAVE_FAILED:
            return {
                ...state,
                saving: false,
                loadTime: payload.loadTime,
                id: payload.id,
                error: error.message,
            };

        default:
            return state;
    }
};

export const newPerson = () => {
    return {
        type: NEW_PERSON,
    }
}

export const fetchPerson = id => {
    return {
        type: FETCH_REQUEST,
        payload: { id },
    }
}

export const fetchStart = id => {
    return {
        type: FETCH_START,
        payload: { id },
    }
}

export const fetchSuccess = (data, loadTime) => {
    return {
        type: FETCH_SUCCESS,
        payload: { data, loadTime },
    }
}

export const fetchFailed = (id, error, loadTime) => {
    return {
        type: FETCH_FAILED,
        payload: { id, loadTime },
        error,
    }
}

export const savePerson = person => {
    return {
        type: SAVE_REQUEST,
        payload: { person },
    }
}

export const saveStart = id => {
    return {
        type: SAVE_START,
        payload: { id },
    }
}

export const saveSuccess = (data, loadTime) => {
    return {
        type: SAVE_SUCCESS,
        payload: { data, loadTime },
    }
}

export const saveFailed = (id, error, loadTime) => {
    return {
        type: SAVE_FAILED,
        payload: { id, loadTime },
        error,
    }
}

export const allActions = {
    newPerson, fetchPerson, fetchStart, fetchSuccess, fetchFailed, savePerson, saveStart, saveSuccess, saveFailed
};

export const fetchPersonCatalogsSaga = function* () {
    yield all(allPersonCatalogs.map(c => put(fetchCatalog(c))));
}

export const fetchPersonSaga = function* (action) {
    yield call(fetchPersonCatalogsSaga);

    const { id } = action.payload;

    yield put(fetchStart(id));

    try {
        const response = yield call(getPerson, id);
        const personData = response.data;
        yield put(fetchSuccess(personData, now()));
    } catch (error) {
        const reqError = new RequestError(error, 'При загрузке сотрудника произошла ошибка');
        yield all([
            put(fetchFailed(id, reqError, now())),
            put(showErrorAlert(reqError.message))
        ]);
    }
}

export const savePersonSaga = function* (action) {
    const { person } = action.payload;
    const id = person.id;
    const state = yield select();
    const currentLocation = state.router.location;

    yield put(saveStart(id));

    const isLocationChanged = state => currentLocation !== state.router.location;
    const isPersonChanged = state => state.person.id !== id;
    try {
        const response = yield call(createOrEditPerson, person);
        const savedPerson = response.data;
        const state = yield select();

        if (!isPersonChanged(state)) {
            yield put(saveSuccess(savedPerson, now()));
        }

        if (!isLocationChanged(state)) {
            yield put(push(personRoute.buildUrl({ id: savedPerson.id })));
        }
    } catch (error) {
        const reqError = new RequestError(error, 'При сохранении сотрудника произошла ошибка');
        if (!isPersonChanged(yield select())) {
            yield put(saveFailed(id, reqError, now()));
        }
        yield put(showErrorAlert(reqError.message));
    }
}

export const saga = function* () {
    yield all([
        takeLatest(FETCH_REQUEST, fetchPersonSaga),
        takeLeading(NEW_PERSON, fetchPersonCatalogsSaga),
        takeEvery(SAVE_REQUEST, savePersonSaga)
    ]);
}

const isCatalogsLoaded = allCatalogs =>
    allPersonCatalogs.every(c => allCatalogs[c].loadComplete);

const catalogsSelector = state => state.catalogs;
const personSelector = state => state.person;

export const personCatalogsSelector = createSelector(
    catalogsSelector,
    catalogs =>
        allPersonCatalogs.reduce((acc, name) => {
            acc[name] = catalogs[name];
            return acc;
        }, {})
);

export const isNewPersonReadySelector = createSelector(
    catalogsSelector,
    catalogs => isCatalogsLoaded(catalogs)
);

export const isPersonReadySelector = createSelector(
    catalogsSelector,
    personSelector,
    (catalogs, person) => person.loadComplete && isCatalogsLoaded(catalogs)
);

export const personNewSelector = createSelector(
    catalogsSelector,
    catalogs => ({
        personalInfo: {
            document: catalogs[IDENTITY_DOCUMENTS].data.find(x => x.code === defaultDocumentCode),
        },
        educationInfo: {},
        workInfo: {},
        languagesInfo: {
            knownLanguages: [
                {
                    language: null,
                    languageLevel: null
                },
                {
                    language: null,
                    languageLevel: null
                }
            ]
        },
        socialNetworksInfo: {
            networks: defaultSocialNetworks.map(code => ({
                network: catalogs[SOCIAL_NETWORKS].data.find(x => x.code === code),
                value: ''
            })).filter(x => x.network),
        },
        filesInfo: {
            files: [],
        },
        filesDirectoryId: uuid(),
    })
);

export const personFullSelector = createSelector(
    catalogsSelector,
    personSelector,
    (catalogs, person) => {
        let {
            educationInfo = {}, workInfo = {}, languages = [],
            socialNetworks = [], files = [], filesDirectoryId, ...personalInfo
        } = person.data;

        // Так как с сервера приходит null, то дефолтные значения не срабатывают
        files = files || [];
        socialNetworks = socialNetworks || [];
        languages = languages || [];

        const getCatalogItem = (catalogName, itemId) => {
            return itemId && catalogs[catalogName].indexedData[itemId];
        }

        return {
            personalInfo: {
                ...personalInfo,
                sex: getCatalogItem(SEX, personalInfo.sex),
                birthDate: personalInfo.birthDate ? new Date(personalInfo.birthDate) : null,
                federalDistrict: getCatalogItem(FEDERAL_DISTRICTS, personalInfo.federalDistrictId),
                region: getCatalogItem(REGIONS, personalInfo.regionId),
                document: getCatalogItem(IDENTITY_DOCUMENTS, personalInfo.documentId),
                familyStatus: getCatalogItem(FAMILY_STATUS, personalInfo.familyStatus),
                childrenInfo: personalInfo.childrenInfo,
                nationality: getCatalogItem(COUNTRIES, personalInfo.nationalityId),
            },
            educationInfo: {
                ...educationInfo,
                educationLevel: getCatalogItem(EDUCATIONAL_LEVELS, educationInfo.educationLevelId),
            },
            workInfo: {
                ...workInfo,
                industry: getCatalogItem(INDUSTRIES, workInfo.industryId),
                workArea: getCatalogItem(WORK_AREAS, workInfo.workAreaId),
                managementLevel: getCatalogItem(MANAGEMENT_LEVELS, workInfo.managementLevelId),
                managementExperience: getCatalogItem(MANAGEMENT_EXPERIENCES, workInfo.managementExperienceId),
                employeesNumber: getCatalogItem(EMPLOYEES_NUMBERS, workInfo.employeesNumberId),
            },
            languagesInfo: {
                knownLanguages:
                    languages.map(item => ({
                        language: getCatalogItem(LANGUAGES, item.languageId),
                        languageLevel: getCatalogItem(LANGUAGE_LEVELS, item.languageLevelId),
                    }))
            },
            socialNetworksInfo: {
                networks: socialNetworks.map(item => ({
                    network: getCatalogItem(SOCIAL_NETWORKS, item.networkId),
                    value: item.value,
                }))
            },
            filesInfo: {
                files,
            },
            filesDirectoryId,
        }
    }
);
