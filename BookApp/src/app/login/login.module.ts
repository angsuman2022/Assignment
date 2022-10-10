import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { LoginComponent } from './login.component';
import { loginroutes  } from '../routing/loginroutes';


@NgModule({
  declarations: [
  
    LoginComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(loginroutes)
  ],
  providers: [],
  bootstrap: [LoginComponent]
})
export class LoginModule { }
