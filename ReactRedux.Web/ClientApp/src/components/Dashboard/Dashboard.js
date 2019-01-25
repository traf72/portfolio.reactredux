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

        let script = document.getElementById('chartLib');
        if (!script) {
            script = document.createElement('script');
            script.src = 'https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.3/Chart.min.js';
            script.id = 'chartLib';
            script.onload = script.onload = () => {
                const script = document.createElement('script');
                script.src = 'https://www.chartjs.org/samples/latest/utils.js';
                script.onload = this.renderChart;
                document.head.appendChild(script);
            };
            document.head.appendChild(script);
        } else {
            this.renderChart();
        };
    }

    renderChart() {
        const ctx = document.getElementById('myChart');
        // eslint-disable-next-line no-unused-vars
        const myChart = new window.Chart(ctx, {
            type: 'line',
            data: {
                labels: [
                    'Понедельник',
                    'Вторник',
                    'Среда',
                    'Четверг',
                    'Пятница',
                    'Суббота',
                    'Восресенье',
                ],
                datasets: [
                    {
                        data: [
                            15339,
                            21345,
                            18483,
                            24003,
                            23489,
                            24092,
                            12034
                        ],
                        lineTension: 0,
                        backgroundColor: 'transparent',
                        borderColor: '#007bff',
                        borderWidth: 4,
                        pointBackgroundColor: '#007bff'
                    }
                ]
            },
            options: {
                scales: {
                    yAxes: [
                        {
                            ticks: {
                                beginAtZero: false
                            }
                        }
                    ]
                },
                legend: {
                    display: false
                }
            }
        });
    }

    render() {
        return (
            <div>
                <canvas className="chart my-4 w-100" id="myChart">
                </canvas>
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