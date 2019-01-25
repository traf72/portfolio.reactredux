import React from 'react';
import { components } from 'react-select';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

const IconOption = props => {
    return (
        <components.Option {...props}>
            <FontAwesomeIcon {...props.iconProps} fixedWidth />
            <span className="ml-2">{props.children}</span>
        </components.Option>
    );
}

export default IconOption;