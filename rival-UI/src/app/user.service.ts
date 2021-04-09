import { User } from './user';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private messageUrl = 'api/User/';
  constructor(private http: HttpClient) { }

    /** POST user */
    postUser(username: string, password: string): Observable<boolean> {
      return this.http.post<boolean>(this.messageUrl+"Login",{username, password})
    }

    /** GET user */
    getUsers(): Observable<User[]> {
      return this.http.get<User[]>(this.messageUrl+"DisplayUsers")
    }

    /** GET change password */
    getChangePassword(username: string, password: string, newPassword: string, newPasswordConfirm: string): Observable<boolean> {
      return this.http.get<boolean>(this.messageUrl+"ChangePassword?username="
      +username+"&oldPassword="+password+"&newPassword="+newPassword+"&newPasswordConfirmation="+newPasswordConfirm)
    }

    /** PUT change password */
    putAddNewUser(username: string, password: string): Observable<boolean> {
      return this.http.put<boolean>(this.messageUrl+"AddNewUser",{username,password})
    }
}

