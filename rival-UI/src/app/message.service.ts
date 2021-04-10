import { Message } from './message';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MessageService {
  private messageUrl = 'api/Message/';
  
  constructor(private http: HttpClient) { }

  /** GET single message */
  getMessage(id: number): Observable<Message> {
    return this.http.get<Message>(this.messageUrl+"GetMessageById?id="+id)
  }

  /* GET multiple messages */
  getMessages():Observable<Message[]> {
    return this.http.get<Message[]>(this.messageUrl+"GetMessages")
  }
}
