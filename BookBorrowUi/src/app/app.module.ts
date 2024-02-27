import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { PageHeaderComponent } from './components/page-header/page-header.component';
import { PageFooterComponent } from './components/page-footer/page-footer.component';
import {MaterialModule} from './material/material.module';
import { SideNavComponent } from './components/side-nav/side-nav.component';
import { BookLibraryComponent } from './components/book-library/book-library.component';
import { LoginComponent } from './components/login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { DetailsComponent } from './components/book-details/details.component';
import { MyBorrowedBooksComponent } from './components/my-borrowed-books/my-borrowed-books.component';
import { MyLentBooksComponent } from './components/my-lent-books/my-lent-books.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { AddNewBookComponent } from './components/add-new-book/add-new-book.component';
import { NgToastModule } from 'ng-angular-popup';

@NgModule({
  declarations: [
    AppComponent,
    PageHeaderComponent,
    PageFooterComponent,
    SideNavComponent,
    BookLibraryComponent,
    LoginComponent,
    DetailsComponent,
    MyBorrowedBooksComponent,
    MyLentBooksComponent,
    PageNotFoundComponent,
    AddNewBookComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgToastModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: () => {
          return localStorage.getItem('access_token');
        },
        allowedDomains: ['localhost:7164'],
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
