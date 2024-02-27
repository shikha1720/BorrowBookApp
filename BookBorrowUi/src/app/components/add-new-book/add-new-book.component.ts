import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-add-new-book',
  templateUrl: './add-new-book.component.html',
  styleUrls: ['./add-new-book.component.css']
})
export class AddNewBookComponent {

  addBookForm: FormGroup;
  userId = this.api.getTokenUserInfo()?.id ?? 0;
 // msg: string = '';

  constructor(private fb: FormBuilder, private api: ApiService, private router:Router, private toast: NgToastService){
    this.addBookForm = fb.group({
      name: fb.control("",[Validators.required]),
      rating: fb.control('', [Validators.required,Validators.min(1),Validators.max(5)]),
      author: fb.control('',[Validators.required]),
      genre: fb.control('',[Validators.required]),
      description: fb.control('',[Validators.required]),
      isBookAvailable: fb.control(true,[Validators.nullValidator]),
      lentByUserId: fb.control(Number(this.userId),[Validators.nullValidator]),
      currentlyBorrowedByUserId: fb.control(0,[Validators.nullValidator])
    })
  }

  addBook(){
    this.api.addBook(this.addBookForm.value, this.userId).subscribe({
      next: (res:any)=> {
        //this.msg = 'Book Lent';
        console.log(this.addBookForm.value);
        this.toast.success({detail:"SUCCESS",summary:'Book Lent Successfully!',duration:1500});
        this.router.navigateByUrl("/myLentBooks");
        setTimeout(function() {
          window.location.reload();
        },1700);
        
      },
      error: (err:any) => console.log(err),
    })
  }

  get Name(): FormControl {
    return this.addBookForm.get('name') as FormControl;
  }
  get Rating(): FormControl {
    return this.addBookForm.get('rating') as FormControl;
  }
  get Author(): FormControl {
    return this.addBookForm.get('author') as FormControl;
  }
  get Genre(): FormControl {
    return this.addBookForm.get('genre') as FormControl;
  }
  get Description(): FormControl {
    return this.addBookForm.get('description') as FormControl;
  }

}
