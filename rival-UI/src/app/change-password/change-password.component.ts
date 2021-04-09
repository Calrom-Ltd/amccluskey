import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { UserService } from '../user.service';

@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  @ViewChild('username') username: ElementRef;
  @ViewChild('oldPassword') oldPassword: ElementRef;
  @ViewChild('newPassword') newPassword: ElementRef;
  @ViewChild('newPasswordConfirmation') newPasswordConfirmation: ElementRef;
  
  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  ChangePassword(): void {    
    this.userService.getChangePassword(this.username.nativeElement.value, this.oldPassword.nativeElement.value, 
      this.newPassword.nativeElement.value, this.newPasswordConfirmation.nativeElement.value)
      .subscribe(_ => {});
 }
}
