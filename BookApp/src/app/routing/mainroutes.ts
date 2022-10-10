import { HomeComponent } from "../home/home.component";
import { LoginComponent } from "../login/login.component";
import { SignupComponent } from "../signup/signup.component";
export const Mainroutes=[
{path:'',component: HomeComponent},
{path:'login',component:LoginComponent},
{path:'signup',component:SignupComponent},
{path:'booksearch',loadChildren:()=>import('../booksearch/booksearch.module').then(m=>m.BookSearchModule)},
{path:'bookadd',loadChildren:()=>import('../bookadd/bookadd.module').then(m=>m.BookAddModule)},
{path:'bookread',loadChildren:()=>import('../bookread/bookread.module').then(m=>m.BookReadModule)},
{path:'bookorder',loadChildren:()=>import('../bookorder/bookorder.module').then(m=>m.BookOrderModule)},
{path:'home',component: HomeComponent}

];
