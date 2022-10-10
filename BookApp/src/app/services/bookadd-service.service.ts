import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class BookaddServiceService {
  //_BookaddUrl="https://localhost:44395/api/BookAdd/Book-Add";
  //_BookDeleteUrl="https://localhost:44395/api/BookAdd/Book-Delete?id=";
 // _BookDetAllUrl="https://localhost:44395/api/BookAdd/Get-Books-All";
  //_BookeditUrl="https://localhost:44395/api/BookAdd/Book-Edit";
  //_Paymenturl="https://localhost:44395/api/Payment/Book-Payment";
 // _Cancelurl="https://localhost:44395/api/Payment/Book-Cancel";

  /* _BookaddUrl="https://localhost:44308/api/gateway/Book/BookAdd";
  _FileUploadUrl="https://localhost:44308/api/gateway/Book/Upload";
  _Cancelurl="https://localhost:44308/api/gateway/Cancel/BookCancel";
  _BookOrderUrl="https://localhost:44308/api/gateway/Book/GetBooksOrder?id=";
  _BookPayUrl="https://localhost:44308/api/gateway/Book/GetBooksPay?id=";
  _BookDeleteUrl="https://localhost:44308/api/gateway/Book/BookDelete?id=";
  _BookDetAllUrl="https://localhost:44308/api/gateway/Book/GetBookAll";
  _BookeditUrl="https://localhost:44308/api/gateway/Book/BookEdit";
  _Paymenturl="https://localhost:44308/api/gateway/Payment"; */

  //Azure call API

  _FileUploadUrl="https://localhost:44308/api/gateway/Book/Upload";
  _BookaddUrl="http://40.76.225.149/api/gateway/Book/BookAdd";
 // _FileUploadUrl="http://40.76.225.149/api/gateway/Book/Upload";
  _Cancelurl="http://40.76.225.149/api/gateway/Cancel/BookCancel";
  _BookOrderUrl="http://40.76.225.149/api/gateway/Book/GetBooksOrder?id=";
  _BookPayUrl="http://40.76.225.149/api/gateway/Book/GetBooksPay?id=";
  _BookDeleteUrl="http://40.76.225.149/api/gateway/Book/BookDelete?id=";
  _BookDetAllUrl="http://40.76.225.149/api/gateway/Book/GetBookAll";
  _BookeditUrl="http://40.76.225.149/api/gateway/Book/BookEdit";
  _Paymenturl="http://40.76.225.149/api/gateway/Payment";
  

  constructor(private http:HttpClient,private _router:Router) { }

  Bookadd(book:any)
  {
    return this.http.post<any>(this._BookaddUrl,book);
  }
  Bookedit(book:any)
  {

    return this.http.put<any>(this._BookeditUrl,book);
  }
  Bookdelete(id:any)
  {
    console.log(id);
    return this.http.delete<any>(this._BookDeleteUrl+id);
  }
  Upload(file:FormData)
  {
    
    return this.http.post<any>(this._FileUploadUrl,file);
  }

  GetBookDet()
  {
    return this.http.get(this._BookDetAllUrl)
  }

  getuserId()
  {
    return localStorage.getItem('userid');
  }

  BookPayment(book:any)
  {
    return this.http.post<any>(this._Paymenturl,book);
  }

  BookCancel(book:any)
  {
    return this.http.post<any>(this._Cancelurl,book);
  }

  getBookOrder(id:any)
  {
    console.log(id);
    return this.http.get(this._BookOrderUrl+id);
  }

  getBookPay(id:any)
  {
    console.log(id);
    return this.http.get(this._BookPayUrl+id);
  }
}
