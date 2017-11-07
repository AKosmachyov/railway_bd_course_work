import { Component, OnInit } from '@angular/core';

import { Ticket } from '../classes/ticket';

@Component({
  selector: 'app-ticket-editor',
  templateUrl: './ticket-editor.component.html',
  styleUrls: ['./ticket-editor.component.css']
})
export class TicketEditorComponent implements OnInit {
  ticket: Ticket = new Ticket();

  constructor() { }

  ngOnInit() {
  }

}
