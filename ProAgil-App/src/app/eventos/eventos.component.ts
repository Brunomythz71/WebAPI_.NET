import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.css']
})
export class EventosComponent implements OnInit {

  eventos : any; //= [
  // {
  //   EventoID: 1,
  //   Tema: 'Angular',
  //   Local : 'Belo Horizonte'
  // },
  // {
  //   EventoID: 2,
  //   Tema: '.NET CORE e Angular',
  //   Local : 'São Paulo'
  // },
  // {
  //   EventoID: 3,
  //   Tema: '.NET CORE',
  //   Local : 'Rio de Janeiro'
  // },

//]
  constructor(private http: HttpClient) { }

  ngOnInit() {
    this.getEventos();
  }

  getEventos(){
    this.eventos = this.http.get("http://localhost:5000/api/Evento").subscribe(response => {this.eventos = response}, error => {console.log(error)});
  }
}
