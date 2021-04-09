import { Component, Input, OnInit, ViewChild, ElementRef } from '@angular/core';
import { User } from '../user';
import { UserService } from '../user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  @ViewChild('username') username: ElementRef;
  @ViewChild('password') password: ElementRef;

  constructor(private userService: UserService) { }
  status: boolean;

  ngOnInit(): void {
  }

  Login(): void {    
    this.userService.postUser(this.username.nativeElement.value, this.password.nativeElement.value).subscribe(data => this.status = data);
 }
}

