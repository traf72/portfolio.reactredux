import React from 'react';
import { Route, Switch } from 'react-router';
import Layout from './components/Layout';
import PersonRoutes from './components/Person/PersonRoutes';
import Search from './components/Search';
import Dashboard from './components/Dashboard';
import Chart from './components/Chart';
import { search, dashboard, charts } from './routes';

export default () => (
    <Layout>
        <Switch>
            <Route path={dashboard.url} component={Dashboard} exact />
            <Route path="/person" component={PersonRoutes} />
            <Route path={search.url} component={Search} />
            <Route path={charts.url} component={Chart} />
        </Switch>
    </Layout>
);