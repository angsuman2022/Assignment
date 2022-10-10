import {NgForm,FormGroup,Validators,FormBuilder,FormControl} from '@angular/forms'
export class UserData{
    email:string='';
    password:string='';
    fullName:string='';
    phone:string='';
    type:string='';
    formUserGroup:FormGroup;
    constructor(){
        var _builder=new FormBuilder();
        this.formUserGroup=_builder.group({});
        //this.formUserGroup.addControl("EmailControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("PasswordControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("FullNameControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("PhoneControl",new FormControl('',Validators.required));
        this.formUserGroup.addControl("typeControl",new FormControl('',Validators.required));

        var validationcollection=[];
        validationcollection.push(Validators.required);        
        validationcollection.push(Validators.pattern("[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}$"));
        this.formUserGroup.addControl("EmailControl",new FormControl('',Validators.compose(validationcollection)));
    }
}