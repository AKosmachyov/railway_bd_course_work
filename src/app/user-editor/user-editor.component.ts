import { Component, OnInit } from '@angular/core';

import { ServerService } from '../services/server.service';

import { User } from '../classes/user';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})
export class UserEditorComponent implements OnInit {
  currentUser: User = new User();
  arr: [User];

  constructor(private serverService: ServerService) { }

  ngOnInit() {
    this.serverService.getUsers()
      .then((res: any) => {
        this.arr = res;
      });
  }

  addObject() {
   const savedUser = Object.assign({}, this.currentUser);
   delete this.currentUser.idUser;
   this.serverService.addObject('user', this.currentUser)
     .then((id: number) => {
     savedUser.idUser = '' + id;
       this.arr.push(savedUser);
       this.currentUser = new User();
     }).catch((err) => {
     console.error(err);
   });
  }
}
