import { Component, OnInit } from '@angular/core';

import { ServerService } from '../services/server.service';

import { Train } from '../classes/train';

@Component({
  selector: 'app-train-editor',
  templateUrl: './train-editor.component.html',
  styleUrls: ['./train-editor.component.css']
})
export class TrainEditorComponent implements OnInit {
  train: Train = new Train();
  TABLE_NAME = 'train';
  arr: [Train];

  constructor(private serverService: ServerService) { }

  ngOnInit() {
    this.serverService.getTableValues(this.TABLE_NAME)
      .then((res: any) => {
        this.arr = res;
      });
  }

}
