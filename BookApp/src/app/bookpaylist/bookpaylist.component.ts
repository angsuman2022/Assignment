import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';
//import { BooksearchlistComponent } from '../booksearchlist/booksearchlist.component';
import {BookData} from '../models/bookdata';

@Component({
  selector: 'app-bookpaylist',
  templateUrl: './bookpaylist.component.html',
  styleUrls: ['./bookpaylist.component.css']
})
export class BookpaylistComponent implements OnInit {

  constructor() { 
    this.Booklist=new BookData();
  }
  @Input() Booklist:any;
  @Output() onReadBook:EventEmitter<any>=new EventEmitter<any>();
  ngOnInit(): void {
  }

  ReadBooksClicked(){
    //console.log(this.Booklist);
    this.onReadBook.emit(this.Booklist);
  }

}
