import { NgModule } from '@angular/core';
import {CommonModule} from '@angular/common';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router'
import { BookaddComponent } from './bookadd.component';
import { bookaddroutes } from '../routing/bookaddroutes';
import {BooklistComponent} from '../booklist/booklist.component';

@NgModule({
  declarations: [
  
    BookaddComponent,
    BooklistComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(bookaddroutes)
  ],
  providers: [],
  bootstrap: [BookaddComponent]
})
export class BookAddModule { }
