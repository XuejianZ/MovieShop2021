import { CastCard } from './../../shared/models/cast-card';
import { ActivatedRoute } from '@angular/router';
import { CastService } from './../../core/services/cast.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-casts-details',
  templateUrl: './casts-details.component.html',
  styleUrls: ['./casts-details.component.css']
})
export class CastsDetailsComponent implements OnInit {


  cast : CastCard | undefined;

  constructor(private castService: CastService, private _route:ActivatedRoute) { }

  ngOnInit(): void {

    const id = +this._route.snapshot.params['id'];
    this.castService.getCastDetails(id).subscribe(

      c => {
          this.cast = c;
      }

    )

  }

}
