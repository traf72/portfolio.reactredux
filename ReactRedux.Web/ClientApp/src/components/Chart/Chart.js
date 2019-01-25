import './Chart.scss';
import React, { Component } from 'react';
import { Row, Col } from 'reactstrap';

class Chart extends Component {
    componentDidMount() {
        let script = document.getElementById('chartLib');
        if (!script) {
            script = document.createElement('script');
            script.src = 'https://cdnjs.cloudflare.com/ajax/libs/Chart.js/2.7.3/Chart.min.js';
            script.id = 'chartLib';
            script.onload = () => {
                const script = document.createElement('script');
                script.src = 'https://www.chartjs.org/samples/latest/utils.js';
                script.onload = this.renderCharts;
                document.head.appendChild(script);
            };
            document.head.appendChild(script);
        } else {
            this.renderCharts();
        }
    }

    renderCharts = () => {
        this.renderChart1();
        this.renderChart2();
    }

    renderChart1 = () => {
        const ctx = document.getElementById('myChart1');
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
                title: {
                    display: true,
                    text: 'График 1'
                },
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

    renderChart2() {
        const ctx = document.getElementById('myChart2').getContext("2d");

        var barChartData = {
            labels: ['Январь', 'Ферваль', 'Март', 'Апрель', 'Май', 'Июнь', 'Июль'],
            datasets: [{
                label: 'Dataset 1',
                backgroundColor: window.chartColors.red,
                stack: 'Stack 0',
                data: [
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor()
                ]
            }, {
                label: 'Dataset 2',
                backgroundColor: window.chartColors.blue,
                stack: 'Stack 0',
                data: [
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor()
                ]
            }, {
                label: 'Dataset 3',
                backgroundColor: window.chartColors.green,
                stack: 'Stack 1',
                data: [
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor(),
                    window.randomScalingFactor()
                ]
            }]
        };

        window.myBar = new window.Chart(ctx, {
            type: 'bar',
            data: barChartData,
            options: {
                title: {
                    display: true,
                    text: 'График 2'
                },
                tooltips: {
                    mode: 'index',
                    intersect: false
                },
                responsive: true,
                scales: {
                    xAxes: [{
                        stacked: true,
                    }],
                    yAxes: [{
                        stacked: true
                    }]
                }
            }
        });

        barChartData.datasets.forEach(function (dataset) {
            dataset.data = dataset.data.map(function () {
                return window.randomScalingFactor();
            });
        });
        window.myBar.update();
    }

    render() {
        return (
            <Row>
                <Col xs={12} xl={6}>
                    <canvas className="my-4 w-100" id="myChart1"></canvas>
                </Col>
                <Col xs={12} xl={6}>
                    <canvas className="my-4 w-100" id="myChart2"></canvas>
                </Col>
            </Row>
        );
    }
}

export default Chart;