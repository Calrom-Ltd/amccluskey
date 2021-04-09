import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MessageService } from '../message.service';
import { Message } from '../message';

@Component({
  selector: 'app-message-detail',
  templateUrl: './message-detail.component.html',
  styleUrls: ['./message-detail.component.css']
})
export class MessageDetailComponent implements OnInit {
  message: Message;

  constructor(private route: ActivatedRoute, private MessageService: MessageService) { }

  ngOnInit(): void {
    this.getMessage();
  }
  getMessage(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.MessageService.getMessage(id)
      .subscribe(message => this.message = message);
  }

}
