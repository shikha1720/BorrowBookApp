import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBorrowedBooksComponent } from './my-borrowed-books.component';

describe('MyBorrowedBooksComponent', () => {
  let component: MyBorrowedBooksComponent;
  let fixture: ComponentFixture<MyBorrowedBooksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyBorrowedBooksComponent]
    });
    fixture = TestBed.createComponent(MyBorrowedBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
