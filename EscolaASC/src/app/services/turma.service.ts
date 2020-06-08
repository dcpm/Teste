import { Turma } from '../models/turma.model';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
    providedIn : 'root'
})

export class TurmaService {

    /**
     *
     */
    constructor(private http: HttpClient, ) {
        
        
    }

    getAllTurmas() : Observable<Turma[]>
    {
        return this.http.get<Turma[]>(`http://localhost:5000/api/periodo/turma/`);

    }

    getTurmaById(Turmaid : number) : Observable<Turma>
    {
        return this.http.get<Turma>(`http://localhost:5000/api/periodo/turma/`);

    }

    
}


