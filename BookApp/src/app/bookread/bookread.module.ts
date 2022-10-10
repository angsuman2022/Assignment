import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { BookreadComponent } from './bookread.component';
import { bookreadroutes } from '../routing/bookreadroutes';
import {BookpaylistComponent} from '../bookpaylist/bookpaylist.component';

@NgModule({
  declarations: [
  
    BookreadComponent,
   BookpaylistComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(bookreadroutes)
  ],
  providers: [],
  bootstrap: [BookreadComponent]
})
export class BookReadModule { }
