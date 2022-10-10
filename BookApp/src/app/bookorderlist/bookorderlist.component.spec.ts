import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BookorderlistComponent } from './bookorderlist.component';

describe('BookorderlistComponent', () => {
  let component: BookorderlistComponent;
  let fixture: ComponentFixture<BookorderlistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BookorderlistComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(BookorderlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
