import './ProgressBar.scss';
import React from 'react';
import PropTypes from 'prop-types';
import { Progress } from 'reactstrap';

const ProgressBar = ({thin, className, ...rest}) => {
    let resultClass = className;
    if (thin) {
        resultClass += ' progress-bar-thin';
    }

    return (
        <Progress className={resultClass} {...rest} />
    );
};

ProgressBar.propTypes = {
    thin: PropTypes.bool,
}

ProgressBar.defaultProps = {
    className: '',
}

export default ProgressBar;
