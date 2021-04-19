import { Component, Input, OnInit } from '@angular/core';
import { MoiveCard } from '../../models/movie-card';

@Component({
  selector: 'app-movie-card',
  templateUrl: './movie-card.component.html',
  styleUrls: ['./movie-card.component.css']
})
export class MovieCardComponent implements OnInit {


@Input() movie: MoiveCard | undefined;
  constructor() { }

  ngOnInit(): void {

    
  }

}
