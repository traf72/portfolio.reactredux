import React from 'react';
import { Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select from '../../common/Select';
import CollapsableHeader from '../../common/CollapsableHeader';
import InputMask from '../../common/InputMask';
import ValidationMessage from '../../common/ValidationMessage';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { INDUSTRIES, WORK_AREAS, MANAGEMENT_LEVELS, MANAGEMENT_EXPERIENCES, EMPLOYEES_NUMBERS } from '../../../ducks/Catalog';
import { requireValidator, yearValidator } from '../../../libs/validators';
import { yearMask } from '../../../constants';

const WorkBlock = props => {
    const { handleStateChange, isInputInvalid, getInputErrorMessage } = props;
    return (
        <div className="person-card-work-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Текущее место работы
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <FormGroup row>
                        <Label for="currentCompany" sm={3}>Компания*</Label>
                        <Col sm={8} xl={5}>
                            <Input bsSize="sm" id="currentCompany" value={props.currentCompany} onChange={e => handleStateChange({ currentCompany: e.target.value })}
                                invalid={isInputInvalid('currentCompany', [requireValidator('Введите компанию')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('currentCompany')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="currentPosition" sm={3}>Должность*</Label>
                        <Col sm={8} xl={5}>
                            <Input bsSize="sm" id="currentPosition" value={props.currentPosition} onChange={e => handleStateChange({ currentPosition: e.target.value })}
                                invalid={isInputInvalid('currentPosition', [requireValidator('Введите должность')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('currentPosition')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="industry" sm={3}>Отрасль*</Label>
                        <Col sm={8} xl={5}>
                            <Select
                                inputId="industry"
                                value={props.selectedIndustry}
                                onChange={item => handleStateChange({ selectedIndustry: item })}
                                options={props[INDUSTRIES].data}
                                catalog
                                bsSize="sm"
                                invalid={isInputInvalid('selectedIndustry', [requireValidator('Выберите отрасль')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedIndustry')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="workArea" sm={3}>Область деятельности*</Label>
                        <Col sm={8} xl={5}>
                            <Select
                                inputId="workArea"
                                value={props.selectedWorkArea}
                                onChange={item => handleStateChange({ selectedWorkArea: item })}
                                options={props[WORK_AREAS].data}
                                catalog
                                bsSize="sm"
                                invalid={isInputInvalid('selectedWorkArea', [requireValidator('Выберите область деятельности')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedWorkArea')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="managementLevel" sm={3}>Уровень менеджмента*</Label>
                        <Col sm={8} xl={5}>
                            <Select
                                inputId="managementLevel"
                                value={props.selectedManagementLevel}
                                onChange={item => handleStateChange({ selectedManagementLevel: item })}
                                options={props[MANAGEMENT_LEVELS].data}
                                catalog
                                bsSize="sm"
                                invalid={isInputInvalid('selectedManagementLevel', [requireValidator('Выберите уровень менеджмента')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedManagementLevel')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="managementExperience" sm={3}>Опыт управления*</Label>
                        <Col sm={8} xl={3}>
                            <Select
                                inputId="managementExperience"
                                value={props.selectedExperience}
                                onChange={item => handleStateChange({ selectedExperience: item })}
                                options={props[MANAGEMENT_EXPERIENCES].data}
                                catalog
                                bsSize="sm"
                                invalid={isInputInvalid('selectedExperience', [requireValidator('Выберите опыт управления')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedExperience')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="employeesCount" sm={3}>Кол-во человек в подчинении*</Label>
                        <Col sm={8} xl={3}>
                            <Select
                                inputId="employeesCount"
                                value={props.selectedEmployeesNumber}
                                onChange={item => handleStateChange({ selectedEmployeesNumber: item })}
                                options={props[EMPLOYEES_NUMBERS].data}
                                catalog
                                bsSize="sm"
                                invalid={isInputInvalid('selectedEmployeesNumber', [requireValidator('Выберите кол-во человек в подчинении')])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('selectedEmployeesNumber')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="hireYear" sm={3}>Год трудоустройства</Label>
                        <Col xs={8} sm={3} lg={2}>
                            <InputMask mask={yearMask} maskChar={null} bsSize="sm" id="hireYear" value={props.hireYear}
                                onChange={e => handleStateChange({ hireYear: e.target.value })}
                                invalid={isInputInvalid('hireYear', [yearValidator()])}
                            />
                            <ValidationMessage className="validation-message-under">{getInputErrorMessage('hireYear')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="previousWorkPlaces" sm={3}>Предыдущие места работы</Label>
                        <Col sm={8} xl={5}>
                            <Input type="textarea" bsSize="sm" id="previousWorkPlaces" value={props.previousWorkPlaces}
                                onChange={e => handleStateChange({ previousWorkPlaces: e.target.value })}
                            />
                        </Col>
                    </FormGroup>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(WorkBlock);