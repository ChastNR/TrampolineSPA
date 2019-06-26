import React, {Component} from 'react';
import {Container} from 'reactstrap';

export class Record extends Component {
    static displayName = Record.name;

    visitDate = () => {

        let dt = new Date();

        let currentMonth=('0'+(dt.getMonth())).slice(-2);
        
        let minDate = dt.getFullYear() + "-" + currentMonth + "-" + dt.getDate();
        let maxDate = dt.getFullYear() + "-" + currentMonth + "-31";
        
        return (
            <input type="date" className="form-control" name="VisitDate"
                   min={minDate} max={maxDate} />
        );
    };

    visitTime = () => {
        let arr = [];

        let dt = new Date();
        
        for (let i = 10; i < 22; i++) {
            if(i > dt.getHours())
            {
                arr.push(<option key={i}>{i + ':00'}</option>)  
            }
            else
            {
                i = dt.getHours() + 2;
                arr.push(<option key={i}>{i + ':00'}</option>)
            }
        }
        
        return (
            <select className="form-control" name="VisitTime">
            {arr}
            </select>
        );
    };

    static async SendRecord() {
        let form = document.forms["clientRecordForm"];
        let status = document.getElementById("status");
        if (form.checkValidity()) {
            await fetch("api/Home/SendRecord", {
                method: "POST", body: new FormData(form)
            });
            status.setAttribute("style", "color:green;");
            status.innerHTML = "Вы успешно записались!";
            form.reset();
        } else {
            status.setAttribute("style", "color:red;");
            status.innerHTML = "Заполните, пожалуйста, все поля!";
        }
    }

    componentDidMount = function () {
        document.getElementById("SubmitButton")
            .addEventListener('click', Record.SendRecord);
    };

    render() {
        return (
            <div className="py-5">
                <div id="Record" className="mb-3">
                    <h1 className="text-center">
                        <a className="text-dark">
                            Записаться
                        </a>
                    </h1>
                </div>
                <Container>
                    <form name="clientRecordForm" className="needs-validation">
                        <div className="form-row">
                            <div className="col-md-6 mb-3">
                                <label htmlFor="Name">Имя</label>
                                <input type="text" name="Name" className="form-control" placeholder="Ваше имя"
                                       required/>
                            </div>
                            <div className="col-md-6 mb-3">
                                <label htmlFor="PhoneNumber">Номер телефона</label>
                                <input type="text" name="PhoneNumber" className="form-control"
                                       placeholder="Номер телефона" required/>
                            </div>
                        </div>
                        <div className="form-row">
                            <div className="col-md-3 mb-3">
                                <label htmlFor="VisitDate">Дата</label>
                                {this.visitDate()}
                            </div>
                            <div className="col-md-3 mb-3">
                                <label htmlFor="VisitTime">Время</label>
                                {this.visitTime()}
                            </div>
                            <div className="col-md-6 mb-3">
                                <label htmlFor="Quantity">Количество посетителей</label>
                                <input type="number" name="Quantity" className="form-control" max="10" min="1"
                                       placeholder="Максимум 10" required/>
                            </div>
                        </div>
                        <div className="text-center mt-3">
                            <button type="button" className="btn btn-primary" id="SubmitButton">Отправить</button>
                        </div>
                    </form>
                    <div className="text-center m-3 p-3" id="status">
                    </div>
                </Container>
            </div>
        );
    }
}