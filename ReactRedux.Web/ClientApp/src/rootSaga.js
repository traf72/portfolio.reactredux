import { all } from 'redux-saga/effects';
import { saga as catalogSaga } from './ducks/Catalog';
import { saga as personSaga } from './ducks/Person';
import { saga as searchSaga } from './ducks/Search';
import { saga as alertSaga } from './ducks/Alert';

export default function* () {
    yield all([
        catalogSaga(),
        personSaga(),
        searchSaga(),
        alertSaga(),
    ]);
};
