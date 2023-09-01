import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellapprovalComponent } from './sellapproval.component';

describe('SellapprovalComponent', () => {
  let component: SellapprovalComponent;
  let fixture: ComponentFixture<SellapprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellapprovalComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SellapprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
