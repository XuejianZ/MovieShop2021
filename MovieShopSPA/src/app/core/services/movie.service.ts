import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { Injectable } from '@angular/core';
import { MoiveCard } from 'src/app/shared/models/movie-card';
import { MovieDetails } from 'src/app/shared/models/movie-details';


@Injectable({
  providedIn: 'root'
})


export class MovieService {


  constructor(private apiService: ApiService){}


  getTop30GrossingMovies():Observable<MoiveCard[]>{

    return this.apiService.getAll('movies/toprevenue');

  }


  getMovieDetails(id:number):Observable<MovieDetails>{

    return this.apiService.getOne('movies/',id);

  }

}
