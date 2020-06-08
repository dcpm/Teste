
import { NovoPeriodoComponent } from './periodo/components/novo-periodo/novo-periodo.component';
import { PeriodoComponent } from './periodo/components/periodo.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ConsultaPeriodoComponent } from './periodo/components/consulta-periodo/consulta-periodo.component';
import { ConsultaTurmasComponent } from './periodo/components/consulta-turmas/consulta-turmas.component';


const routes: Routes = [
  {path: '' , component : PeriodoComponent},
 
  {path: 'novo-periodo', component : NovoPeriodoComponent},
  {path: 'consulta-periodo', component : ConsultaPeriodoComponent},
  {path: 'consulta-turmas', component : ConsultaTurmasComponent},
  
  
  
  //último
  {path: '**', redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
