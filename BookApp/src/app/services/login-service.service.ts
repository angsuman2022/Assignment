import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { Router } from '@angular/router';


@Injectable({
  providedIn: 'root'
})
export class LoginServiceService {
 // _loginUrl="https://localhost:44395/api/User/login-user";
  //_registerUrl="https://localhost:44395/api/User/register-user";

  /* _loginUrl="https://localhost:44308/api/gateway/User/login";
  _registerUrl="https://localhost:44308/api/gateway/User/register"; */
  
  _loginUrl="http://40.76.225.149/api/gateway/User/login";
  _registerUrl="http://40.76.225.149/api/gateway/User/register";

  constructor(private http:HttpClient,private _router:Router) { }
  loginUser(login:any)
  {
    return this.http.post<any>(this._loginUrl,login);
  }
  registerUser(register:any)
  {
    return this.http.post<any>(this._registerUrl,register);
  }
  getToken()
  {
    return localStorage.getItem('token');
  }
  logingIn(){
    return !!localStorage.getItem('token');
  }
  logotUser()
  {
    localStorage.removeItem('token');
    localStorage.removeItem('type');
    localStorage.removeItem('userid');
    this._router.navigate(['']);
  }

  /*logingInReder(){
    //return !!localStorage.getItem('token');
    if(localStorage.getItem('token')!=null && localStorage.getItem('type')=="Reader")
    {
      return true;
    }
  }*/
}
