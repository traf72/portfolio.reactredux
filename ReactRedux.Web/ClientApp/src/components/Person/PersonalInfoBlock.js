import React from 'react';
import PhotoUploader from '../common/PhotoUploader';
import { Row, Col } from 'reactstrap';
import { getFullBirthDate } from '../../utils';

const PersonalInfoBlock = props => {
    function getFullName() {
        const { lastName = '', firstName = '', middleName = '' } = props;
        return `${lastName} ${firstName} ${middleName}`;
    }

    return (
        <div className="person-card-personal-info-block person-card-section">
            <Row>
                <Col sm={5} md={4} xl={3} className="person-card-photo-col">
                    <PhotoUploader photoId={props.photoId} readOnly />
                </Col>
                <Col className="ml-sm-n4 ml-md-2 ml-lg-n5">
                    <Row>
                        <Col className="person-card-person-name">
                            {getFullName()}
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Пол:</span><span className="person-card-value">{props.sex && props.sex.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Дата рождения:</span><span className="person-card-value">{getFullBirthDate(props.birthDate)}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Место рождения:</span><span className="person-card-value">{props.birthPlace}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Проживает:</span><span className="person-card-value">{props.region && props.region.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Телефон:</span><span className="person-card-value">{props.phone}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Email:</span><span className="person-card-value">{props.email}</span>
                        </Col>
                    </Row>
                    {props.document &&
                        <Row>
                            <Col>
                                <span className="person-card-label">{props.document.name}:</span><span className="person-card-value">{props.documentNumber}</span>
                            </Col>
                        </Row>
                    }
                </Col>
            </Row>
        </div>
    );
}

export default PersonalInfoBlock;