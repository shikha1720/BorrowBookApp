import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { ApiService } from '../../services/api.service';
import { NgToastService } from 'ng-angular-popup';
import { Router } from '@angular/router';

@Component({
  selector: 'app-page-header',
  templateUrl: './page-header.component.html',
  styleUrls: ['./page-header.component.css']
})
export class PageHeaderComponent implements OnInit {

  @Output() menuClicked = new EventEmitter<boolean>();
  userId = this.api.getTokenUserInfo()?.id ?? 0;
  tokenAvailable! : number;

  constructor(protected api: ApiService,
              private toast: NgToastService,
              private router: Router){}
  ngOnInit(): void {
    this.api.getToken(this.userId).subscribe({
      next: (res: any) => {
        this.tokenAvailable = res;
      }
    });
  }

  logOut(){
    this.router.navigateByUrl("/books/library");
    this.api.deleteToken();  
    // this.toast.success({detail:"SUCCESS",summary:'Logged Out Successfully!',duration:1500});
  }

}
