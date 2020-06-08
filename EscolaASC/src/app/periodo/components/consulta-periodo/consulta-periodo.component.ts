import { TurmaService } from './../../../services/turma.service';
import { MatSort } from '@angular/material/sort';
import { PeriodoService } from './../../../services/periodo.service';
import { Materia } from './../../../models/materia.model';
import { MatTableDataSource } from '@angular/material/table';
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Periodo } from 'src/app/models/periodo.model';
import { Turma } from 'src/app/models/turma.model';

@Component({
  selector: 'app-consulta-periodo',
  templateUrl: './consulta-periodo.component.html',
  styleUrls: ['./../../../app.component.css']
})
export class ConsultaPeriodoComponent implements OnInit {

  dataSource : MatTableDataSource<Turma>;
  colunasTurma : string[] = ['NomeTurma', 'QuantidadeAluno', 'operacao'];
  

  @ViewChild(MatSort) sort : MatSort;

  



  constructor(private turmaService : TurmaService) { }

  ngOnInit() {

    this.loadTurmas();
    
  
    
  }



  loadTurmas(){
    this.turmaService.getAllTurmas().subscribe((data)=>{
      console.log(data);

      let turmas : Array<Turma> =JSON.parse(JSON.stringify(data));
  
      this.dataSource = new MatTableDataSource<Turma>(turmas);
      this.dataSource.sort = this.sort;
    })
    
    

  }
  
  

  redirectTurma(){
    
  }

}
