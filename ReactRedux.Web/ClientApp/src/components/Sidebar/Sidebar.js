import './Sidebar.scss';
import React from 'react';
import PropTypes from 'prop-types';
import { Navbar, Nav, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { connect } from 'react-redux';
import { sidebarRoutes as routes, isPathMatch } from '../../routes';

const Sidebar = ({ className, path }) => {
    function getNavLink(url, icon, title) {
        return <NavLink tag={Link} active={isPathMatch(path, url)} to={url}><FontAwesomeIcon icon={icon} fixedWidth />{title}</NavLink>;
    }

    const resultClass = `${className} sidebar mt-2`;
    return (
        <Navbar className={resultClass} color="light">
            <Nav className="flex-column">
                <NavItem>
                    {getNavLink(routes.home.url, 'home', routes.home.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.personNew.url, 'address-card', routes.personNew.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.search.url, 'search', routes.search.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.charts.url, 'chart-pie', routes.charts.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.reports.url, 'file-invoice', routes.reports.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.importRoute.url, 'file-import', routes.importRoute.title)}
                </NavItem>
            </Nav>

            <h6 className="sidebar-heading d-flex justify-content-between align-items-center px-3 mt-4 mb-1 text-muted">
                <span>Администрирование</span>
            </h6>
            <Nav className="flex-column mb-2">
                <NavItem>
                    {getNavLink(routes.users.url, 'users', routes.users.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.usersActions.url, 'file-alt', routes.usersActions.title)}
                </NavItem>
                <NavItem>
                    {getNavLink(routes.attributes.url, 'tools', routes.attributes.title)}
                </NavItem>
            </Nav>
        </Navbar>
    );
}

Sidebar.propTypes = {
    className: PropTypes.string,
    path: PropTypes.string,
}

Sidebar.defaultProps = {
    className: '',
}

export default connect(
    state => {
        return {
            'path': state.router.location.pathname,
        }
    },
)(Sidebar);