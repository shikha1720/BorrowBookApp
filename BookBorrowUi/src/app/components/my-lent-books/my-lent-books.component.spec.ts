import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyLentBooksComponent } from './my-lent-books.component';

describe('MyLentBooksComponent', () => {
  let component: MyLentBooksComponent;
  let fixture: ComponentFixture<MyLentBooksComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [MyLentBooksComponent]
    });
    fixture = TestBed.createComponent(MyLentBooksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
