import React, {Component} from 'react';
import {Container, Row, ModalBody, ModalHeader, FormGroup, Modal, ModalFooter} from 'reactstrap';

export class Services extends Component {
    static displayName = Services.name;

    constructor(props) {
        super(props);
        this.state = {services: [], service: null, modal: false, loading: true};

        this.toggle = this.toggle.bind(this);

        fetch('api/Service')
            .then(response => response.json())
            .then(data => {
                this.setState({services: data, loading: false});
            });
    }

    toggle() {
        this.setState(prevState => ({
            modal: !prevState.modal
        }));
    }

    openService = (id) => {
        this.toggle();
        fetch('api/Service/' + id)
            .then(response => response.json())
            .then(data => {
                this.setState({service: data})
            });
    };

    sendServiceForm = async () => {
        let form = document.forms["buyServiceForm"];
        if (form.checkValidity()) {
            await fetch("api/Service", {
                method: "POST", body: new FormData(form)
            });
            this.toggle();
            this.state.service.setState = null;
        } else {
            form.reportValidity()
        }
    };

    renderServiceList(services) {
        return (
            <Row>
                {services.map(service =>
                    <div key={service.id} className="col-lg-4 col-md-6 col-sm-12 mb-4">
                        <div className="card shadow border-3">
                            <img className="card-img-top" src={service.imgPath} alt=""/>
                            <div className="card-body">
                                <h6 className="card-title">{service.name}</h6>
                                <p className="card-text">
                                    {service.description}
                                </p>
                                <button type="button"
                                        onClick={() => this.openService(service.id)} className="btn btn-primary">
                                    Купить
                                </button>
                            </div>
                        </div>
                    </div>
                )}
            </Row>
        );
    }

    render() {
        return (
            <div className="py-5">
                <div id="subHeader" className="mb-3">
                    <h1 className="text-center">
                        Абонементы
                    </h1>
                </div>
                <Container>
                    {this.renderServiceList(this.state.services)}
                </Container>
                {this.state.service &&
                <div>
                    <Modal isOpen={this.state.modal} toggle={this.toggle} className={this.props.className}>
                        <ModalHeader toggle={this.toggle}>
                            {this.state.service.name} | {this.state.service.days} Занятий
                            | {this.state.service.price}$
                        </ModalHeader>
                        <ModalBody>
                            <form name="buyServiceForm">
                                <FormGroup>
                                    <label htmlFor="name">Имя</label>
                                    <input name="name" className="form-control" required/>
                                </FormGroup>
                                <FormGroup>
                                    <label htmlFor="email">Email адрес</label>
                                    <input name="email" className="form-control" required/>
                                </FormGroup>
                                <FormGroup>
                                    <label htmlFor="phoneNumber">Мобильный номер</label>
                                    <input name="phoneNumber" className="form-control" required/>
                                </FormGroup>
                                <input type="hidden" name="serviceId" value={this.state.service.id}/>
                            </form>
                        </ModalBody>
                        <ModalFooter className="justify-content-center">
                            <button type="button" className="btn btn-primary"
                                    onClick={() => this.sendServiceForm()}>Отправить
                            </button>
                        </ModalFooter>
                    </Modal>
                </div>
                }
            </div>
        );
    }
}