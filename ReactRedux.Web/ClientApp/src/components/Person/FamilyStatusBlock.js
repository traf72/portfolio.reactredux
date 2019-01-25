import React from 'react';
import { Row, Col, Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';

const FamilyStatusBlock = props => {
    const { familyStatus, childrenInfo } = props;

    if (!familyStatus && !childrenInfo) {
        return null;
    }

    return (
        <div className="person-card-family-status-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Семейное положение
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    {familyStatus &&
                        <Row>
                            <Col>
                                <span className="person-card-label">Статус:</span><span className="person-card-value">{familyStatus.name}</span>
                            </Col>
                        </Row>
                    }
                    {childrenInfo &&
                        <Row>
                            <Col>
                                <span className="person-card-label">Дети:</span><span className="person-card-value">{childrenInfo}</span>
                            </Col>
                        </Row>
                    }
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(FamilyStatusBlock);