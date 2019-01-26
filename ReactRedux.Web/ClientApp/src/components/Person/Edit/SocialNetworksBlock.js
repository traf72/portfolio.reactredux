import React from 'react';
import { Col, FormGroup, Label, Input, Collapse, Button } from 'reactstrap';
import Select, { IconOption } from '../../common/Select';
import CollapsableHeader from '../../common/CollapsableHeader';
import ValidationMessage from '../../common/ValidationMessage';
import ToggleOpen from '../../../decorators/ToggleOpen';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { SOCIAL_NETWORKS } from '../../../ducks/Catalog';

const SocialNetworksBlock = props => {
    const { handleStateChange } = props;

    function handleChange(e, networkInfo) {
        const networks = props.networks.set(props.networks.indexOf(networkInfo), { ...networkInfo, ...{ value: e.target.value } });
        handleStateChange({ networks });
    }

    function addNetwork(network) {
        const networks = props.networks.push({ network, value: '' });
        handleStateChange({ networks });
    }

    function removeNetwork(network) {
        const networks = props.networks.delete(props.networks.indexOf(network));
        handleStateChange({ networks });
    }

    function getAvailableNetworks() {
        const alreadySelected = props.networks.map(x => x.network.id);
        return props[SOCIAL_NETWORKS].data.filter(x => !alreadySelected.includes(x.id));
    }

    function validator() {
        return networks => {
            const isValid = networks.size && networks.find(x => x.value.trim());
            return isValid ? null : 'Заполните хотя бы одну социальную сеть';
        }
    }

    function renderNetworks() {
        return props.networks.map(network => renderNetwork(network));
    }

    function renderNetwork(networkInfo) {
        const { network, value } = networkInfo;
        return (
            <FormGroup key={network.code} row>
                <Label for={network.code} xs={1} className="social-icon-label" title={network.name}><FontAwesomeIcon icon={['fab', network.icon]} color={network.iconColor} fixedWidth /></Label>
                <Col xs={10} sm={8} lg={4}>
                    <Input bsSize="sm" id={network.code} value={value} onChange={e => handleChange(e, networkInfo)} />
                </Col>
                <Col xs={1} className="remove-item-col">
                    <Button close className="remove-item-btn" type="button" onClick={e => removeNetwork(networkInfo)} aria-label="Remove" tabIndex="-1" />
                </Col>
            </FormGroup>
        );
    }

    function renderAvailableNetworks() {
        return (
            <FormGroup row>
                <Label xs={1} className="social-icon-label"><FontAwesomeIcon icon="plus-circle" fixedWidth className="invisible" /></Label>
                <Col xs={10} sm={8} lg={4}>
                    <Select
                        value={null}
                        onChange={addNetwork}
                        options={getAvailableNetworks()}
                        bsSize="sm"
                        catalog
                        placeholder="Выберите социальную сеть"
                        components={{ Option: getSelectOption(IconOption) }}
                    />
                </Col>
            </FormGroup>
        );
    }

    function getSelectOption(IconOption) {
        return class Option extends React.Component {
            render() {
                const { data } = this.props;
                const iconProps = {
                    icon: ['fab', data.icon],
                    color: data.iconColor,
                }
                return (
                    <IconOption iconProps={iconProps} {...this.props} />
                );
            }
        }
    }

    return (
        <div className="person-card-social-networks-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Социальные сети и мессенджеры*
                <Input className="d-none" invalid={props.isInputInvalid('networks', [validator()])}/>
                <ValidationMessage className="ml-2" tag="span">{props.getInputErrorMessage('networks')}</ValidationMessage>
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    {renderNetworks()}
                    {renderAvailableNetworks()}
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(SocialNetworksBlock);