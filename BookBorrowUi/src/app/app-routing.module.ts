import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookLibraryComponent } from './components/book-library/book-library.component';
import { LoginComponent } from './components/login/login.component';
import { authenticationGuard } from './guards/authentication.guard';
import { DetailsComponent } from './components/book-details/details.component';
import { MyBorrowedBooksComponent } from './components/my-borrowed-books/my-borrowed-books.component';
import { MyLentBooksComponent } from './components/my-lent-books/my-lent-books.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { AddNewBookComponent } from './components/add-new-book/add-new-book.component';

const routes: Routes = [
  {
    path: 'books/library',
    component: BookLibraryComponent,
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'bookDetails/:id',
    component: DetailsComponent,
  },
  {
    path: 'myBorrowedBooks',
    component: MyBorrowedBooksComponent,
    canActivate:[authenticationGuard],
  },
  {
    path: 'myLentBooks',
    component: MyLentBooksComponent,
    canActivate:[authenticationGuard],
  },
  {
    path: 'addNewBook',
    component: AddNewBookComponent,
    canActivate:[authenticationGuard],
  },
  {
    path:'', 
    redirectTo:"/books/library", 
    pathMatch:'full'
  },
  { 
    path: '**', 
    component:PageNotFoundComponent
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
