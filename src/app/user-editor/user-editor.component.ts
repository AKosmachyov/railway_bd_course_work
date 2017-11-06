import { Component, OnInit } from '@angular/core';

import { User } from '../classes/user';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})
export class UserEditorComponent implements OnInit {
  currentUser: User = new User();

  constructor() { }

  ngOnInit() {
  }

}
