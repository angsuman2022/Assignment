import { Component,EventEmitter, Input, OnInit, Output } from '@angular/core';
import { BooksearchlistComponent } from '../booksearchlist/booksearchlist.component';
import {BookData} from '../models/bookdata';

@Component({
  selector: 'app-booklist',
  templateUrl: './booklist.component.html',
  styleUrls: ['./booklist.component.css']
})
export class BooklistComponent implements OnInit {
  
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
      };*/
      this.Booklist=new BookData();
  }
  
  @Input() Booklist:any;
  @Output() onRemoveBook:EventEmitter<any>=new EventEmitter<any>();
  @Output() onEditBook:EventEmitter<any>=new EventEmitter<any>();
  ngOnInit(): void {
    //console.log(this.Booklist);
  }

  deleteBooksClicked(){
    this.onRemoveBook.emit(this.Booklist.id);
  }
  editBooksClicked(){
    //console.log(this.Booklist);
    this.onEditBook.emit(this.Booklist);
  }



}
