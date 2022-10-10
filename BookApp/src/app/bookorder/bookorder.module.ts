import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { BookorderComponent } from './bookorder.component';
import { bookorderroutes } from '../routing/bookorderroutes';
import {BookorderlistComponent} from '../bookorderlist/bookorderlist.component';

@NgModule({
  declarations: [
  
    BookorderComponent,
    BookorderlistComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(bookorderroutes)
  ],
  providers: [],
  bootstrap: [BookorderComponent]
})
export class BookOrderModule { }
