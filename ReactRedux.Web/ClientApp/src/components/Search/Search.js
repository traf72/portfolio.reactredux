import './Search.scss';
import React, { Component } from 'react';
import DataGrid from '../common/DataGrid';
import EducationBlock from './EducationBlock';
import PersonalInfoBlock from './PersonalInfoBlock';
import WorkBlock from './WorkBlock';
import Button from '../common/Button';
import PhotoImg from '../common/PhotoImg';
import { Form } from 'reactstrap';
import { NavLink } from 'react-router-dom';
import { connect } from 'react-redux';
import { allActions as pageLoaderActions } from '../../ducks/PageLoader';
import { person as personRoute } from '../../routes';
import { fetchCatalog } from '../../ducks/Catalog';
import {
    search, searchSelector, catalogsSelector, personalInfoBlockCatalogs,
    educationBlockCatalogs, workInfoBlockCatalogs, allSearchCatalogs
} from '../../ducks/Search';

const columns = [
    {
        Header: '',
        accessor: 'photo',
        width: 35,
        sortable: false,
        Cell: e => {
            return (
                <NavLink to={personRoute.buildUrl({ id: e.original.id })}>
                    <PhotoImg className="search-result-photo" photoId={e.original.photoId} />
                </NavLink>
            );
        }
    },
    {
        Header: 'ФИО',
        accessor: 'fio',
        minWidth: 250,
        maxWidth: 350,
        Cell: e => <NavLink to={personRoute.buildUrl({ id: e.original.id })}>{e.value}</NavLink>,
    },
    {
        Header: 'Пол',
        accessor: 'sex',
        width: 100,
    },
    {
        Header: 'Дата рождения',
        accessor: 'birthDate',
        width: 150,
    },
    {
        Header: 'Проживает',
        accessor: 'residence',
        minWidth: 250,
        maxWidth: 350,
    },
    {
        Header: 'Телефон',
        accessor: 'phone',
        width: 150,
    },
    {
        Header: 'Email',
        accessor: 'email',
        minWidth: 180,
        maxWidth: 250,
    },
    {
        Header: 'Образование',
        accessor: 'educationLevel',
        minWidth: 250,
        maxWidth: 350,
    },
    {
        Header: 'Университет',
        accessor: 'university',
        minWidth: 250,
        maxWidth: 350,
    },
    {
        Header: 'Компания',
        accessor: 'currentCompany',
        minWidth: 150,
        maxWidth: 250,
    },
    {
        Header: 'Должность',
        accessor: 'currentPosition',
        minWidth: 200,
        maxWidth: 250,
    },
    {
        Header: 'Отрасль',
        accessor: 'industry',
        minWidth: 200,
        maxWidth: 250,
    },
    {
        Header: 'Уровень менеджмента',
        accessor: 'managementLevel',
        width: 150,
    },
    {
        Header: 'Опыт управления',
        accessor: 'managementExperience',
        width: 150,
    },
];

class Search extends Component {
    state = {
        personalInfo: {
            lastName: '',
            firstName: '',
            middleName: '',
            selectedSex: null,
            birthDate: null,
            birthPlace: '',
            email: '',
            phone: '',
            selectedDistrict: null,
            selectedRegion: null,
            selectedDocument: null,
            documentNumber: '',
        },
        educationInfo: {
            selectedEducationLevel: null,
            university: '',
            specialty: '',
            graduationYear: '',
            educationExtraInfo: '',
        },
        workInfo: {
            currentCompany: '',
            currentPosition: '',
            selectedIndustry: null,
            selectedWorkArea: null,
            selectedManagementLevel: null,
            selectedExperience: null,
            selectedEmployeesNumber: null,
            hireYear: '',
            previousWorkPlaces: '',
        },
    }

    componentDidMount() {
        allSearchCatalogs.forEach(c => this.props.fetchCatalog(c));
        this.props.search();
    }

    handleStateChange = (blockStateKey, blockState) => {
        this.setState(state => {
            return {
                ...state,
                [blockStateKey]: { ...state[blockStateKey], ...blockState }
            }
        });
    }

    getCatalogs = names => {
        return names.reduce((obj, name) => {
            obj[name] = this.props.catalogs[name];
            return obj;
        }, {});
    }

    onSubmit = e => {
        e.preventDefault();

        const { personalInfo, educationInfo, workInfo } = this.state;

        const criteria = {
            ...personalInfo,
            ...educationInfo,
            ...workInfo,
            sex: personalInfo.selectedSex && personalInfo.selectedSex.id,
            federalDistrictId: personalInfo.selectedDistrict && personalInfo.selectedDistrict.id,
            regionId: personalInfo.selectedRegion && personalInfo.selectedRegion.id,
            documentId: personalInfo.selectedDocument && personalInfo.selectedDocument.id,
            educationLevelId: educationInfo.selectedEducationLevel && educationInfo.selectedEducationLevel.id,
            industryId: workInfo.selectedIndustry && workInfo.selectedIndustry.id,
            workAreaId: workInfo.selectedWorkArea && workInfo.selectedWorkArea.id,
            managementLevelId: workInfo.selectedManagementLevel && workInfo.selectedManagementLevel.id,
            managementExperienceId: workInfo.selectedExperience && workInfo.selectedExperience.id,
            employeesNumberId: workInfo.selectedEmployeesNumber && workInfo.selectedEmployeesNumber.id,
        }

        this.props.search(criteria);
    }

    render() {
        return (
            <div className="search">
                <Form className="search-inputs" onSubmit={this.onSubmit} autoComplete="off">
                    <PersonalInfoBlock
                        handleStateChange={this.handleStateChange.bind(null, 'personalInfo')}
                        {...this.state.personalInfo}
                        {...this.getCatalogs(personalInfoBlockCatalogs)}
                    />
                    <EducationBlock
                        handleStateChange={this.handleStateChange.bind(null, 'educationInfo')}
                        {...this.state.educationInfo}
                        {...this.getCatalogs(educationBlockCatalogs)}
                        defaultOpen={false}
                    />
                    <WorkBlock
                        handleStateChange={this.handleStateChange.bind(null, 'workInfo')}
                        {...this.state.workInfo}
                        {...this.getCatalogs(workInfoBlockCatalogs)}
                        defaultOpen={false}
                    />
                    <Button className="search-btn" color="primary" icon="search" type="submit">Найти</Button>
                </Form>
                <div className="search-result">
                    <DataGrid
                        data={this.props.searchResult.data}
                        columns={columns}
                        loading={!this.props.searchResult.loadComplete}
                        showPageSizeOptions={false}
                    />
                </div>
            </div>
        );
    }
}

export default connect(state => {
    return {
        searchResult: searchSelector(state),
        catalogs: catalogsSelector(state),
    };
}, { ...pageLoaderActions, search, fetchCatalog }
)(Search);