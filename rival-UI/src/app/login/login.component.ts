import { Component, Input, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UserService } from '../user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild('username') username: ElementRef;
  @ViewChild('password') password: ElementRef;

  constructor(private userService: UserService, private router: Router) { }
  status: any;
  notice: string;

  ngOnInit(): void {
    this.notice= "";
  }

  Login(): void {    
    this.userService.postUser(this.username.nativeElement.value, this.password.nativeElement.value).subscribe(data => 
      {
        if(data==true)
        {
          this.router.navigateByUrl('/user');
        }
      } );
      this.notice = "Error, please try again";
 }
}

