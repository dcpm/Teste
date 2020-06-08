import { AlunoService } from './../services/aluno.service';
//import { PeriodoRoutingModule } from './periodo-routing.module';
import { PeriodoComponent } from './components/periodo.component';
import { ConsultaTurmasComponent } from './components/consulta-turmas/consulta-turmas.component';
import { NovoPeriodoComponent } from './components/novo-periodo/novo-periodo.component';
import { ConsultaPeriodoComponent } from './components/consulta-periodo/consulta-periodo.component';
//import { ModalComponent } from './modal/modal.component';
import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import {  MatCardModule } from '@angular/material/card';
import { MatListModule } from '@angular/material/list';
import { MatTooltipModule } from '@angular/material/tooltip';
import {  MatIconModule } from '@angular/material/icon';
import {  MatSnackBarModule } from '@angular/material/snack-bar';
import {  MatPaginatorModule } from '@angular/material/paginator';
import {  MatSortModule } from '@angular/material/sort';
import {  MatTableModule } from '@angular/material/table';
import {  MatDialogModule } from '@angular/material/dialog';
import {  MatGridListModule } from '@angular/material/grid-list';
import {  MatSelectModule } from '@angular/material/select';
import {  MatProgressSpinnerModule} from '@angular/material/progress-spinner';
//import {  MatSidenavContainer, MatSidenavModule} from '@angular/material/sidenav';
import {  MatProgressBarModule } from '@angular/material/progress-bar';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { TurmaService } from '../services/turma.service';
import { PeriodoService } from '../services/periodo.service';
import { MateriaService } from '../services/materia.service';
//import { HttpUtilService } from './../shared';




@NgModule({
  declarations: [ConsultaPeriodoComponent, NovoPeriodoComponent, ConsultaTurmasComponent, PeriodoComponent],
  imports: [
    BrowserAnimationsModule,
    CommonModule,
    RouterModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatListModule,
    MatTooltipModule,
    MatIconModule,
    MatSnackBarModule,
    MatPaginatorModule,
    MatSortModule,
    MatTableModule,
    MatDialogModule,
    MatGridListModule,
    MatSelectModule,
    MatProgressSpinnerModule,
    //PeriodoRoutingModule,
    //MatSidenavContainer,
    //MatSidenavModule,
    MatProgressBarModule
    
  ],
  providers : [TurmaService, PeriodoService, MateriaService, AlunoService],
  
})
export class PeriodoModule { }
