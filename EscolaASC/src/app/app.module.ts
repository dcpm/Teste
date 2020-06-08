import { AlunoService } from './services/aluno.service';
import { MateriaService } from './services/materia.service';
import { PeriodoService } from './services/periodo.service';
import { TurmaService } from './services/turma.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PeriodoModule } from './periodo/periodo.module';
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

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    PeriodoModule,
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
    //MatSidenavContainer,
    //MatSidenavModule,
    MatProgressBarModule,


    
    AppRoutingModule
  ],
  providers: [TurmaService, PeriodoService, MateriaService, AlunoService],
  bootstrap: [AppComponent]
})
export class AppModule { }
