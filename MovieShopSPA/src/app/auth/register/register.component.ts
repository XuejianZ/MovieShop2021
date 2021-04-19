import { RegisterService } from './../../core/services/register.service';
import { Register } from './../../shared/models/register';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  invalidRegistarion=false

  userRegister: Register = {

    email: '', password: '',firstName:'', lastName:'', dateOfBirth: new Date(0)

  };

  constructor(private registerService: RegisterService,private router:Router) { }

  ngOnInit(): void {
  }


  register(){


    this.registerService.register(this.userRegister).subscribe(

      (response)=>{

        if(response){
          console.log(response);
          console.log('register successfully in home page!!!');
          this.router.navigate(['/login']);
         // this.router.navigate(['/login']);
         // this.router.navigate(['/login']);

        }
        
      },

      (error)=>{
        if(error){
          this.invalidRegistarion=true;
        }
      }    
         

    );

  }

}
