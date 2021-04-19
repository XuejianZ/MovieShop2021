import { AuthenticationService } from './../../services/authentication.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/shared/models/user';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {


  isAuthenticated: boolean | undefined;
  currentUser: User | undefined;

  Logout:boolean=false;


  constructor(private authService :AuthenticationService ) { }

  ngOnInit(): void {


    this.authService.populateUserInfo();


    this.authService.isAuthenticated.subscribe(
      auth => {
        this.isAuthenticated= auth;
        console.log('Auth Status: ' + this.isAuthenticated)
      }
    )
       

       this.authService.currentUser.subscribe(

        user =>{
          this.currentUser=user;
          console.table('User Data: ' + this.currentUser);
          console.log(JSON.stringify(this.currentUser));
        }
       )
     
  }

  
  logout(){
    this.authService.logout();
  }

}
