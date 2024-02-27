import { Component, OnInit } from '@angular/core';
import { SideNavItem } from '../../models/model';
import { ApiService } from '../../services/api.service';

@Component({
  selector: 'app-side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.css']
})
export class SideNavComponent implements OnInit {

  userId = this.api.getTokenUserInfo()?.id ?? 0;
  tokenAvailable! : number;

  constructor(protected api: ApiService){}
  ngOnInit(): void {
    this.api.getToken(this.userId).subscribe({
      next: (res: any) => {
        console.log(res);
        this.tokenAvailable = res;
      }
    })
  }

  sideNavContent: SideNavItem[] = [
    {
      title: 'view books',
      link: 'books/library',
    },
    {
      title: 'add new book',
      link: 'addNewBook',
    },
    {
      title: 'my borrowed books',
      link: 'myBorrowedBooks',
    },
    {
      title: 'my lent books',
      link: 'myLentBooks',
    },
  ]
}
