import { Component, OnInit } from '@angular/core';
import {BookData} from '../models/bookdata';
import {PaymentData} from '../models/paymentdata';
import { BookaddServiceService } from '../services/bookadd-service.service';
import{Router} from '@angular/router';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private _service:BookaddServiceService,private _router:Router) { }
  BookdataModel:BookData=new BookData();
  BookdataModels:Array<BookData>=new Array<BookData>();
  PaymentdataModel:PaymentData=new PaymentData();
  Errormsg:any='';
  
  ngOnInit(): void {
    this.GetdataFromserver();
  }

  Success(input:any){
  
    this.BookdataModels=input;
  }
  
  GetdataFromserver(){
    var user=this._service.getuserId();
    
    this._service.GetBookDet().subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res));
  }

   PaymentBook(input:any)
  {
    var user=this._service.getuserId();
    if(user==null)
    {
      alert("Login Needed");
      this._router.navigate(['login']);
      return;
    }
    this.BookdataModel=input;
    this.PaymentdataModel=new PaymentData();
    document.getElementById("btnPayment")?.click();
  
  }

  BookPayment()
  {
    
    /*if(this.BookdataModel.bookTitle=="")
    {
      alert("Please enter Book Title");
      return;
    }

    if(this.BookdataModel.bookCategory=="")
    {
      alert("Please enter Book Category");
      return;
    }
    if(this.BookdataModel.bookPrice==0)
    {
      alert("Please enter Book Price");
      return;
    }
    if(this.BookdataModel.bookPublish=="")
    {
      alert("Please enter Book Publishers");
      return;
    }
    if(this.BookdataModel.publishDate=="")
    {
      alert("Please enter Book Publish Date");
      return;
    }

    if(this.BookdataModel.bookContent=="")
    {
      alert("Please eneter Book Content");
      return;
    }

    if(this.BookdataModel.active==false && this.isEdit==false)
    {
      alert("Please Select Active");
      return;
    }

    this.BookdataModel.bookImg=this._ImgPath;
    if(this.BookdataModel.bookImg=="" && this.isEdit==false)
    {
      alert("Please Select Image");
      return;
    } */
    
    var user=this._service.getuserId();
    if(user!=null)
    {
      this.PaymentdataModel.paymentBy=Number(user);
    }
    this.PaymentdataModel.bookId=Number(this.BookdataModel.id);
    console.log(this.PaymentdataModel);
    this._service.BookPayment(this.PaymentdataModel).subscribe(res=>
      {
        console.log(res);
        this.Errormsg=res.status;
        document.getElementById("btnpaymentcon")?.click();

      },res=>console.log(res));
    
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
