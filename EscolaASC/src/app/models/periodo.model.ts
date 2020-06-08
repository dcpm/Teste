import { Turma } from './turma.model';
import { Materia } from './materia.model';


export class Periodo{

    public Periodoid : number;      
    public NomePeriodo: string;
    public QuantidadeAlunos : number;
    public  QuantidadeTurmas : number;
    public  QuantidadeMaterias : number;
    public periodo : Periodo;

    public materias : Array<Materia>
    public turmas: Array<Turma>
}
