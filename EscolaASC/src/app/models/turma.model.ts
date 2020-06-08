import { Aluno } from './aluno.model';
import { Materia } from './materia.model';
export class Turma {

    public Turmaid : number;

    public nomeTurma: string;
    public Materia : Materia;
    public quantidadeAluno : number;
    public Materias : Array<Materia>
}
