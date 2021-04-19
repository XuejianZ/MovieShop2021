import { CastCard } from './../../models/cast-card';
import { Component, OnInit, Input } from '@angular/core';


@Component({
  selector: 'app-cast-card',
  templateUrl: './cast-card.component.html',
  styleUrls: ['./cast-card.component.css']
})


export class CastCardComponent implements OnInit {

@Input() cast: CastCard | undefined

  constructor() { }

  ngOnInit(): void {
  }

}
