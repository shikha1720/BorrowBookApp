import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-my-lent-books',
  templateUrl: './my-lent-books.component.html',
  styleUrls: ['./my-lent-books.component.css']
})
export class MyLentBooksComponent implements OnInit {

  listOfLentBooks: any[] =[];

  constructor(private api: ApiService){}
  ngOnInit(): void {
    let userid = this.api.getTokenUserInfo()?.id ?? 0;
    this.api.getLentBooks(userid).subscribe({
      next: (res:any) =>{
        console.log(res);
        this.listOfLentBooks = res;
      },
      error: (err:any) => console.log(err),
    });
  }

}
