import { Component, OnInit } from '@angular/core';
import {BookData} from '../models/bookdata';
import{Router} from '@angular/router';
import { BookaddServiceService } from '../services/bookadd-service.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bookread',
  templateUrl: './bookread.component.html',
  styleUrls: ['./bookread.component.css']
})
export class BookreadComponent implements OnInit {

  constructor(private _service:BookaddServiceService,private _router:Router,private http: HttpClient) { }
  BookdataModel:BookData=new BookData();
  BookdataModels:Array<BookData>=new Array<BookData>();
  ngOnInit(): void {
    this.GetdataFromserver();
  }

  GetdataFromserver(){
    var user=this._service.getuserId();
    /* this.http.get("https://localhost:44395/api/BookAdd/Get-Books-Pay?id="+Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res)); */
    this._service.getBookPay(Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res));
  }
  Success(input:any){
    
    this.BookdataModels=input;
  }

   ReadBook(input:any)
  {
    //console.log(input);
    //this.isEdit=true;
    this.BookdataModel=input;
    document.getElementById("AddBookDet")?.click();
  
  }

  SearchBooks(input:any)
  {
    let filteredBooks:BookData[]=[];
    if(input=='')
    {
      this.GetdataFromserver();
    }
    else{
      filteredBooks=this.BookdataModels.filter((val,index)=>{
        let tergetKey=val.bookTitle.toLocaleLowerCase();
        let searchkey=input.toLocaleLowerCase();
        return tergetKey.includes(searchkey);
      });
      this.BookdataModels=filteredBooks;

    }
  }


}
