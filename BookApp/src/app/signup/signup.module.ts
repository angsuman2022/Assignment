import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {RouterModule} from '@angular/router'
import { SignupComponent } from './signup.component';
import { signuproutes  } from '../routing/signuproutes';


@NgModule({
  declarations: [ 
    SignupComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(signuproutes)
  ],
  providers: [],
  bootstrap: [SignupComponent]
})
export class SignupModule { }
