import { Component, OnInit } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { Book } from '../../models/model';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css'],
})
export class DetailsComponent implements OnInit {
  public id: any;
  public book: any;
  public userId : any;
  token! : number;

  constructor(protected api: ApiService, 
              private route: ActivatedRoute,
              private router: Router,
              private toast: NgToastService) {}

  ngOnInit(): void {
    this.id = this.route.snapshot.paramMap.get('id');
    this.userId = this.api.getTokenUserInfo()?.id ?? 0;
    this.api.getToken(this.userId).subscribe({
      next: (res: any) => {
        this.token = res;
      }})
    //console.log(this.id);

    this.api.getBookById(this.id).subscribe({
      next: (res: any) => {
        this.book = res;
        console.log(this.book);
      },
      error: (err: any) => console.log(err),
    });
  }

  borrowBook(book: Book) {
    if (confirm('Do You Want to Borrow "' + book.name + '" Book')) {
      let userid = this.api.getTokenUserInfo()?.id ?? 0;
      if (this.token > 0) {
        this.api.borrowBook(userid, book.id).subscribe({
          next: (res: any) => {
            if (res === 'success') {
              book.isBookAvailable = false;
              this.toast.success({detail:"SUCCESS",summary:'Book Borrowed Successfully!',duration:1500});
              this.router.navigateByUrl("/books/library");
              setTimeout(function() {
                window.location.reload();
            },1600);
            }
          },
          error: (err: any) => console.log(err),
        });
      }
      else{
        this.toast.warning({detail:"WARNING",summary:'Tokens Not Available',duration:5000});
      }
    }
  }

  returnBook(book: Book) {
    if(confirm('Do You Want to Return "' + book.name + '" Book')){
      let userid = this.api.getTokenUserInfo()?.id ?? 0;
      this.api.returnBook(userid, book.id).subscribe({
        next: (res: any) => {
          if(res === 'success'){
            book.isBookAvailable = true;
            this.toast.success({detail:"SUCCESS",summary:'Book Returned Successfully!',duration:1500});
              this.router.navigateByUrl("/books/library");
              setTimeout(function() {
                window.location.reload();
            },1700);
          }
        },
        error: (err:any) => console.log(err),
      })
    }
  }
}
