import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookingcartComponent } from './bookingcart.component';

describe('BookingcartComponent', () => {
  let component: BookingcartComponent;
  let fixture: ComponentFixture<BookingcartComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookingcartComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BookingcartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
