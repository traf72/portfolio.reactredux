import './EditPerson.scss';
import React, { Component } from 'react';
import PropTypes from 'prop-types';
import { Form } from 'reactstrap';
import { List } from 'immutable';
import { connect } from 'react-redux';
import Button from '../../common/Button/'
import PersonalInfoBlock from './PersonalInfoBlock';
import EducationBlock from './EducationBlock';
import WorkBlock from './WorkBlock';
import LanguagesBlock from './LanguagesBlock';
import SocialNetworksBlock from './SocialNetworksBlock';
import FamilyStatusBlock from './FamilyStatusBlock';
import ForeignerBlock from './ForeignerBlock';
import FilesBlock from './FilesBlock';
import { fetchCatalog } from '../../../ducks/Catalog';
import {
    fetchPerson, savePerson, newPerson, personNewSelector, personFullSelector, personCatalogsSelector,
    isNewPersonReadySelector, isPersonReadySelector, personalInfoBlockCatalogs, educationBlockCatalogs,
    workInfoBlockCatalogs, languagesBlockCatalogs,
    socialNetworksBlockCatalogs, foreignerBlockCatalogs
} from '../../../ducks/Person';
import { showWarningAlert } from '../../../ducks/Alert';
import { allActions as pageLoaderActions } from '../../../ducks/PageLoader';

class EditPerson extends Component {
    constructor(props) {
        super(props);

        const loadComplete = this.isNewPerson() ? this.props.loadComplete : false;
        this.state = {
            person: loadComplete ? this.getInitialPersonState() : {},
            loadComplete,
            isFormSubmitted: false,
        }
    }

    componentDidMount() {
        if (this.state.loadComplete) {
            return;
        }

        this.ensureDataLoaded();
    }

    componentDidUpdate(prevProps) {
        if (prevProps.id !== this.props.id) {
            this.setState({
                loadComplete: false,
                person: {},
            });

            this.ensureDataLoaded();
            return;
        }

        if (!this.state.loadComplete && !prevProps.loadComplete && this.props.loadComplete) {
            this.props.hidePageLoader();
            this.setState({
                loadComplete: true,
                person: this.getInitialPersonState(),
            });
        }

        if (prevProps.saveInProgress && !this.props.saveInProgress) {
            this.props.hidePageLoader();
        }
    }

    ensureDataLoaded() {
        this.props.showPageLoader();
        if (this.isNewPerson()) {
            this.props.newPerson();
        } else {
            this.props.fetchPerson(this.props.id);
        }
    }

    getInitialPersonState() {
        const { person } = this.props;

        const {
            personalInfo = {}, educationInfo = {}, workInfo = {}, languagesInfo = [],
            socialNetworksInfo = [], filesInfo = {}, filesDirectoryId,
        } = person;

        return {
            personalInfo: {
                id: personalInfo.id,
                lastName: personalInfo.lastName || '',
                firstName: personalInfo.firstName || '',
                middleName: personalInfo.middleName || '',
                selectedSex: personalInfo.sex,
                birthDate: personalInfo.birthDate,
                birthPlace: personalInfo.birthPlace || '',
                email: personalInfo.email || '',
                phone: personalInfo.phone || '',
                selectedDistrict: personalInfo.federalDistrict,
                selectedRegion: personalInfo.region,
                selectedDocument: personalInfo.document,
                documentNumber: personalInfo.documentNumber || '',
                photoId: personalInfo.photoId,
            },
            educationInfo: {
                selectedEducationLevel: educationInfo.educationLevel,
                university: educationInfo.university || '',
                specialty: educationInfo.specialty || '',
                graduationYear: educationInfo.graduationYear || '',
                educationExtraInfo: educationInfo.educationExtraInfo || '',
            },
            workInfo: {
                currentCompany: workInfo.currentCompany || '',
                currentPosition: workInfo.currentPosition || '',
                selectedIndustry: workInfo.industry,
                selectedWorkArea: workInfo.workArea,
                selectedManagementLevel: workInfo.managementLevel,
                selectedExperience: workInfo.managementExperience,
                selectedEmployeesNumber: workInfo.employeesNumber,
                hireYear: workInfo.hireYear || '',
                previousWorkPlaces: workInfo.previousWorkPlaces || '',
            },
            languagesInfo: {
                knownLanguages: List(languagesInfo.knownLanguages),
            },
            socialNetworksInfo: {
                networks: List(socialNetworksInfo.networks),
            },
            foreignerInfo: {
                selectedNationality: personalInfo.nationality,
                readyMoveToRussia: personalInfo.readyMoveToRussia || false,
            },
            familyInfo: {
                selectedFamilyStatus: personalInfo.familyStatus,
                childrenInfo: personalInfo.childrenInfo || '',
            },
            filesInfo: {
                files: List(filesInfo.files),
            },
            filesDirectoryId,
        };
    }

    isNewPerson() {
        return !this.props.id;
    }

    handleStateChange = (blockStateKey, blockState) => {
        this.setState(state => {
            const person = {
                ...state.person,
                [blockStateKey]: { ...state.person[blockStateKey], ...blockState }
            }

            return {
                ...state,
                person: { ...person }
            }
        });
    }

    isInputInvalid = (blockStateKey, inputStateKey, validators, inputErrorKey) => {
        if (!this.state.isFormSubmitted) {
            return false;
        }

        const errorKey = inputErrorKey || this.getInputErrorKey(inputStateKey);
        for (let validate of validators) {
            this[errorKey] = validate(this.state.person[blockStateKey][inputStateKey]);
            if (this[errorKey]) {
                this.isFormValid = false;
                return true;
            }
        }
    }

    getInputErrorMessage = (inputStateKey, inputErrorKey) => {
        const errorKey = inputErrorKey || this.getInputErrorKey(inputStateKey);
        return this[errorKey];
    }

    getInputErrorKey(inputStateKey) {
        return `${inputStateKey}_error`;
    }

    getCatalogs = names => {
        return names.reduce((obj, name) => {
            obj[name] = this.props.catalogs[name];
            return obj;
        }, {});
    }

    onSubmit = e => {
        e.preventDefault();
        this.isFormValid = true;
        this.setState({ isFormSubmitted: true }, () => {
            if (this.isFormValid) {
                this.props.showPageLoader(true);
                this.props.savePerson(this.getPersonToSave());
            } else {
                this.props.showWarningAlert('Не все поля корректно заполнены', 2.5);
            }
        });
    }

    getPersonToSave = () => {
        const {
            personalInfo, educationInfo, workInfo, languagesInfo, socialNetworksInfo,
            foreignerInfo, familyInfo, filesInfo, filesDirectoryId,
        } = this.state.person;

        const { selectedDistrict, selectedDocument, selectedRegion, selectedSex } = personalInfo;
        const { selectedEducationLevel } = educationInfo;
        const { selectedEmployeesNumber, selectedExperience, selectedIndustry, selectedManagementLevel, selectedWorkArea } = workInfo;

        return {
            ...personalInfo,
            federalDistrictId: selectedDistrict.id,
            regionId: selectedRegion.id,
            documentId: selectedDocument.id,
            sex: selectedSex.id,
            familyStatus: familyInfo.selectedFamilyStatus && familyInfo.selectedFamilyStatus.id,
            childrenInfo: familyInfo.childrenInfo,
            nationalityId: foreignerInfo.selectedNationality && foreignerInfo.selectedNationality.id,
            readyMoveToRussia: foreignerInfo.readyMoveToRussia,
            filesDirectoryId,
            educationInfo: {
                ...educationInfo,
                educationLevelId: selectedEducationLevel.id,
            },
            workInfo: {
                ...workInfo,
                employeesNumberId: selectedEmployeesNumber.id,
                managementExperienceId: selectedExperience.id,
                industryId: selectedIndustry.id,
                managementLevelId: selectedManagementLevel.id,
                workAreaId: selectedWorkArea.id,
            },
            languages: languagesInfo.knownLanguages.filter(x => x.language).map(x => ({
                languageId: x.language.id,
                languageLevelId: x.languageLevel.id,
            })),
            socialNetworks: socialNetworksInfo.networks.filter(x => x.value.trim()).map(x => ({
                networkId: x.network.id,
                value: x.value,
            })),
            files: filesInfo.files.filter(f => !f.error),
        }
    }

    render() {
        if (!this.state.loadComplete) {
            return null;
        }

        return (
            <div className="person-card person-card-edit">
                <Form className="person-card-form" autoComplete="off">
                    <PersonalInfoBlock
                        handleStateChange={this.handleStateChange.bind(null, 'personalInfo')}
                        isInputInvalid={this.isInputInvalid.bind(null, 'personalInfo')}
                        getInputErrorMessage={this.getInputErrorMessage}
                        {...this.getCatalogs(personalInfoBlockCatalogs)}
                        filesDirectoryId={this.props.person.filesDirectoryId}
                        {...this.state.person.personalInfo}
                    />
                    <EducationBlock
                        handleStateChange={this.handleStateChange.bind(null, 'educationInfo')}
                        isInputInvalid={this.isInputInvalid.bind(null, 'educationInfo')}
                        getInputErrorMessage={this.getInputErrorMessage}
                        {...this.getCatalogs(educationBlockCatalogs)}
                        {...this.state.person.educationInfo}
                    />
                    <WorkBlock
                        handleStateChange={this.handleStateChange.bind(null, 'workInfo')}
                        isInputInvalid={this.isInputInvalid.bind(null, 'workInfo')}
                        getInputErrorMessage={this.getInputErrorMessage}
                        {...this.getCatalogs(workInfoBlockCatalogs)}
                        {...this.state.person.workInfo}
                    />
                    <LanguagesBlock
                        handleStateChange={this.handleStateChange.bind(null, 'languagesInfo')}
                        isInputInvalid={this.isInputInvalid.bind(null, 'languagesInfo')}
                        getInputErrorMessage={this.getInputErrorMessage}
                        {...this.getCatalogs(languagesBlockCatalogs)}
                        {...this.state.person.languagesInfo}
                    />
                    <SocialNetworksBlock
                        handleStateChange={this.handleStateChange.bind(null, 'socialNetworksInfo')}
                        isInputInvalid={this.isInputInvalid.bind(null, 'socialNetworksInfo')}
                        getInputErrorMessage={this.getInputErrorMessage}
                        {...this.getCatalogs(socialNetworksBlockCatalogs)}
                        {...this.state.person.socialNetworksInfo}
                    />
                    <FamilyStatusBlock
                        handleStateChange={this.handleStateChange.bind(null, 'familyInfo')}
                        {...this.getCatalogs(socialNetworksBlockCatalogs)}
                        {...this.state.person.familyInfo}
                    />
                    <ForeignerBlock
                        handleStateChange={this.handleStateChange.bind(null, 'foreignerInfo')}
                        isInputInvalid={this.isInputInvalid.bind(null, 'foreignerInfo')}
                        getInputErrorMessage={this.getInputErrorMessage}
                        {...this.getCatalogs(foreignerBlockCatalogs)}
                        {...this.state.person.foreignerInfo}
                    />
                    <FilesBlock
                        handleStateChange={this.handleStateChange.bind(null, 'filesInfo')}
                        directoryId={this.props.person.filesDirectoryId}
                        {...this.state.person.filesInfo}
                    />
                </Form>
                <Button className="person-card-action-btn" color="primary" icon="save" type="submit" onClick={this.onSubmit}>Сохранить</Button>
            </div>
        );
    }
}

EditPerson.propTypes = {
    id: PropTypes.number,
    person: PropTypes.object,
}

export default connect(
    (state, ownProps) => {
        let isReadySelector;
        let personSelector;
        if (ownProps.id) {
            isReadySelector = isPersonReadySelector;
            personSelector = personFullSelector;
        } else {
            isReadySelector = isNewPersonReadySelector;
            personSelector = personNewSelector;
        }

        const isReady = isReadySelector(state);
        if (!isReady) {
            return { loadComplete: false };
        }

        return {
            loadComplete: true,
            saveInProgress: state.person && state.person.saving,
            person: personSelector(state),
            catalogs: personCatalogsSelector(state),
        }
    },
    { ...pageLoaderActions, fetchPerson, savePerson, newPerson, fetchCatalog, showWarningAlert }
)(EditPerson);