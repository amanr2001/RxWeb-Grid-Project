import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookedcarsComponent } from './bookedcars.component';

describe('BookedcarsComponent', () => {
  let component: BookedcarsComponent;
  let fixture: ComponentFixture<BookedcarsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookedcarsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookedcarsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
