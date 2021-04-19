import { CastCard } from './../../shared/models/cast-card';
import { Observable } from 'rxjs';
import { ApiService } from './api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CastService {


  constructor(private apiService : ApiService) {} 
  
  getCastDetails(id: number):Observable<CastCard>{

        return this.apiService.getOne('movies/cast/', id);

  }




  


}
