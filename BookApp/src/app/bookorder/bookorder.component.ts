import { Component, OnInit } from '@angular/core';
import {OrderData} from '../models/orderdata';
import{Router} from '@angular/router';
import { BookaddServiceService } from '../services/bookadd-service.service';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-bookorder',
  templateUrl: './bookorder.component.html',
  styleUrls: ['./bookorder.component.css']
})
export class BookorderComponent implements OnInit {

  constructor(private _service:BookaddServiceService,private _router:Router,private http: HttpClient) { }
  OrderdataModel:OrderData=new OrderData();
  OrderdataModels:Array<OrderData>=new Array<OrderData>();
  Errormsg:any='';

  ngOnInit(): void {
     this.GetdataFromserver();

  }

  Success(input:any){
    
    this.OrderdataModels=input;
  }
  
  GetdataFromserver(){
    var user=this._service.getuserId();
   /*  this.http.get("https://localhost:44395/api/BookAdd/Get-Books-Order?id="+Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res)); */

    this._service.getBookOrder(Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res));
  }

  PostCancel(input:any){
    
    this.Errormsg=input.status;
  }

  CancelBook(input:any)
  {
    //console.log(input);
    //this.isEdit=true;
    debugger;
    this.OrderdataModel=input;
    this._service.BookCancel(this.OrderdataModel).subscribe(res=>this.PostCancel(res),res=>console.log(res));

    document.getElementById("btncancel")?.click();
  
  }

  DownloadInvoice(input:any)
  {
    //console.log(input);
    //this.isEdit=true;
    debugger;
    this.OrderdataModel=input;
    document.getElementById("btndownload")?.click();
  
  }

  SearchBooks(input:any)
  {
    let filteredBooks:OrderData[]=[];
    if(input=='')
    {
      this.GetdataFromserver();
    }
    else{
      filteredBooks=this.OrderdataModels.filter((val,index)=>{
        let tergetKey=val.bookTitle.toLocaleLowerCase();
        let searchkey=input.toLocaleLowerCase();
        return tergetKey.includes(searchkey);
      });
      this.OrderdataModels=filteredBooks;

    }
  }

}
