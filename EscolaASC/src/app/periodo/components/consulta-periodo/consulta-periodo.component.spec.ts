import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaPeriodoComponent } from './consulta-periodo.component';

describe('ConsultaPeriodoComponent', () => {
  let component: ConsultaPeriodoComponent;
  let fixture: ComponentFixture<ConsultaPeriodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ConsultaPeriodoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultaPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
