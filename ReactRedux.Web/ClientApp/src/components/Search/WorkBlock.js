import React from 'react';
import { Row, Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select from '../common/Select';
import InputMask from '../common/InputMask';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';
import { yearMask } from '../../constants';
import { INDUSTRIES, WORK_AREAS, MANAGEMENT_LEVELS, MANAGEMENT_EXPERIENCES, EMPLOYEES_NUMBERS } from '../../ducks/Catalog';

const WorkBlock = props => {
    const { handleStateChange } = props;

    return (
        <div className="search-inputs-work-block">
            <CollapsableHeader className="search-inputs-block-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Текущее место работы
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div>
                    <Row form>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="currentCompany">Компания</Label>
                                <Input bsSize="sm" id="currentCompany" value={props.currentCompany} onChange={e => handleStateChange({ currentCompany: e.target.value })} />
                            </FormGroup>
                        </Col>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="currentPosition">Должность</Label>
                                <Input bsSize="sm" id="currentPosition" value={props.currentPosition} onChange={e => handleStateChange({ currentPosition: e.target.value })} />
                            </FormGroup>
                        </Col>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="industry">Отрасль</Label>
                                <Select
                                    inputId="industry"
                                    value={props.selectedIndustry}
                                    onChange={item => handleStateChange({ selectedIndustry: item })}
                                    options={props[INDUSTRIES].data}
                                    isClearable
                                    catalog
                                    bsSize="sm"
                                />
                            </FormGroup>
                        </Col>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="workArea">Область деятельности</Label>
                                <Select
                                    inputId="workArea"
                                    value={props.selectedWorkArea}
                                    onChange={item => handleStateChange({ selectedWorkArea: item })}
                                    options={props[WORK_AREAS].data}
                                    isClearable
                                    catalog
                                    bsSize="sm"
                                />
                            </FormGroup>
                        </Col>
                    </Row>
                    <Row form>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="managementLevel">Уровень менеджмента</Label>
                                <Select
                                    inputId="managementLevel"
                                    value={props.selectedManagementLevel}
                                    onChange={item => handleStateChange({ selectedManagementLevel: item })}
                                    options={props[MANAGEMENT_LEVELS].data}
                                    isClearable
                                    catalog
                                    bsSize="sm"
                                />
                            </FormGroup>
                        </Col>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="managementExperience">Опыт управления</Label>
                                <Select
                                    inputId="managementExperience"
                                    value={props.selectedExperience}
                                    onChange={item => handleStateChange({ selectedExperience: item })}
                                    options={props[MANAGEMENT_EXPERIENCES].data}
                                    isClearable
                                    catalog
                                    bsSize="sm"
                                />
                            </FormGroup>
                        </Col>
                        <Col md={6} xl>
                            <FormGroup>
                                <Label for="employeesCount">Кол-во человек в подчинении</Label>
                                <Select
                                    inputId="employeesCount"
                                    value={props.selectedEmployeesNumber}
                                    onChange={item => handleStateChange({ selectedEmployeesNumber: item })}
                                    options={props[EMPLOYEES_NUMBERS].data}
                                    isClearable
                                    catalog
                                    bsSize="sm"
                                />
                            </FormGroup>
                        </Col>
                        <Col xs={6} md={3} xl={2}>
                            <FormGroup>
                                <Label for="hireYear">Год трудоустройства</Label>
                                <InputMask
                                    mask={yearMask}
                                    maskChar={null}
                                    bsSize="sm"
                                    id="hireYear"
                                    value={props.hireYear}
                                    onChange={e => handleStateChange({ hireYear: e.target.value })}
                                />
                            </FormGroup>
                        </Col>
                    </Row>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(WorkBlock);