import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CastsDetailsComponent } from './casts-details.component';

describe('CastsDetailsComponent', () => {
  let component: CastsDetailsComponent;
  let fixture: ComponentFixture<CastsDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CastsDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CastsDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
