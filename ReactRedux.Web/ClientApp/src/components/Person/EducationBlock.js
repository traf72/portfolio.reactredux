import React from 'react';
import { Row, Col, Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';

const EducationBlock = props => {
    return (
        <div className="person-card-education-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Образование
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <Row>
                        <Col>
                            <span className="person-card-label">Уровень:</span><span className="person-card-value">{props.educationLevel && props.educationLevel.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">ВУЗ:</span><span className="person-card-value">{props.university}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Специальность:</span><span className="person-card-value">{props.specialty}</span>
                        </Col>
                    </Row>
                    {props.graduationYear &&
                        <Row>
                             <Col>
                                 <span className="person-card-label">Год окончания:</span><span className="person-card-value">{props.graduationYear}</span>
                             </Col>
                        </Row>
                    }
                    {props.educationExtraInfo &&
                        <Row>
                            <Col>
                                <span className="person-card-label">Дополнительная информация:</span><span className="person-card-value">{props.educationExtraInfo}</span>
                            </Col>
                        </Row>
                    }
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(EducationBlock);