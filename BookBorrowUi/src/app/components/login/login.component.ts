import { Component } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../services/api.service';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  hide = true;
  loginForm: FormGroup;
  responseMsg: string = '';

  constructor(private fb: FormBuilder,
              private api: ApiService,
              private router: Router,
              private toast: NgToastService ){
    this.loginForm = fb.group({
      username: fb.control('',[Validators.required]),
      password:fb.control('',[Validators.required,Validators.minLength(8),Validators.maxLength(15)]),
    });
  }

  login(){
    let loginInfo = {
      username: this.loginForm.get('username')?.value,
      password: this.loginForm.get('password')?.value,
    };

    this.api.login(loginInfo).subscribe({
      next: (res: any) => {
        console.log(res.toString());
        if(res.toString() == 'Invalid'){
          this.responseMsg = 'Invalid Credentials!';
        }
        else{
          this.responseMsg = '';
          this.api.saveToken(res.toString());
          this.toast.success({detail:"SUCCESS",summary:'Loged In Succesfully!',duration:1500});
          this.router.navigateByUrl("/books/library");
          setTimeout(function() {
            window.location.reload();
        },1600);
        }
      },
      error: (err:any)=>{
        console.log('Error: ');
        console.log(err);
      },
    });
  }

  getUsernameErrors(){
    if(this.getUsername().hasError('required'))return 'User Name required';
    return '';
  }

  getPasswordErrors(){
    if(this.getPassword().hasError('required'))return 'Password is required';
    if(this.getPassword().hasError('minlength'))return 'Minimum 8 characters are required';
    if(this.getPassword().hasError('maxlength'))return 'Maximum 15 characters are required';
    return '';
  }

  getUsername(): FormControl {
    return this.loginForm.get('username') as FormControl;
  }

  getPassword(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }
}
