import React, { Component } from 'react';
import PropTypes from 'prop-types';
import AsyncPaginate from 'react-select-async-paginate';
import { sleep } from '../../../utils';
import Decorator from './SelectDecorator';

// Компонент AsyncPaginate с багом. Если пришли новые options из props, то он их не подцепляет.
// Поэтому сделал хак, что если приходят новые props, то компонент полностью перерисовывается
class VirtualizedSelect extends Component {
    static getDerivedStateFromProps(props, state) {
        if (props.options !== state.options) {
            return VirtualizedSelect.getState(props.options);
        }

        return null;
    }

    static getState(options) {
        return {
            key: Date.now(),
            options,
        }
    }

    constructor(props) {
        super(props);

        this.state = VirtualizedSelect.getState(props.options);
    }

    loadOptions = async (search, prevOptions) => {
        const { options, loadDelay, pageSize } = this.props;

        await sleep(loadDelay);

        let filteredOptions;
        if (!search) {
            filteredOptions = options;
        } else {
            const searchLower = search.toLowerCase();
            const getOptionLabel = this.getOptionLabelFn();
            filteredOptions = options.filter(option => {
                return getOptionLabel(option).toLowerCase().includes(searchLower);
            });
        }

        const hasMore = filteredOptions.length > prevOptions.length + pageSize;
        const slicedOptions = filteredOptions.slice(
            prevOptions.length,
            prevOptions.length + pageSize
        );

        return {
            options: slicedOptions,
            hasMore,
        };
    };

    getOptionLabelFn = () => {
        return this.props.getOptionLabel || (x => x.label);
    }

    render() {
        const { options, loadOptions, ...props } = this.props; 
        const initialOptions = options.slice(0, this.props.pageSize);

        return (
            <AsyncPaginate
                key={this.state.key}
                options={initialOptions}
                loadOptions={this.loadOptions}
                {...props}
            />
        );
    }
};

VirtualizedSelect.propTypes = {
    loadDelay: PropTypes.number,
    pageSize: PropTypes.number,
}

VirtualizedSelect.defaultProps = {
    loadDelay: 100,
    pageSize: 100,
}

export default Decorator(VirtualizedSelect);