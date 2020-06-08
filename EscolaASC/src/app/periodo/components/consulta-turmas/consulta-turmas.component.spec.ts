import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaTurmasComponent } from './consulta-turmas.component';

describe('ConsultaTurmasComponent', () => {
  let component: ConsultaTurmasComponent;
  let fixture: ComponentFixture<ConsultaTurmasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultaTurmasComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultaTurmasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
