import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';
import {BookData} from '../models/bookdata';

@Component({
  selector: 'app-booksearchlist',
  templateUrl: './booksearchlist.component.html',
  styleUrls: ['./booksearchlist.component.css']
})
export class BooksearchlistComponent implements OnInit {

  constructor() { 
    /*this.Booklist={
      bookTitle:'',
      bookCategory:'',
      bookImg:'',
      bookPrice:0,
      bookPublish:'',
      active:false,
      bookContent:'',
      createBy:0, 
      publishDate:''
      }; */
      this.Booklist=new BookData();
    
  }
  @Input() Booklist:BookData;
  @Output() onPaymentBook:EventEmitter<any>=new EventEmitter<any>();
  ngOnInit(): void {
  }

  paymentBooksClicked(){
    //console.log(this.Booklist);
    this.onPaymentBook.emit(this.Booklist);
  }

}
