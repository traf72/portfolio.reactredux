import './Person.scss';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import PersonalInfoBlock from './PersonalInfoBlock';
import EducationBlock from './EducationBlock';
import WorkBlock from './WorkBlock';
import LanguagesBlock from './LanguagesBlock';
import SocialNetworksBlock from './SocialNetworksBlock';
import FamilyStatusBlock from './FamilyStatusBlock';
import ForeignerBlock from './ForeignerBlock';
import FilesBlock from './FilesBlock';
import { connect } from 'react-redux';
import Button from '../common/Button';
import { fetchPerson, personFullSelector } from '../../ducks/Person';
import { allActions as pageLoaderActions } from '../../ducks/PageLoader';
import { push } from 'connected-react-router';
import { personEdit as personEditRoute } from '../../routes';

class Person extends Component {
    state = {
        loadComplete: false,
    }

    componentDidMount() {
        if (this.state.loadComplete) {
            return;
        }

        this.ensureDataLoaded();
    }

    componentDidUpdate(prevProps) {
        if (prevProps.id !== this.props.id) {
            this.setState({ loadComplete: false });
            this.ensureDataLoaded();
            return;
        }

        if (!this.state.loadComplete && !prevProps.loadComplete && this.props.loadComplete) {
            this.props.hidePageLoader();
            this.setState({ loadComplete: true });
        }
    }

    ensureDataLoaded() {
        this.props.showPageLoader();
        this.props.fetchPerson(this.props.id);
    }

    editPerson = () => {
        this.props.push(personEditRoute.buildUrl({ id: this.props.id }));
    }

    render() {
        if (!this.state.loadComplete) {
            return null;
        }

        const { person } = this.props;

        const familyInfo = {
            familyStatus: person.personalInfo.familyStatus,
            childrenInfo: person.personalInfo.childrenInfo,
        }

        const foreignerInfo = {
            nationality: person.personalInfo.nationality,
            readyMoveToRussia: person.personalInfo.readyMoveToRussia,
        }

        return (
            <div className="person-card">
                <div className="person-card-form">
                    <PersonalInfoBlock {...person.personalInfo} />
                    <EducationBlock {...person.educationInfo} />
                    <WorkBlock {...person.workInfo} />
                    <LanguagesBlock {...person.languagesInfo} />
                    <SocialNetworksBlock {...person.socialNetworksInfo} />
                    <FamilyStatusBlock {...familyInfo} />
                    <ForeignerBlock {...foreignerInfo} />
                    <FilesBlock {...person.filesInfo} />
                </div>
                <Button className="person-card-action-btn" color="primary" icon="edit" onClick={this.editPerson}>Изменить</Button>
            </div>
        );
    }
}

Person.propTypes = {
    id: PropTypes.number.isRequired,
    person: PropTypes.object.isRequired,
}

export default connect(state => {
    return personFullSelector(state);
}, { ...pageLoaderActions, fetchPerson, push }
)(Person);