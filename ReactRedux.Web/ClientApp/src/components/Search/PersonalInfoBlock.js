import React from 'react';
import { Row, Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select from '../common/Select';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';
import { SEX, FEDERAL_DISTRICTS, REGIONS, IDENTITY_DOCUMENTS } from '../../ducks/Catalog';

const PersonalInfoBlock = props => {
    const { handleStateChange } = props;

    return (
        <div className="search-inputs-personal-info-block">
            <CollapsableHeader className="search-inputs-block-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Личная информация
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <Row form>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="lastName">Фамилия</Label>
                            <Input bsSize="sm" id="lastName" value={props.lastName} onChange={e => handleStateChange({ lastName: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="firstName">Имя</Label>
                            <Input bsSize="sm" id="firstName" value={props.firstName} onChange={e => handleStateChange({ firstName: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="middleName">Отчество</Label>
                            <Input bsSize="sm" id="middleName" value={props.middleName} onChange={e => handleStateChange({ middleName: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="sex">Пол</Label>
                            <Select
                                inputId="sex"
                                onChange={item => handleStateChange({ selectedSex: item })}
                                value={props.selectedSex}
                                options={props[SEX].data}
                                isClearable
                                bsSize="sm"
                                catalog
                            />
                        </FormGroup>
                    </Col>
                </Row>
                <Row form>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="startAge">Возраст</Label>
                            <div>
                                <Input type="number" bsSize="sm" id="startAge" value={props.startAge} className="d-inline-block w-25"
                                    onChange={e => handleStateChange({ startAge: e.target.value })} />
                                <span className="mx-2">-</span>
                                <Input type="number" bsSize="sm" id="endAge" value={props.endAge} className="d-inline-block w-25"
                                    onChange={e => handleStateChange({ endAge: e.target.value })} />
                            </div>
                        </FormGroup>
                    </Col>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="birthPlace">Место рождения</Label>
                            <Input bsSize="sm" id="birthPlace" value={props.birthPlace} onChange={e => handleStateChange({ birthPlace: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="email">Email</Label>
                            <Input type="email" bsSize="sm" id="email" value={props.email} onChange={e => handleStateChange({ email: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col md={6} xl>
                        <FormGroup>
                            <Label for="phone">Телефон</Label>
                            <Input bsSize="sm" id="phone" value={props.phone} onChange={e => handleStateChange({ phone: e.target.value })} />
                        </FormGroup>
                    </Col>
                </Row>
                <Row form>
                    <Col md={6} xl={3}>
                        <FormGroup>
                            <Label for="federalDistrict">Федеральный округ</Label>
                            <Select
                                inputId="federalDistrict"
                                value={props.selectedDistrict}
                                onChange={item => handleStateChange({ selectedDistrict: item })}
                                options={props[FEDERAL_DISTRICTS].data}
                                isClearable
                                catalog
                                bsSize="sm"
                            />
                        </FormGroup>
                    </Col>
                    <Col md={6} xl={3}>
                        <FormGroup>
                            <Label for="region">Регион</Label>
                            <Select
                                inputId="region"
                                value={props.selectedRegion}
                                onChange={item => handleStateChange({ selectedRegion: item })}
                                options={props[REGIONS].data}
                                isClearable
                                catalog
                                bsSize="sm"
                            />
                        </FormGroup>
                    </Col>
                </Row>
                <Row form>
                    <Col md={6} xl={3}>
                        <FormGroup>
                            <Label for="documentType">Документ</Label>
                            <Select
                                inputId="documentType"
                                value={props.selectedDocument}
                                onChange={item => handleStateChange({ selectedDocument: item })}
                                options={props[IDENTITY_DOCUMENTS].data}
                                isClearable
                                catalog
                                bsSize="sm"
                            />
                        </FormGroup>
                    </Col>
                    <Col xs={8} md={6} xl={3}>
                        <FormGroup>
                            <Label for="documentNumber">Номер документа</Label>
                            <Input value={props.documentNumber} id="documentNumber" bsSize="sm" onChange={e => handleStateChange({ documentNumber: e.target.value })} />
                        </FormGroup>
                    </Col>
                </Row>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(PersonalInfoBlock);