import { Component, OnInit } from '@angular/core';

import { Train } from '../classes/train';

@Component({
  selector: 'app-train-editor',
  templateUrl: './train-editor.component.html',
  styleUrls: ['./train-editor.component.css']
})
export class TrainEditorComponent implements OnInit {
  train: Train = new Train();

  constructor() { }

  ngOnInit() {
  }

}
