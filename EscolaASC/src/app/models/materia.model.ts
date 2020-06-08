import { Prova } from './prova.model';

export class Materia {

    public idMateria : number;

    public NomeMateria :string;
    public p1 : number;
    public p2 : number;
    public p3 : number;
    public pf : number;
    public provas : Array<Prova>;
    public media : number;
    
}
