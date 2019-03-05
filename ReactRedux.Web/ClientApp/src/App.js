import React from 'react';
import { Route, Switch } from 'react-router';
import Layout from './components/Layout';
import PersonRoutes from './components/Person/PersonRoutes';
import Search from './components/Search';
import Home from './components/Home';
import { search, home } from './routes';

export default () => (
    <Layout>
        <Switch>
            <Route path={home.url} component={Home} exact />
            <Route path="/person" component={PersonRoutes} />
            <Route path={search.url} component={Search} />
        </Switch>
    </Layout>
);