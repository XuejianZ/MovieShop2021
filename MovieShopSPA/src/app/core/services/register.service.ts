import { ApiService } from './api.service';
import { Observable } from 'rxjs';
import { Register } from './../../shared/models/register';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  constructor(private apiService:ApiService) { }


  register( userRegister:Register):Observable<boolean>{


    return this.apiService.create('account/register', userRegister).pipe(map(response=>{


        if(response){

          console.log('registered successfully')
          return true;

        }
        else{

          console.log('registered failed')
          return false;
        }

    }));

  }
}
