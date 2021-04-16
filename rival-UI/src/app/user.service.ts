import { User } from './user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private messageUrl = 'api/User/';
  constructor(private http: HttpClient) { }

    httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    /** POST user */
    postUser(username: string, password: string): Observable<any> {
      return this.http.post<any>(this.messageUrl+"Login",{username, password}, this.httpOptions)
    }

    /** GET user */
    getUsers(): Observable<User[]> {
      return this.http.get<User[]>(this.messageUrl+"DisplayUsers")
    }

    /** POST change password */
    postChangePassword(username: string, oldPassword: string, newPassword: string, newPasswordConfirmation: string): Observable<boolean> {
      return this.http.post<boolean>(this.messageUrl+"ChangePassword", {username, oldPassword, newPassword, newPasswordConfirmation}, this.httpOptions)
    }

    /** PUT add new user */
    putAddNewUser(username: string, password: string): Observable<boolean> {
      return this.http.put<boolean>(this.messageUrl+"AddNewUser"
      ,{username,password}, this.httpOptions);
    }
}

