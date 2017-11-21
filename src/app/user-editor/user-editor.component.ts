import { Component, OnInit } from '@angular/core';

import { ServerService } from '../services/server.service';

import { User } from '../classes/user';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})
export class UserEditorComponent implements OnInit {
  TABLE_NAME = 'user';
  currentUser: User = new User();

  isUpdate: Boolean = false;
  updatedUser: User;

  arr: [User];

  constructor(private serverService: ServerService) { }

  ngOnInit() {
    this.serverService.getTableValues(this.TABLE_NAME)
      .then((res: any) => {
        this.arr = res;
      });
  }

  addObject() {
   const savedUser = Object.assign({}, this.currentUser);
   delete this.currentUser.idUser;
   this.serverService.addObject(this.TABLE_NAME, this.currentUser)
     .then((id: number) => {
     savedUser.idUser = '' + id;
       this.arr.push(savedUser);
       this.currentUser = new User();
     }).catch((err) => {
     console.error(err);
   });
  }

  setUpdateObject(user: User) {
    console.log(user);
    this.currentUser.LastName = user.LastName;
    this.updatedUser = user;
    this.isUpdate = true;
    // this.currentUser.LastName = user.LastName;
    // this.serverService.updateObject(this.TABLE_NAME, user, user);
  }

  updateObject() {
    this.isUpdate = false;
    console.log(this.currentUser);
  }

  removeObject(user: User) {
    this.serverService.removeObject(this.TABLE_NAME, user)
      .then(() => {
        const i = this.arr.indexOf(user);
        this.arr.splice(i, 1);
      });
  }
}
