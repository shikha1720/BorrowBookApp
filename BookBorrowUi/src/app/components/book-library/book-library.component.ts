import { Component, OnInit } from '@angular/core';
import { Book } from '../../models/model';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-book-library',
  templateUrl: './book-library.component.html',
  styleUrls: ['./book-library.component.css']
})
export class BookLibraryComponent implements OnInit {
  allBooks: Book[] = [];
  availableBooks: Book[] = [];
  displayedColumns: string[] =[
    'id',
    'name',
    'author',
    'genre',
    'isBookAvailable',
    'detail',
  ];

  constructor(private api: ApiService,
              private router: Router){}

  ngOnInit(): void {
    let userId = this.api.getTokenUserInfo()?.id ?? 0;
    this.api.getAllBooks().subscribe({
      next: (res: Book[]) => {
        this.allBooks = res;
        this.allBooks = this.allBooks.filter(book => book.lentByUserId != userId);
        this.availableBooks = [...this.allBooks];
        console.log(this.availableBooks);
        console.log(this.allBooks);
      },
      error: (err: any) => console.log(err),
    });
  }

  getBookCount() {
    return this.availableBooks.length;
    //return this.availableBooks.reduce((pv,cv) => cv.books.length +pv, 0);
  }

  search(value: string){
    value = value.toLowerCase();

    if(value.length > 0){
      this.availableBooks = this.allBooks.filter((book)=>
        book.name.toLowerCase().includes(value) ||
        book.author.toLowerCase().includes(value) ||
        book.genre.toLowerCase().includes(value)
      );
    }
    else{
      this.availableBooks = [...this.allBooks];
    }
  }

  bookDetails(id:number){
    this.router.navigateByUrl("/bookDetails/" + id);
  }
}
