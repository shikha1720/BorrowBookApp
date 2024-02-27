import { Component, OnInit } from '@angular/core';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'BookBorrowUi';

  constructor(protected toast: NgToastService) {}
  ngOnInit(): void {
  }

  checkToast(){
    return true;
  }
}
