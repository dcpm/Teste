import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NovoPeriodoComponent } from './novo-periodo.component';

describe('NovoPeriodoComponent', () => {
  let component: NovoPeriodoComponent;
  let fixture: ComponentFixture<NovoPeriodoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NovoPeriodoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NovoPeriodoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
