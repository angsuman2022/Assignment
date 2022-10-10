import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookreadComponent } from './bookread.component';

describe('BookreadComponent', () => {
  let component: BookreadComponent;
  let fixture: ComponentFixture<BookreadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookreadComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookreadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
