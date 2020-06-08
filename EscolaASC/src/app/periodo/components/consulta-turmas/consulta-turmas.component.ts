import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Aluno } from 'src/app/models/aluno.model';

@Component({
  selector: 'app-consulta-turmas',
  templateUrl: './consulta-turmas.component.html',
  styleUrls: ['./../../../app.component.css']
})
export class ConsultaTurmasComponent implements OnInit {

  dataSource : MatTableDataSource<Aluno>;
  colunas : string[] = ['nome', 'p1', 'p2', 'p3','pf','media', 'operacao'];


  constructor() { }

  ngOnInit(): void {
  }

}
