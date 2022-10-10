import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { HomeComponent } from './home.component';
import{MasterComponent} from '../master/master.component'
import { Mainroutes } from '../routing/mainroutes';
import {LoginComponent } from '../login/login.component';
import {SignupComponent} from '../signup/signup.component';
import {LoginServiceService} from '../services/login-service.service';
import{HttpClientModule} from '@angular/common/http';
import{BooksearchlistComponent} from '../booksearchlist/booksearchlist.component'


@NgModule({
  declarations: [
    HomeComponent,
    MasterComponent,
    LoginComponent,
    SignupComponent,
    BooksearchlistComponent
    
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot(Mainroutes),
    HttpClientModule
  ],
  providers: [LoginServiceService],
  bootstrap: [MasterComponent]
})
export class MasterModule { }