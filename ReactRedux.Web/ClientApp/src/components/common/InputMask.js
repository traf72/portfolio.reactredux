import React from 'react';
import ReactInputMask from 'react-input-mask';
import BootstrapInput from '../../decorators/BootstrapInput';

const InputMask = props => {
    const formatChars = {
        '9': '[0-9]',
        'a': '[A-Za-z]',
        'б': '[А-Яа-я]',
        '*': '[A-Za-zА-Яа-я0-9]',
    };

    return (
        <ReactInputMask formatChars={formatChars} {...props} />
    );
}

export default BootstrapInput(InputMask);
