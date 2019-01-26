import React from 'react';
import { Col, FormGroup, Collapse, Button } from 'reactstrap';
import Select from '../../common/Select';
import { LinkButton } from '../../common/Button';
import CollapsableHeader from '../../common/CollapsableHeader';
import ValidationMessage from '../../common/ValidationMessage';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { LANGUAGES, LANGUAGE_LEVELS } from '../../../ducks/Catalog';

const LanguagesBlock = props => {
    const { handleStateChange } = props;

    function handleChange(index, item) {
        const knownLanguages = props.knownLanguages.set(index, { ...props.knownLanguages.get(index), ...item });
        handleStateChange({ knownLanguages });
    }

    function addLanguage() {
        const knownLanguages = props.knownLanguages.push({ language: null, languageLevel: null, });
        handleStateChange({ knownLanguages });
    }

    function removeLanguage(index) {
        const knownLanguages = props.knownLanguages.delete(index);
        handleStateChange({ knownLanguages });
    }

    function getAvailableLanguages() {
        const alreadySelected = props.knownLanguages.filter(x => x.language).map(x => x.language.id);
        return props[LANGUAGES].data.filter(x => !alreadySelected.includes(x.id));
    }

    function validator(index) {
        return knownLanguages => {
            const langInfo = knownLanguages.get(index);
            const isValid = !langInfo.language || (langInfo.language && langInfo.languageLevel);
            return isValid ? null : 'Выберите уровень';
        }
    }

    function renderLanguageBlock(langInfo, key) {
        const langErrorKey = `knownLanguage_${key}`;
        return (
            <FormGroup row key={key}>
                <Col xs={6} lg={5} xl={4}>
                    <Select
                        value={langInfo.language}
                        onChange={item => handleChange(key, { language: item })}
                        options={getAvailableLanguages()}
                        placeholder="Выберите язык"
                        isClearable
                        catalog
                        bsSize="sm"
                    />
                </Col>
                <Col xs={5} lg={4} xl={3}>
                    <Select
                        value={langInfo.languageLevel}
                        onChange={item => handleChange(key, { languageLevel: item })}
                        options={props[LANGUAGE_LEVELS].data}
                        placeholder="Выберите уровень"
                        catalog
                        bsSize="sm"
                        invalid={props.isInputInvalid('knownLanguages', [validator(key)], langErrorKey)}
                    />
                    <ValidationMessage className="validation-message-under">{props.getInputErrorMessage(null, langErrorKey)}</ValidationMessage>
                </Col>
                <Col xs={1} className="remove-item-col">
                    <Button close className="remove-item-btn" type="button" onClick={e => removeLanguage(key)} aria-label="Remove" tabIndex="-1" />
                </Col>
            </FormGroup>
        );
    }

    return (
        <div className="person-card-languages-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Иностранные языки
                </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    {props.knownLanguages.map((item, index) => renderLanguageBlock(item, index))}
                    <LinkButton icon="plus-circle" onClick={addLanguage}>Добавить</LinkButton>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(LanguagesBlock);