import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookorderComponent } from './bookorder.component';

describe('BookorderComponent', () => {
  let component: BookorderComponent;
  let fixture: ComponentFixture<BookorderComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookorderComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookorderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
