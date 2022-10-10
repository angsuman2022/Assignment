import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookpaylistComponent } from './bookpaylist.component';

describe('BookpaylistComponent', () => {
  let component: BookpaylistComponent;
  let fixture: ComponentFixture<BookpaylistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookpaylistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookpaylistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
