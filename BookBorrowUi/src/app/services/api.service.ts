import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Book, User } from '../models/model';

@Injectable({
  providedIn: 'root'
})
export class ApiService {

  baseUrl = 'https://localhost:7164/api/';
  constructor(private http: HttpClient,
              private jwt: JwtHelperService,) { }

  login(loginInfo: any){
    let params = new HttpParams()
    .append('username', loginInfo.username)
    .append('password', loginInfo.password);
    return this.http.get(this.baseUrl + 'User/Login' , {
      params: params,
      responseType: 'text',
    });
  }

  saveToken(token: string){
    localStorage.setItem('access_token', token);
  }

  isLoggedIn(): boolean{
    return !!localStorage.getItem('access_token');
  }

  deleteToken() {
    localStorage.removeItem('access_token');
   // location.reload();
  }

  getTokenUserInfo(): User | null {
    if(!this.isLoggedIn())return null;
    let token = this.jwt.decodeToken();
    let user : User ={
      id: token.id,
      name: token.name,
      username: token.username,
      tokenAvailable: token.tokenAvailable,
      password: '',
    };
    return user;
  }

  getAllBooks(){
    return this.http.get<Book[]>(this.baseUrl + 'Book/GetAllBooks');
  }

  getBookById(id:number){
    return this.http.get<Book>(this.baseUrl + ('Book/GetBookById/' + id ));
    //console.log(this.baseUrl + ('Books/GetBookById/' + id ));
  }

  borrowBook(userId: number, bookId: number){
    return this.http.get(this.baseUrl + 'BookBorrow/' + userId + '/' + bookId, {
      responseType: 'text',
    });
  }

  getBorrowedBooks(userId: number){
    return this.http.get<any>(this.baseUrl + 'BookBorrow/GetBorrowedBooks/' + userId);
  }

  getLentBooks(userId: number){
    return this.http.get<Book[]>(this.baseUrl + 'Book/GetLentBooks/' + userId);
  }

  returnBook(userId: number, bookId: number){
    return this.http.get(this.baseUrl + 'Book/ReturnBook/' + userId + '/' + bookId,{
      responseType: 'text',
    });
  }

  addBook(book: Book,userId:number){
    console.log(book, userId);
    console.log(book.lentByUserId, typeof book.lentByUserId)
    return this.http.post(this.baseUrl + 'Book/NewBook/' + userId, book, {
      responseType:'text',
    });
  }

  getToken(userId:number){
    //console.log(this.http.get(this.baseUrl + 'User/Tokens/' + userId));
    return this.http.get(this.baseUrl + 'User/Tokens/' + userId);
  }

}
