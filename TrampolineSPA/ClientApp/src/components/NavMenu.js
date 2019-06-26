import React, {Component} from 'react';
import {Collapse, Container, Nav, NavbarToggler, NavItem, NavLink} from 'reactstrap';
import './NavMenu.css';

export class NavMenu extends Component {
    static displayName = NavMenu.name;

    constructor(props) {
        super(props);

        this.toggleNavbar = this.toggleNavbar.bind(this);
        this.state = {
            collapsed: true
        };
    }

    toggleNavbar() {
        this.setState({
            collapsed: !this.state.collapsed
        });
    }

    componentDidMount = function () {
        window.addEventListener('scroll', NavMenu.scrollEffect);
    };

    componentWillUnmount = function () {
        window.removeEventListener('scroll', NavMenu.scrollEffect);
    };

    static scrollEffect() {
        let scrolled = window.pageYOffset || document.documentElement.scrollTop;
        let x = document.getElementsByClassName('nav-link');
        let nav = document.getElementById('main-nav');
        let i;
        if (scrolled > 100) {
            nav.classList.add("shadow");
            nav.setAttribute("style", "background-color: white;");
            for (i = 0; i < x.length; i++) {
                x[i].style.color = "black";
            }
        }
        if (100 > scrolled) {
            nav.classList.remove("shadow");
            nav.setAttribute("style", "background-color: null");
            for (i = 0; i < x.length; i++) {
                x[i].style.color = "white";
            }
        }
    };

    render() {
        return (
            <header>
                <div className="fixed-top" id="main-nav">
                    <Nav className="navbar-expand-md align-items-center">
                        <Container>
                            <NavbarToggler onClick={this.toggleNavbar} className="mr-2"/>
                            <Collapse className="navbar-collapse p-3" isOpen={!this.state.collapsed} navbar>
                                <ul className="navbar-nav nav-fill w-100">
                                    <NavItem>
                                        <NavLink>Абонементы</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink>Записаться</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink>Блог</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink>Наши тренеры</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink>Контакты</NavLink>
                                    </NavItem>
                                    <NavItem>
                                        <NavLink>Account</NavLink>
                                    </NavItem>
                                </ul>
                            </Collapse>
                        </Container>
                    </Nav>
                </div>
            </header>
        );
    }
}
