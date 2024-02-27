import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { Book } from '../../models/model';

@Component({
  selector: 'app-my-borrowed-books',
  templateUrl: './my-borrowed-books.component.html',
  styleUrls: ['./my-borrowed-books.component.css']
})
export class MyBorrowedBooksComponent implements OnInit {

  listOfBorrowedBooks: any[] =[];

  constructor(protected api: ApiService){}

  ngOnInit(): void {
    let userid = this.api.getTokenUserInfo()?.id ?? 0;
    this.api.getBorrowedBooks(userid).subscribe({
      next: (res:any) =>{
        console.log(res);
        this.listOfBorrowedBooks = res;
      },
      error: (err:any) => console.log(err),
    });
  }
}
