import React from 'react';
import ReactSelect, { components } from 'react-select';
import Decorator from './SelectDecorator';

const Select = props => {
    return (
        <ReactSelect {...props} />
    );
};

export default Decorator(Select);
export { components }; 
