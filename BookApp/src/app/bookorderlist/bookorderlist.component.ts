import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';
//import { BooksearchlistComponent } from '../booksearchlist/booksearchlist.component';
import {OrderData} from '../models/orderdata';

@Component({
  selector: 'app-bookorderlist',
  templateUrl: './bookorderlist.component.html',
  styleUrls: ['./bookorderlist.component.css']
})
export class BookorderlistComponent implements OnInit {

  constructor() { }
  @Input() Orderlist:any;
  @Output() onCancelBook:EventEmitter<any>=new EventEmitter<any>();
  @Output() onDownloadBook:EventEmitter<any>=new EventEmitter<any>();
  ngOnInit(): void {
  }

  CancelBooksClicked(){
    //console.log(this.Booklist);
    this.onCancelBook.emit(this.Orderlist);
  }

  DownloadBooksClicked(){
    //console.log(this.Booklist);
    this.onDownloadBook.emit(this.Orderlist);
  }

}
