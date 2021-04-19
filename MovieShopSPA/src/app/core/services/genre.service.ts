import { MoiveCard } from './../../shared/models/movie-card';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Genre } from 'src/app/shared/models/genre';
import { ApiService } from './api.service';


@Injectable({
  providedIn: 'root' 
})
export class GenreService {

  constructor(private apiService: ApiService) { }

  getAllGenres(): Observable<Genre[]>  {

    return this.apiService.getAll('genres');

  }

  getAllMovies(id:number):Observable<MoiveCard[]>{

    return this.apiService.getAllById('movies/genres/', id);

  }

  //this call genre API
  //https://localhost:44332/api/Genres
  // call the api to the base service....
  
}
