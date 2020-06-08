import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Periodo } from '../models/periodo.model';

@Injectable({
    providedIn : 'root'
})

export class PeriodoService {

    private readonly PATH = 'periodo';
    /**
     *
     */
    constructor(private http: HttpClient) {
        
        
    }

    getAllPeriodo(){
        return this.http.get('http://localhost:5000/api/periodo/');

    }

    create(periodo : Periodo){
        return this.http.post('http://localhost:5000/api/periodo/', periodo);
        
    }
    deletePeriodo(){

    }
}
