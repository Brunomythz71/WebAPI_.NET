import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { EventosComponent}  from './eventos/eventos.component';
import { ContatosComponent}  from './contatos/contatos.component';
import { PalestrantesComponent}  from './palestrantes/palestrantes.component';

const routes: Routes = [
{path: 'home', component: HomeComponent},
{path: 'eventos', component: EventosComponent},
{path: 'contatos', component: ContatosComponent},
{path: 'palestrantes', component: PalestrantesComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
