import { Component, OnInit } from '@angular/core';
import {UserData} from '../models/userdata';
import {LoginServiceService } from '../services/login-service.service';
import{Router} from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private _service:LoginServiceService,private _router:Router) { }
  UserdataModel:UserData=new UserData();
  Errormsg:any='';
  ngOnInit(): void {
  }
  loginUser()
  {
    var userdto = {
      email: this.UserdataModel.email,
      password: this.UserdataModel.password
      //fullName: this.UserdataModel.fullName,
      //phone:this.UserdataModel.phone,
      //type:this.UserdataModel.type
    };
    this._service.loginUser(userdto).subscribe(res=>{
     /*  console.log('Hi you are able to login');
      alert('Hi'); */
      localStorage.setItem('token',res.token);
      localStorage.setItem('userid',res.userid);
      localStorage.setItem('type',res.type);
      if(localStorage.getItem('type')=="Reader")
         this._router.navigate(['home']);
         else
         this._router.navigate(['bookadd/add']);

    }, res=>
    {
      console.log(res);
      this.Errormsg="Wrong email Id or Password";
      document.getElementById('btnerrormsg')?.click();


    }
  );
  }
  

}
