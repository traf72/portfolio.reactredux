import React from 'react';
import { Row, Col, Collapse } from 'reactstrap';
import CollapsableHeader from '../common/CollapsableHeader';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import ToggleOpen from '../../decorators/ToggleOpen';
import { socialNetworkTypes } from '../../enums';
import { trimStart } from '../../utils';

const SocialNetworksBlock = props => {
    if (!props.networks || !props.networks.length) {
        return null;
    }

    function getSocialNetworkUrl(network, value) {
        if (network.type === socialNetworkTypes.Messenger) {
            return null;
        }

        return `https://${value}`;
    }

    function renderSocialNetwork(networkInfo) {
        let { network, value } = networkInfo;
        value = trimStart(value, 'http://');
        value = trimStart(value, 'https://');

        return (
            <Row key={network.id} className="person-card-social-icon-row">
                <Col>
                    <FontAwesomeIcon className="person-card-label person-card-social-icon-label" icon={['fab', network.icon]} color={network.iconColor} fixedWidth />
                    <a href={getSocialNetworkUrl(network, value)} className="person-card-value person-card-social-icon-value" target="__blank">{value}</a>
                </Col>
            </Row>
        );
    }

    return (
        <div className="person-card-social-networks-block">
            <CollapsableHeader className="person-card-section-header" isOpen={props.isOpen} toggleOpen={props.toggleOpen}>
                Социальные сети и мессенджеры
            </CollapsableHeader>
            <Collapse isOpen={props.isOpen}>
                <div className="person-card-section">
                    {props.networks.map(n => renderSocialNetwork(n))}
                </div>
            </Collapse>
        </div>
    );
}

export default ToggleOpen(SocialNetworksBlock);
