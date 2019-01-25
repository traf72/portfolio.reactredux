import React from 'react';
import PropTypes from 'prop-types';

export default Component => class ToggleOpen extends React.Component {
    static propTypes = {
        defaultOpen: PropTypes.bool,
    }

    static defaultProps = {
        defaultOpen: true,
    }

    constructor(props) {
        super(props);

        this.state = { isOpen: props.defaultOpen }
    }

    toggleOpen = () => {
        this.setState({ isOpen: !this.state.isOpen });
    }

    render() {
        return (
            <Component {...this.props} isOpen={this.state.isOpen} toggleOpen={this.toggleOpen} />
        );
    }
}