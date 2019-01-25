import React from 'react';
import { Col, FormGroup, Label, Input, Collapse } from 'reactstrap';
import Select from '../../common/Select';
import CollapsableHeader from '../../common/CollapsableHeader';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { FAMILY_STATUS } from '../../../ducks/Catalog';

const FamilyStatusBlock = props => {
    const { handleStateChange } = props;

    return (
        <div className="person-card-family-status-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Семейное положение
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <FormGroup row>
                        <Label for="selectedFamilyStatus" xs={2}>Статус</Label>
                        <Col xs={4}>
                            <Select
                                inputId="selectedFamilyStatus"
                                value={props.selectedFamilyStatus}
                                onChange={item => handleStateChange({ selectedFamilyStatus: item })}
                                options={props[FAMILY_STATUS].data}
                                isClearable
                                catalog
                                bsSize="sm"
                            />
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Label for="childrenInfo" xs={2}>Дети</Label>
                        <Col xs={4}>
                            <Input bsSize="sm" id="childrenInfo" value={props.childrenInfo} onChange={e => handleStateChange({ childrenInfo: e.target.value })} />
                        </Col>
                    </FormGroup>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(FamilyStatusBlock);