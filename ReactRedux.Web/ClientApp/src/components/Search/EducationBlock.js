import React from 'react';
import { Row, Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select from '../common/Select';
import CollapsableHeader from '../common/CollapsableHeader';
import ToggleOpen from '../../decorators/ToggleOpen';
import { EDUCATIONAL_LEVELS } from '../../ducks/Catalog';

const EducationBlock = props => {
    const { handleStateChange } = props;

    return (
        <div className="search-inputs-education-block">
            <CollapsableHeader className="search-inputs-block-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Образование
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div>
                    <Row form>
                        <Col>
                            <FormGroup>
                                <Label for="educationLevel">Уровень</Label>
                                <Select
                                    inputId="educationLevel"
                                    value={props.selectedEducationLevel}
                                    onChange={item => handleStateChange({ selectedEducationLevel: item })}
                                    options={props[EDUCATIONAL_LEVELS].data}
                                    isClearable
                                    catalog
                                    bsSize="sm"
                                />
                            </FormGroup>
                        </Col>
                        <Col>
                            <FormGroup>
                                <Label for="university">ВУЗ</Label>
                                <Input bsSize="sm" id="university" value={props.university} onChange={e => handleStateChange({ university: e.target.value })} />
                            </FormGroup>
                        </Col>
                        <Col>
                            <FormGroup>
                                <Label for="specialty">Специальность</Label>
                                <Input bsSize="sm" id="specialty" value={props.specialty} onChange={e => handleStateChange({ specialty: e.target.value })} />
                            </FormGroup>
                        </Col>
                        <Col xs={2}>
                            <FormGroup>
                                <Label for="graduationYear">Год окончания</Label>
                                <Input bsSize="sm" id="graduationYear" value={props.graduationYear} onChange={e => handleStateChange({ graduationYear: e.target.value })} />
                            </FormGroup>
                        </Col>
                    </Row>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(EducationBlock);