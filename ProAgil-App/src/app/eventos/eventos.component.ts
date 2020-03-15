import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { stringify } from 'querystring';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';


@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos : any = [];
  eventosFiltratos : any = [];
  imagemLargura : number = 50;
  imagemMargem : number = 2;
  exibeImagem : boolean = true;
  exibeImagemTxt : string = 'OCULTAR IMAGEM';
  _filtroLista : string;

  get filtroLista() : string{
    return this._filtroLista;
  }
  set filtroLista(value: string){
    this._filtroLista = value;
    this.eventosFiltratos = !this.filtroLista ? this.eventos : this.buscarEvento(this.filtroLista);
  }

  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  getEventos(){
    this.eventos = this.http.get("http://localhost:5000/api/Evento").subscribe(response => {this.eventos = response}, error => {console.log(error)});
    this.eventosFiltratos = this.http.get("http://localhost:5000/api/Evento").subscribe(response => {this.eventosFiltratos = response}, error => {console.log(error)});
  }

  ocutarImagem(){
    this.exibeImagem = !this.exibeImagem;
    this.exibeImagemTxt = this.exibeImagem == false ? 'MOSTRA IMAGEM' : 'OCULTAR IMAGEM';
  }

  buscarEvento(aBuscar : string) : any{
    aBuscar = aBuscar.toLocaleLowerCase();
    return this.eventos.filter(evento  => evento.tema.toLocaleLowerCase().indexOf(aBuscar) !== -1);
  }


}
