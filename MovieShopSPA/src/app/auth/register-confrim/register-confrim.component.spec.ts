import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterConfrimComponent } from './register-confrim.component';

describe('RegisterConfrimComponent', () => {
  let component: RegisterConfrimComponent;
  let fixture: ComponentFixture<RegisterConfrimComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterConfrimComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterConfrimComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
