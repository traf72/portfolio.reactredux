import React from 'react';
import { Route, Switch } from 'react-router';
import Layout from './components/Layout';
import PersonRoutes from './components/Person/PersonRoutes';
import Search from './components/Search';
import Dashboard from './components/Dashboard';
import { search, dashboard } from './routes';

export default () => (
    <Layout>
        <Switch>
            <Route path={dashboard.url} component={Dashboard} exact />
            <Route path="/person" component={PersonRoutes} />
            <Route path={search.url} component={Search} />
        </Switch>
    </Layout>
);