import { combineReducers } from 'redux';
import history from './history';
import { connectRouter } from 'connected-react-router';
import catalogReducer from './ducks/Catalog';
import personReducer from './ducks/Person';
import searchReducer from './ducks/Search';
import alertReducer from './ducks/Alert';
import pageLoaderReducer from './ducks/PageLoader';

export default combineReducers({
    router: connectRouter(history),
    catalogs: catalogReducer,
    person: personReducer,
    search: searchReducer,
    alert: alertReducer,
    pageLoader: pageLoaderReducer,
});
