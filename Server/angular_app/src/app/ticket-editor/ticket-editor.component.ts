import { Component, OnInit } from '@angular/core';

import { ServerService } from '../services/server.service';

import { Ticket } from '../classes/ticket';

@Component({
  selector: 'app-ticket-editor',
  templateUrl: './ticket-editor.component.html',
  styleUrls: ['./ticket-editor.component.css']
})
export class TicketEditorComponent implements OnInit {
  ticket: Ticket = new Ticket();
  arr: [Ticket];
  TABLE_NAME = 'ticket';

  constructor(private serverService: ServerService) { }

  ngOnInit() {
    this.serverService.getTableValues(this.TABLE_NAME)
      .then((res: any) => {
        this.arr = res;
      });
  }

}
