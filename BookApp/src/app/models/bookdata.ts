//import {NgForm,FormGroup,Validators,FormBuilder,FormControl} from '@angular/forms'
export class BookData{
    id?:number=0;
    bookTitle:string='';
    bookCategory:string='';
    bookImg:string='';
    bookPrice:number=0;
    bookPublish:string='';
    active:boolean=false;
    bookContent:string='';
    createBy:number=0;
    publishDate:string='';
    /*formBookGroup:FormGroup;
    constructor(){
        var _builder=new FormBuilder();
        this.formBookGroup=_builder.group({});
        //this.formUserGroup.addControl("EmailControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("TitleControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("CategoryControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("PriceControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("PublishControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("activeControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("ContentControl",new FormControl('',Validators.required));
        this.formBookGroup.addControl("publishDateControl",new FormControl('',Validators.required));

        var validationcollection=[];
        validationcollection.push(Validators.required);        
        validationcollection.push(Validators.pattern("^[+]?\\d+(\.\\d+)?$"));
        this.formBookGroup.addControl("PriceControl",new FormControl('',Validators.compose(validationcollection)));
    } */
}