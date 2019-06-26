import React, {Component} from 'react';
import {Container} from 'reactstrap';
import './Home.css';


import {Services} from './Services';
import {Record} from './Record';
import {Blog} from './Blog';
import {Trainers} from './Trainers';
import {Contacts} from './Contacts';



export class Home extends Component {
    static displayName = Home.name;

    render() {
        return (
            <div>
                <div className="mb-3" id="bVideo">
                    <div className="overlay"/>
                    <video playsInline="playsInline" autoPlay="autoPlay" muted="muted" loop="loop">
                        <source src="/images/test.mp4" type="video/mp4"/>
                    </video>
                    <Container className="h-100">
                        <div className="d-flex h-100 text-center align-items-center">
                            <div className="text-white w-100">
                                <h1 className="display-3">Trampoline</h1>
                                <p className="lead mb-0">Can you do better than this guys?</p>
                            </div>
                        </div>
                    </Container>
                </div>
                <Services />
                <Record />
                <Blog />
                <Trainers />
                <Contacts />
            </div>
        );
    }
}
