import React from 'react';
import { Row, Col, Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';
import { yesNo } from '../../enums';

const ForeignerBlock = props => {
    if (!props.nationality) {
        return null;
    }

    return (
        <div className="person-card-foreigner-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Иностранец
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <Row>
                        <Col>
                            <span className="person-card-label">Гражданство:</span><span className="person-card-value">{props.nationality.name}</span>
                        </Col>
                    </Row>
                    <Row>
                        <Col>
                            <span className="person-card-label">Готов к переезду в Россию:</span><span className="person-card-value">{yesNo[props.readyMoveToRussia]}</span>
                        </Col>
                    </Row>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(ForeignerBlock);