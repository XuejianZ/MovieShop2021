import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { FooterComponent } from './core/layout/footer/footer.component';
import { GenresComponent } from './genres/genres.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {HttpClientModule} from '@angular/common/http';
import { MovieCardComponent } from './shared/components/movie-card/movie-card.component';
import { MovieCardListComponent } from './movies/movie-card-list/movie-card-list.component';
import { CastCardComponent } from './shared/components/cast-card/cast-card.component';
import { MovieDetailsComponent } from './movies/movie-details/movie-details.component';
import { CastsDetailsComponent } from './casts/casts-details/casts-details.component';
import { LoginComponent } from './auth/login/login.component';
import { RegisterComponent } from './auth/register/register.component';
import {FormsModule,ReactiveFormsModule} from '@angular/forms';
import { RegisterConfrimComponent } from './auth/register-confrim/register-confrim.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    HeaderComponent,
    FooterComponent,
    GenresComponent,
    MovieCardComponent,
    MovieCardListComponent,
    CastCardComponent,
    MovieDetailsComponent,
    CastsDetailsComponent,
    LoginComponent,
    RegisterComponent,
    RegisterConfrimComponent
  ],

  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],

  providers: [],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
