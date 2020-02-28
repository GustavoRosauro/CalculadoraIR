import React, { Component } from 'react';
import { Val, LimpaInputs } from './GenericFunctions'
export class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { consulta: false, salario: false, data: [],value:'' }
        this.mostrarComponentes = this.mostrarComponentes.bind(this);
        this.gravarSalario = this.gravarSalario.bind(this);
        this.onChange = this.onChange.bind(this);
    }
    mostrarComponentes() {

        this.setState({
            consulta: true
        })
    }
    onChange(e) {
        const re = /^[0-9\b]+$/;
        if (e.target.value === '' || re.test(e.target.value)) {
            this.setState({ value: e.target.value })
        }
    }
    async Inserir() {
        if (Val('cpf').length < 11) {
            alert('CPF menor que 11')
        }
        else {
            await fetch('api/CalculadoraIR/Inserir', {
                method: 'POST',
                body: JSON.stringify({
                    nome: Val('nome'),
                    cpf: Val('cpf'),
                    dependentes: Val('dependentes') === "" ? 0 : parseFloat(Val('dependentes')),
                    rendaBruta: Val('renda') === "" ? 0 : parseFloat(Val('renda'))
                }),
                headers: {
                    'Content-Type': 'application/json'
                }
            })
                .then(resp => {
                    if (resp) {
                        LimpaInputs();
                        alert('Inserido com sucesso !!');
                    }
                })
                .catch(error => console.log(error))
        }
    }
    async gravarSalario() {
        if (Val('salario') === "") {
            alert('informe um salário');
        }
        else {
            await fetch('api/CalculadoraIR/RetornaContribuintes?salario=' + Val('salario'))
                .then(resp => resp.json())
                .then(data => {
                    console.log(data)
                    this.setState({
                        salario: true,
                        data: data
                    })
                })
        }
    }
    voltar() {
        this.setState({ consulta: false, salario: false, data: [] })
    }
    static displayName = Home.name;
    render() {
        return (
            <>
                {this.state.consulta ? (
                    <>
                        <button className='btn btn-info' style={{ float: 'right' }} onClick={() => { this.voltar() }}>Voltar</button>
                        <div className='col-md-5'>
                            <label id='s'>Informe Salario Minimo</label>
                            <input className='form-control' id='salario' />
                            <br />
                            <button className='btn btn-primary' onClick={this.gravarSalario}>Salvar Salario</button>
                        </div>
                    </>
                ) : (<><div className="col-md-6">
                    <h1>Calculadora Imposto Renda</h1>
                    <label>Nome Contribuinte</label>
                    <input className='form-control' id='nome' />
                    <label>CPF</label>
                        <input className='form-control' type="text" onChange={this.onChange} value={this.state.value}  maxLength="11" id='cpf' />
                    <label>Depentes</label>
                    <input className='form-control' type='number' id='dependentes' />
                    <label>RendaBruta</label>
                    <input className='form-control' type='number' id='renda' />
                    <div class="row">
                        <div class="col-sm-12">
                            <button className='btn btn-success' onClick={() => { this.Inserir() }}>Salvar</button>
                            <button className='btn btn-info' style={margem} onClick={this.mostrarComponentes}>Finalizar Cadastro</button>
                        </div>
                    </div>            </div>
                </>)
                }
                {
                    this.state.salario ? (<>
                        <table className='table table-striped'>
                            <thead>
                                <tr>
                                    <th>Nome</th>
                                    <th>Valor do IR</th>

                                </tr>
                            </thead>
                            <tbody>
                                {this.state.data.map(d =>
                                    <tr hey={d.id}>
                                        <td>{d.nome}</td>
                                        <td>{(d.ir).toFixed(2)}</td>
                                    </tr>
                                )}
                            </tbody>
                        </table>
                    </>) : (<></>)
                }
            </>
        );
    }
}
let margem = {
    marginLeft: '5%'
}