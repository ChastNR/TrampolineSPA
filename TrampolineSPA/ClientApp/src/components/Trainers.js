import React, {Component} from 'react';
import {Container, Row} from 'reactstrap';

export class Trainers extends Component {
    static displayName = Trainers.name;

    render() {
        return (
            <div className="py-5">
                <div id="trainersHeader" className="mb-3">
                    <h1 className="text-center">
                        Наши тренеры
                    </h1>
                </div>
                <Container>
                    <Row>
                        <div className="col-xl-3 col-md-6 mb-4">
                            <div className="card border-0 shadow">
                                <img src="https://source.unsplash.com/TMgQMXoglsM/500x350" className="card-img-top"
                                     alt="..."/>
                                <div className="card-body text-center">
                                    <h5 className="card-title mb-0">NoName</h5>
                                    <div className="card-text text-black-50">Мастер спорта по гимнастике</div>
                                </div>
                            </div>
                        </div>
                        <div className="col-xl-3 col-md-6 mb-4">
                            <div className="card border-0 shadow">
                                <img src="https://source.unsplash.com/9UVmlIb0wJU/500x350" className="card-img-top"
                                     alt="..."/>
                                <div className="card-body text-center">
                                    <h5 className="card-title mb-0">NoName</h5>
                                    <div className="card-text text-black-50">Мастер спорта по акробатике</div>
                                </div>
                            </div>
                        </div>
                        <div className="col-xl-3 col-md-6 mb-4">
                            <div className="card border-0 shadow">
                                <img src="https://source.unsplash.com/sNut2MqSmds/500x350" className="card-img-top"
                                     alt="..."/>
                                <div className="card-body text-center">
                                    <h5 className="card-title mb-0">NoName</h5>
                                    <div className="card-text text-black-50">Мастер спорта по батутному спорту</div>
                                </div>
                            </div>
                        </div>
                        <div className="col-xl-3 col-md-6 mb-4">
                            <div className="card border-0 shadow">
                                <img src="https://source.unsplash.com/ZI6p3i9SbVU/500x350" className="card-img-top"
                                     alt="..."/>
                                <div className="card-body text-center">
                                    <h5 className="card-title mb-0">NoName</h5>
                                    <div className="card-text text-black-50">Мастер спорта по спортивной
                                        гимнастике
                                    </div>
                                </div>
                            </div>
                        </div>
                    </Row>
                </Container>
            </div>
        );
    }
}
                