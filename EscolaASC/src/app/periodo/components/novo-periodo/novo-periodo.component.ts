import { PeriodoService } from './../../../services/periodo.service';
import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Periodo } from 'src/app/models/periodo.model';

@Component({
  selector: 'app-novo-periodo',
  templateUrl: './novo-periodo.component.html',
  styleUrls: ['./../../../app.component.css']
})
export class NovoPeriodoComponent implements OnInit {
  formPeriodo : FormGroup;

  constructor(private fb: FormBuilder, private periodoService : PeriodoService) { }

  

  ngOnInit(): void {
    
    this.gerarFormPeriodo();
  }

  enviarPeriodo(){
    const periodo: Periodo = this.formPeriodo.value;
    console.log(periodo);
    this.periodoService.create(periodo).subscribe((response =>{
      console.log(response);
      

    }))
    

  }

  gerarFormPeriodo(){
    this.formPeriodo = this.fb.group({
      QuantidadeAlunos : ['', [Validators.required]],
      QuantidadeTurmas : ['', [Validators.required]],
      QuantidadeMaterias : ['', [Validators.required]],
      NomePeriodo : ['', [Validators.required]]
      


    })

  }

}
