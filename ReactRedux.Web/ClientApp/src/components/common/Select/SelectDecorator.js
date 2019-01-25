import './Select.scss';
import React from 'react';
import PropTypes from 'prop-types';

export default Component => class SelectDecorator extends React.Component {
    static propTypes = {
        bsSize: PropTypes.oneOf(['sm', 'lg']),
        catalog: PropTypes.bool,
        invalid: PropTypes.bool,
    }

    static defaultProps = {
        className: '',
    }

    getClass = () => {
        const { className, bsSize, invalid } = this.props;

        let resultClass = `react-select ${className}`;
        if (bsSize) {
            if (bsSize === 'lg') {
                console.warn('The value "lg" is not supported yet');
            } else {
                resultClass += `react-select-${bsSize}`;
            }
        }

        if (invalid) {
            resultClass += ' is-invalid';
        }

        return resultClass;
    }

    render() {
        const { className, bsSize, invalid, catalog, ...props } = this.props;

        let getOptionValue;
        let getOptionLabel;
        if (catalog) {
            getOptionValue = x => x.id;
            getOptionLabel = x => x.name;
        }

        return (
            <Component
                placeholder={props.multi ? 'Выберите элементы' : 'Выберите элемент'}
                noOptionsMessage={() => 'Ничего не найдено'}
                loadingMessage={() => 'Загрузка...'}
                className={this.getClass()}
                classNamePrefix="react-select"
                getOptionValue={getOptionValue}
                getOptionLabel={getOptionLabel}
                {...props}
            />
        );
    }
}