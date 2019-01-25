import React from 'react';
import { Row, Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select, { VirtualizedSelect } from '../common/Select';
import DatePicker from '../common/DatePicker';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';
import { SEX, FEDERAL_DISTRICTS, REGIONS, REGION_LOCALITIES, IDENTITY_DOCUMENTS } from '../../ducks/Catalog';

const PersonalInfoBlock = props => {
    const { handleStateChange } = props;

    function handleRegionChange(region) {
        if (region === props.selectedRegion) {
            return;
        }

        handleStateChange({
            selectedRegion: region,
            selectedLocality: null,
        });

        if (region) {
            props.loadLocalities(region.id);
        }
    }

    return (
        <div className="search-inputs-personal-info-block">
            <CollapsableHeader className="search-inputs-block-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Личная информация
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <Row form>
                    <Col>
                        <FormGroup>
                            <Label for="lastName">Фамилия</Label>
                            <Input bsSize="sm" id="lastName" value={props.lastName} onChange={e => handleStateChange({ lastName: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="firstName">Имя</Label>
                            <Input bsSize="sm" id="firstName" value={props.firstName} onChange={e => handleStateChange({ firstName: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="middleName">Отчество</Label>
                            <Input bsSize="sm" id="middleName" value={props.middleName} onChange={e => handleStateChange({ middleName: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col>
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
                    <Col>
                        <FormGroup>
                            <Label for="birthDate">Дата рождения</Label>
                            <DatePicker
                                id="birthDate"
                                bsSize="sm"
                                selected={props.birthDate}
                                onChange={value => handleStateChange({ birthDate: value })}
                            />
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="birthPlace">Место рождения</Label>
                            <Input bsSize="sm" id="birthPlace" value={props.birthPlace} onChange={e => handleStateChange({ birthPlace: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="email">Email</Label>
                            <Input type="email" bsSize="sm" id="email" value={props.email} onChange={e => handleStateChange({ email: e.target.value })} />
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="phone">Телефон</Label>
                            <Input bsSize="sm" id="phone" value={props.phone} onChange={e => handleStateChange({ phone: e.target.value })} />
                        </FormGroup>
                    </Col>
                </Row>
                <Row form>
                    <Col>
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
                    <Col>
                        <FormGroup>
                            <Label for="region">Регион</Label>
                            <Select
                                inputId="region"
                                value={props.selectedRegion}
                                onChange={handleRegionChange}
                                options={props[REGIONS].data}
                                isClearable
                                catalog
                                bsSize="sm"
                            />
                        </FormGroup>
                    </Col>
                    <Col>
                        <FormGroup>
                            <Label for="locality">Населённый пункт</Label>
                            <VirtualizedSelect
                                inputId="locality"
                                value={props.selectedLocality}
                                onChange={item => handleStateChange({ selectedLocality: item })}
                                options={props[REGION_LOCALITIES].data}
                                isClearable
                                catalog
                                bsSize="sm"
                                isLoading={props[REGION_LOCALITIES].loading}
                            />
                        </FormGroup>
                    </Col>
                </Row>
                <Row form>
                    <Col xs={4}>
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
                    <Col xs={3}>
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