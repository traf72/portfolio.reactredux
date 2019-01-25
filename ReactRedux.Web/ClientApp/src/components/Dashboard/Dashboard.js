import './Dashboard.scss';
import React, { Component } from 'react';
import { person as personRoute } from '../../routes';
import DataGrid from '../common/DataGrid';
import PhotoImg from '../common/PhotoImg';
import { NavLink } from 'react-router-dom';
import { connect } from 'react-redux';
import { search, selector } from '../../ducks/Search';

const columns = [
    {
        Header: '',
        accessor: 'photo',
        width: 35,
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
        minWidth: 150,
        maxWidth: 200,
    },
];

class Dashbord extends Component {
    componentDidMount() {
        this.props.search();
    }

    render() {
        return (
            <div>
                <h5>Недавно добавленные</h5>
                <DataGrid
                    data={this.props.data}
                    columns={columns}
                    loading={!this.props.loadComplete}
                    showPageSizeOptions={false}
                    showPagination={false}
                    sortable={false}
                />
            </div>
        );
    }
}

export default connect(state => {
    return { ...selector(state.search) };
}, { search })(Dashbord);