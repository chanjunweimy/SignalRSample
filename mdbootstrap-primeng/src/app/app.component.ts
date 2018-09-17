import { Component, OnInit } from '@angular/core';
import { MessageService } from 'primeng/api';
import * as signalR from '@aspnet/signalr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit  {
  title = 'mdbootstrap-starter';

  constructor(private messageService: MessageService) {
  }

  ngOnInit(): void {
    const connection = new signalR.HubConnectionBuilder()
    .withUrl('https://localhost:5001/notify')
    .build();

    connection.start().catch(err => document.write(err));

    connection.on('BroadcastMessage', (type: string, payload: string) => {
        this.messageService.add({severity: type, summary: payload });
    });
  }
}
