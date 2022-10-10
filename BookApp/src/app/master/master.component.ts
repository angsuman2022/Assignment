import { Component, OnInit } from '@angular/core';
import {LoginServiceService } from '../services/login-service.service';

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit {

  constructor(private _auth:LoginServiceService) { }

  ngOnInit(): void {
  }
  LoggedIn(Input:boolean):boolean{
    if(Input)
    {
      //console.log(this._auth.logingIn());
      return this._auth.logingIn();
      
    }
    else{
      //console.log(this._auth.logingIn());
      return !this._auth.logingIn();
    }
  }
  Logout(){
    this._auth.logotUser();
  }

  LoggedRedIn():boolean{
        if(localStorage.getItem('type')=="Reader")
        {
          return true;
        }
        else
        {
          return false;
        }   
  }

  LoggedAuthIn():boolean{    
    if(localStorage.getItem('type')=="Author")
    {
      return true;
    }
    else
    {
      return false;
    }   
}

}
