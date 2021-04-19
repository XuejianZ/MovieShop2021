import { LoginComponent } from './auth/login/login.component';
import { CastsDetailsComponent } from './casts/casts-details/casts-details.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
import { RegisterComponent } from './auth/register/register.component';


const routes: Routes = 
[

    {path:"", component: HomeComponent},
    {path:"genre/movies/:id", component: MovieCardListComponent },
    {path: "movies/:id", component: MovieDetailsComponent },
    {path: "Movies/Cast/:id" , component:CastsDetailsComponent },
    {path:"login", component: LoginComponent},
    {path: "register", component: RegisterComponent},
    {path: "cast/:id" , component:CastsDetailsComponent}
   
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
