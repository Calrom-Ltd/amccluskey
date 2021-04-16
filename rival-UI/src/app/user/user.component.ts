import { Component, OnInit } from '@angular/core';
import { UserService } from '../user.service';
import { User } from '../user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  users: User[]=[];
  constructor(private UserService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.getUsers();
  }

  getUsers(): void {
    this.UserService.getUsers()
      .subscribe(users => this.users = users);
  }

  addUser(): void {
    this.router.navigateByUrl('/addUser');
  }
}
