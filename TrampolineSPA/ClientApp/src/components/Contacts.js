import React, {Component} from 'react';
import {Container} from 'reactstrap';
import './Contacts.css';

export class Contacts extends Component {
    static displayName = Contacts.name;
    
    render() {
        return (
            <div>
                <footer id="mainFooter">
                    <div>
                        <Container>
                            <div className="row py-4 d-flex align-items-center">
                                <div className="col-md-6 col-lg-5 text-center text-md-left mb-4 mb-md-0">
                                    <h6 className="mb-0">Оставайтесь на связи в наших социальных сетях!</h6>
                                </div>
                                <div className="col-md-6 col-lg-7 text-center text-md-right">
                                    <a className="mx-3 h1 d-inline-block" href="http://vk.com">
                                        <i className="fab fa-vk"></i>
                                        <span className="sr-only">View our VK Profile</span>
                                    </a>
                                    <a className="mx-3 h1 d-inline-block" href="http://twitter.com">
                                        <i className="fab fa-twitter"></i>
                                        <span className="sr-only">View our Twitter Profile</span>
                                    </a>
                                    <a className="mx-3 h1 d-inline-block" href="http://facebook.com">
                                        <i className="fab fa-facebook-f"></i>
                                        <span className="sr-only">View our Facebook Profile</span>
                                    </a>
                                    <a className="mx-3 h1 d-inline-block" href="http://instagram.com">
                                        <i className="fab fa-instagram"></i>
                                        <span className="sr-only">View our Instagram Profile</span>
                                    </a>
                                </div>
                            </div>
                        </Container>
                    </div>
                    <div className="bg-dark py-5">
                        <div className="container text-center text-md-left text-white">
                            <div className="row mt-3">

                                <div className="col-xl-3 col-md-6 mx-auto mb-4">
                                    <h5 className="text-uppercase font-weight-bold">Trampoline</h5>
                                    <hr className="bg-white"/>
                                    <p>
                                        Lorem ipsum dolor sit amet, consectetur
                                        adipisicing elit. Lorem ipsum dolor sit amet, consectetur
                                        adipisicing elit. Lorem ipsum dolor sit amet, consectetur
                                        adipisicing elit.
                                    </p>
                                </div>
                                <div className="col-xl-3 col-md-6 mx-auto mb-4">
                                    <h5 className="text-uppercase font-weight-bold">Products</h5>
                                    <hr className="bg-white"/>
                                    <p>
                                        <a href="">Свободные прыжки</a>
                                    </p>
                                    <p>
                                        <a href="">Гимнастика для детей</a>
                                    </p>
                                    <p>
                                        <a href="">Фитнес на батуте</a>
                                    </p>
                                    <p>
                                        <a href="">Записаться</a>
                                    </p>

                                </div>
                                <div className="col-xl-3 col-md-6 mx-auto mb-4">
                                    <h5 className="text-uppercase font-weight-bold">Useful links</h5>
                                    <hr className="bg-white"/>
                                    <p>
                                        <a href="">Ваш аккаунт</a>
                                    </p>
                                    <p>
                                        <a href="">Стать частью нашего коллектива</a>
                                    </p>
                                    <p>
                                        <a href="">Блог</a>
                                    </p>
                                    <p>
                                        <a href="">Помощь</a>
                                    </p>
                                </div>
                                <div className="col-xl-3 col-md-6 mx-auto mb-4">
                                    <h5 className="text-uppercase font-weight-bold">Contact</h5>
                                    <hr className="bg-white"/>
                                    <p>
                                        Belarus, Minsk.
                                    </p>
                                    <p>
                                        <a className="btn btn-outline-danger"
                                           href="mailto:liltihon@tut.by">liltihon@tut.by</a>
                                    </p>
                                    <p>
                                        +375(29)-305-03-65
                                    </p>
                                    <p>
                                        +375(29)-305-03-65
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="main-footer py-5">
                        <p className="text-muted text-center small p-0 mb-4">&copy; Copyright {new Date().getFullYear()} <a
                            href="">www.trampoline.com</a>. All rights reserved. All
                            trademarks used are properties of their respective owners.</p>
                        <div className="social d-table mx-auto">
                            <a className="mx-3 h4 d-inline-block" href="http://vk.com">
                                <i className="fab fa-vk"></i>
                                <span className="sr-only">View our VK Profile</span>
                            </a>
                            <a className="mx-3 h4 d-inline-block" href="http://twitter.com">
                                <i className="fab fa-twitter"></i>
                                <span className="sr-only">View our Twitter Profile</span>
                            </a>
                            <a className="mx-3 h4 d-inline-block" href="http://facebook.com">
                                <i className="fab fa-facebook-f"></i>
                                <span className="sr-only">View our Facebook Profile</span>
                            </a>
                            <a className="mx-3 h4 d-inline-block" href="http://instagram.com">
                                <i className="fab fa-instagram"></i>
                                <span className="sr-only">View our Instagram Profile</span>
                            </a>
                        </div>
                    </div>
                </footer>
            </div>
        );
    }
}