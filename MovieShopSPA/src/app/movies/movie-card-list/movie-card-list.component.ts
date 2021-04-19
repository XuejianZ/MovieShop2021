import { MoiveCard } from './../../shared/models/movie-card';
import { GenreService } from './../../core/services/genre.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-movie-card-list',
  templateUrl: './movie-card-list.component.html',
  styleUrls: ['./movie-card-list.component.css']
})
export class MovieCardListComponent implements OnInit {

  movie: MoiveCard[] | undefined;

  constructor(private genreService: GenreService, private _route: ActivatedRoute) { }
 

  ngOnInit(): void {

      const id = +this._route.snapshot.params['id'];
      this.genreService.getAllMovies(id).subscribe(

        g=>{
          this.movie =g;
        }
      )
  }

}
