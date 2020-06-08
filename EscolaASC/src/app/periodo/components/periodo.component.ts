import { PeriodoService } from './../../services/periodo.service';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Component, OnInit, ViewChild } from '@angular/core';
import { Router,  NavigationEnd, ActivatedRoute} from '@angular/router'
import { MatTableDataSource } from '@angular/material/table';
import { Periodo } from 'src/app/models/periodo.model';


import {  MatSortModule, MatSort } from '@angular/material/sort';


@Component({
  selector: 'app-periodo',
  templateUrl: './periodo.component.html',
  styleUrls: ['./../../app.component.css'],

})
export class PeriodoComponent implements OnInit {

  dataSource : MatTableDataSource<Periodo>;
  colunas : string[] = ['nomePeriodo', 'verPeriodo' ,'novo-periodo'];


  @ViewChild(MatSort) sort : MatSort;
  
  


  constructor(
    private route: ActivatedRoute,
    private Router : Router,
    private periodoService : PeriodoService

  ) { }

  

  ngOnInit() {
    this.loadPeriodo();
  }

  loadPeriodo() {
    this.periodoService.getAllPeriodo().subscribe((data)=>{
      console.log(data);

      let periodos : Array<Periodo> =JSON.parse(JSON.stringify(data));
  
      this.dataSource = new MatTableDataSource<Periodo>(periodos);
      this.dataSource.sort = this.sort;
    })
    
  }
  
  
  //se der faz
  deletePeriodo(){
    this.periodoService.deletePeriodo();
  }




}
