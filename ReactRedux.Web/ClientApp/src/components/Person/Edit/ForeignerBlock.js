import React from 'react';
import { Col, FormGroup, Label, CustomInput, Collapse } from 'reactstrap';
import Select from '../../common/Select';
import CollapsableHeader from '../../common/CollapsableHeader';
import ValidationMessage from '../../common/ValidationMessage';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { COUNTRIES } from '../../../ducks/Catalog';

const ForeignerBlock = props => {
    const { handleStateChange } = props;

    function validator() {
        return value => {
            return value || !props.readyMoveToRussia ? null : 'Выберите гражданство';
        }
    }

    return (
        <div className="person-card-foreigner-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Для иностранцев
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    <FormGroup row>
                        <Label for="selectedNationality" xs={2}>Гражданство</Label>
                        <Col xs={5}>
                            <Select
                                inputId="selectedNationality"
                                value={props.selectedNationality}
                                onChange={item => handleStateChange({ selectedNationality: item })}
                                options={props[COUNTRIES].data}
                                isClearable
                                catalog
                                bsSize="sm"
                                invalid={props.isInputInvalid('selectedNationality', [validator()])}
                            />
                            <ValidationMessage className="validation-message-under">{props.getInputErrorMessage('selectedNationality')}</ValidationMessage>
                        </Col>
                    </FormGroup>
                    <FormGroup row>
                        <Col xs={2} />
                        <Col xs={5}>
                            <CustomInput type="checkbox" id="readyMoveToRussia" label="Готов к переезду в Россию" checked={props.readyMoveToRussia}
                                onChange={e => handleStateChange({ readyMoveToRussia: e.target.checked })}
                            />
                        </Col>
                    </FormGroup>
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(ForeignerBlock);