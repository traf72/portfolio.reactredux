import React from 'react';
import { Row, Col, Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';

const WorkBlock = props => {
    return (
        <div className="person-card-work-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Текущее место работы
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <Row>
                        <Col>
                            <span className="person-card-label">Компания:</span><span className="person-card-value">{props.currentCompany}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Должность:</span><span className="person-card-value">{props.currentPosition}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Отрасль:</span><span className="person-card-value">{props.industry && props.industry.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Область деятельности:</span><span className="person-card-value">{props.workArea && props.workArea.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Уровень менеджмента:</span><span className="person-card-value">{props.managementLevel && props.managementLevel.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Опыт управления:</span><span className="person-card-value">{props.managementExperience && props.managementExperience.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Кол-во человек в подчинении:</span><span className="person-card-value">{props.employeesNumber && props.employeesNumber.name}</span>
                        </Col>
                    </Row>
                    {props.hireYear &&
                        <Row>
                            <Col>
                                <span className="person-card-label">Год трудоустройства:</span><span className="person-card-value">{props.hireYear}</span>
                            </Col>
                        </Row>
                    }
                    {props.previousWorkPlaces &&
                        <Row>
                            <Col>
                                <span className="person-card-label">Описание предыдущих мест работы:</span><span className="person-card-value">{props.previousWorkPlaces}</span>
                            </Col>
                        </Row>
                    }
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(WorkBlock);