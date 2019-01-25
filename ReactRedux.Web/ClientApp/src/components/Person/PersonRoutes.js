import { Route, Switch } from 'react-router';
import React, { Component } from 'react';
import EditPerson from './Edit';
import Person from './Person';
import { personNew, personEdit, person } from '../../routes';

class PersonRoutes extends Component {
    renderEditPerson = ({ match }) => {
        const { params } = match;
        return <EditPerson id={+params.id} />;
    }

    renderPerson = ({ match }) => {
        const { params } = match;
        return <Person id={+params.id} />;
    }

    render() {
        return (
            <Switch>
                <Route path={personNew.url} component={EditPerson} />
                <Route path={personEdit.url} component={this.renderEditPerson} />
                <Route path={person.url} component={this.renderPerson} />
            </Switch>
        );
    }
}

export default PersonRoutes;