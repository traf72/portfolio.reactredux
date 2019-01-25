import React from 'react';
import { Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select from '../../common/Select';
import CollapsableHeader from '../../common/CollapsableHeader';
import InputMask from '../../common/InputMask';
import ValidationMessage from '../../common/ValidationMessage';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { EDUCATIONAL_LEVELS } from '../../../ducks/Catalog';
import { requireValidator, yearValidator } from '../../../libs/validators';
import { yearMask } from '../../../constants';

const EducationBlock = props => {
    const { handleStateChange, isInputInvalid, getInputErrorMessage } = props;
    return (
        <div className="person-card-education-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Образование
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <FormGroup row>
                        <Label for="educationLevel" xs={2}>Уровень*</Label>
                        <Col xs={5}>
                            <Select
                                inputId="educationLevel"
                                value={props.selectedEducationLevel}
                                onChange={item => handleStateChange({ selectedEducationLevel: item })}
                                options={props[EDUCATIONAL_LEVELS].data}
                                catalog
                                bsSize="sm"
                                invalid={isInputInvalid('selectedEducationLevel', [requireValidator('Выберите уровень образования')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedEducationLevel')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="university" xs={2}>ВУЗ*</Label>
                        <Col xs={5}>
                            <Input bsSize="sm" id="university" value={props.university} onChange={e => handleStateChange({ university: e.target.value })}
                                invalid={isInputInvalid('university', [requireValidator('Введите ВУЗ')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('university')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="specialty" xs={2}>Специальность*</Label>
                        <Col xs={5}>
                            <Input bsSize="sm" id="specialty" value={props.specialty} onChange={e => handleStateChange({ specialty: e.target.value })}
                                invalid={isInputInvalid('specialty', [requireValidator('Введите специальность')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('specialty')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="graduationYear" xs={2}>Год окончания</Label>
                        <Col xs={2}>
                            <InputMask mask={yearMask} maskChar={null} bsSize="sm" id="graduationYear" value={props.graduationYear}
                                onChange={e => handleStateChange({ graduationYear: e.target.value })}
                                invalid={isInputInvalid('graduationYear', [yearValidator()])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('graduationYear')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="educationExtraInfo" xs={2}>Дополнительная информация</Label>
                        <Col xs={5}>
                            <Input type="textarea" bsSize="sm" id="educationExtraInfo" value={props.educationExtraInfo}
                                onChange={e => handleStateChange({ educationExtraInfo: e.target.value })}
                            />
                        </Col>
                    </FormGroup>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(EducationBlock);