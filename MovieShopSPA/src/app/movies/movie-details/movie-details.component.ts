
import { CastCard } from './../../shared/models/cast-card';
import { MoiveCard } from 'src/app/shared/models/movie-card';
import { GenreService } from './../../core/services/genre.service';
import { Component, Input, OnInit } from '@angular/core';
import { MovieService } from 'src/app/core/services/movie.service';
import { ActivatedRoute, ActivatedRouteSnapshot } from '@angular/router';
import { identity } from 'rxjs';
import { map } from 'rxjs/operators';
import { MovieDetails } from 'src/app/shared/models/movie-details';
import { HttpParams } from '@angular/common/http';

@Component({
  selector: 'app-movie-details',
  templateUrl: './movie-details.component.html',
  styleUrls: ['./movie-details.component.css']
})



export class MovieDetailsComponent implements OnInit {


  movie: MovieDetails | undefined;
  

  constructor(private movieService: MovieService, private _route: ActivatedRoute) { }

  id: number| undefined;


  ngOnInit() {

    this._route.paramMap.subscribe(

        params =>{
          this.id = +params.getAll('id');
        //  this.id = Number(params.get('id')); this also works

          this.movieService.getMovieDetails(this.id).subscribe(
            m=>{
              this.movie = m;
            }
          )
        }
    )

/* this one is not recommend, because it does do subscirbre
     const id = +this._route.snapshot.params['id'];
     this.movieService.getMovieDetails(id).subscribe(

       g=>{
          this.movie=g;
       }

     );

 */ 
}

}


