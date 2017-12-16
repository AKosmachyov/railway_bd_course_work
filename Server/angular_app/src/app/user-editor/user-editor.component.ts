import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

import { ServerService } from '../services/server.service';

import { User } from '../classes/user';

@Component({
  selector: 'app-user-editor',
  templateUrl: './user-editor.component.html',
  styleUrls: ['./user-editor.component.css']
})
export class UserEditorComponent implements OnInit {
  @ViewChild('userForm') userForm: NgForm;
  TABLE_NAME = 'user';
  currentUser: User = new User();

  isUpdate: Boolean = false;
  savedUser: User;

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

  setUpdateObject(user) {
    this.savedUser = user;
    this.currentUser = Object.assign({}, user);
    this.isUpdate = true;
  }

  updateObject() {
    if(!confirm('Вы уверены?'))
      return;
    this.isUpdate = false;
    const i = this.arr.indexOf(this.savedUser);
    this.serverService.updateObject(this.TABLE_NAME, this.savedUser, this.currentUser)
      .then(() => {
        this.arr.splice(i , 1, Object.assign({}, this.currentUser));
        this.userForm.reset();
      });
  }

  removeObject(user: User) {
    if(!confirm('Вы уверены?'))
      return;

    this.serverService.removeObject(this.TABLE_NAME, user)
      .then(() => {
        const i = this.arr.indexOf(user);
        this.arr.splice(i, 1);
      });
  }
}
