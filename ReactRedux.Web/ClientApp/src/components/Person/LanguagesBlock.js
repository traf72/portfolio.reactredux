import React from 'react';
import { Row, Col, Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';

const LanguagesBlock = props => {
    if (!props.knownLanguages || !props.knownLanguages.length) {
        return null;
    }

    function renderLanguage(langInfo) {
        const { language, languageLevel } = langInfo;
        return (
            <Row key={language.id}>
                <Col>
                    <span className="person-card-label">{language.name}:</span><span className="person-card-value">{languageLevel.name}</span>
                </Col>
            </Row>
        );
    }

    return (
        <div className="person-card-languages-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Иностранные языки
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    {props.knownLanguages.map(l => renderLanguage(l))}
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(LanguagesBlock);