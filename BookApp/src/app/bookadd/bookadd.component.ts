import { Component, OnInit } from '@angular/core';
import {BookData} from '../models/bookdata';
import{Router} from '@angular/router';
import { BookaddServiceService } from '../services/bookadd-service.service';
import { HttpClient } from '@angular/common/http';


@Component({
  selector: 'app-bookadd',
  templateUrl: './bookadd.component.html',
  styleUrls: ['./bookadd.component.css']
})
export class BookaddComponent implements OnInit {

  constructor(private _service:BookaddServiceService,private _router:Router,private http: HttpClient) { }
  BookdataModel:BookData=new BookData();
  BookdataModels:Array<BookData>=new Array<BookData>();
  _ImgPath:string='';
  ngOnInit(): void {
    this.GetdataFromserver();
  }
  Success(input:any){
    
    this.BookdataModels=input;
  }
  
  GetdataFromserver(){
    var user=this._service.getuserId();
    /* this.http.get("https://localhost:44395/api/BookAdd/Get-Books?id="+Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res)); */

    /* this.http.get("https://localhost:44308/api/gateway/Book/GetBooks?id="+Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res)); */
    this.http.get("http://40.76.225.149/api/gateway/Book/GetBooks?id="+Number(user)).subscribe(res=>{
      this.Success(res);
      console.log(res);
    },res=>console.log(res));
  }
  uploadFile(files:any){
    if(files.length==0){
      return ;
    }
    
    let fileToUpload=<File>files[0];
    const formData=new FormData();
    formData.append('file',fileToUpload,fileToUpload.name);
    this._service.Upload(formData).subscribe(res=>{
      console.log(res);
      this._ImgPath=res.imgPath;
    },res=>console.log(res)); 
   /* this.http.post('https://localhost:44395/api/BookAdd/Upload',formData).subscribe(res=>{
     console.log(res);
     //this._ImgPath=res.Success;     
    },res=>console.log(res)); */
  }
  BookAdd()
  {
    
    if(this.BookdataModel.bookTitle=="")
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
    }
    var user=this._service.getuserId();
    if(user!=null)
    {
      this.BookdataModel.createBy=Number(user);
    }
    //console.log(this.BookdataModel);
    if(this.isEdit)
    {
      this._service.Bookedit(this.BookdataModel).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
    }
    else{
        this._service.Bookadd(this.BookdataModel).subscribe(res=>{
          console.log(res);     
          this.PostSuccess(res);
        },res=>console.log(res)); 
  }
  }

  removeBook(input:any)
  {
    //console.log(input);
    this._service.Bookdelete(input).subscribe(res=>this.PostSuccess(res),res=>console.log(res));
  }
  PostSuccess(input:any)
  {
    this.GetdataFromserver();
  }
  isEdit=false;
  editBook(input:any)
  {
    //console.log(input);
    this.isEdit=true;
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
