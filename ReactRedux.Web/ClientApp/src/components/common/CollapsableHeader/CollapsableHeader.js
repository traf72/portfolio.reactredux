import './CollapsableHeader.scss';
import React from 'react';
import PropTypes from 'prop-types';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const CollapsableHeader = ({ isOpen, toggleOpen, className, tag: Tag, children }) => {
    const icon = isOpen ? 'angle-up' : 'angle-down';
    const componentClass = 'collapsable-header';
    className = `${className} ${componentClass}`;

    const getClass = suffix => `${componentClass}-${suffix}`;

    return (
        <Tag className={className} onClick={e => toggleOpen(!isOpen)}><FontAwesomeIcon className={getClass('icon')} icon={icon} />{children}</Tag>
    );
}


CollapsableHeader.propTypes = {
    isOpen: PropTypes.bool,
    toggleOpen: PropTypes.func,
    className: PropTypes.string,
    tag: PropTypes.string,
}

CollapsableHeader.defaultProps = {
    toggleOpen: x => x,
    className: '',
    tag: 'h4',
}

export default CollapsableHeader;