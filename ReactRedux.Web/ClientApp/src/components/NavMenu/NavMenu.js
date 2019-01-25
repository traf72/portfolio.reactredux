import './NavMenu.scss';
import React from 'react';
import { Collapse, Navbar, NavbarBrand, NavbarToggler, Nav, NavItem, UncontrolledDropdown, DropdownToggle, DropdownMenu, DropdownItem, Form, Input } from 'reactstrap';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'

export default class NavMenu extends React.Component {
    state = {
        isOpen: false
    };

    toggle = () => {
        this.setState({
            isOpen: !this.state.isOpen
        });
    }

    render() {
        return (
            <header>
                <Navbar className="nav-menu p-0 shadow" fixed="top" expand="sm" color="dark" dark>
                    <NavbarBrand className="mx-3" tag="span">Кадровый резерв</NavbarBrand>
                    <NavbarToggler onClick={this.toggle} className="mr-2" />
                    <Collapse isOpen={this.state.isOpen} navbar>
                        <Nav className="mr-auto my-2 my-sm-0" navbar></Nav>
                        <Nav className="mx-3 mx-sm-2 my-2 my-sm-0" navbar>
                            <NavItem className="mr-0 mr-sm-2">
                                <Form inline>
                                    <Input type="search" placeholder="Поиск" aria-label="Поиск" />
                                </Form>
                            </NavItem>
                            <UncontrolledDropdown nav inNavbar>
                                <DropdownToggle nav caret><FontAwesomeIcon icon="user" />Сергей Иванов</DropdownToggle>
                                <DropdownMenu right>
                                    <DropdownItem><FontAwesomeIcon icon="cog" />Профиль</DropdownItem>
                                    <DropdownItem><FontAwesomeIcon icon="sign-out-alt" />Выход</DropdownItem>
                                </DropdownMenu>
                            </UncontrolledDropdown>
                        </Nav>
                    </Collapse>
                </Navbar>
            </header>
        );
    }
}