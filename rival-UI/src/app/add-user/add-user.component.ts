import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';

@Component({
  selector: 'app-add-user',
  templateUrl: './add-user.component.html',
  styleUrls: ['./add-user.component.css']
})
export class AddUserComponent implements OnInit {
  @ViewChild('username') username: ElementRef;
  @ViewChild('password') password: ElementRef;
  notice: string;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.notice= "";
  }

  addUser(): void {    
    this.userService.putAddNewUser(this.username.nativeElement.value, this.password.nativeElement.value).subscribe(data => 
      {
        if(data==true)
        {
          this.router.navigateByUrl('/user');
        }
      } );
      this.notice = "Error, user not added, please try again";
 }
}
