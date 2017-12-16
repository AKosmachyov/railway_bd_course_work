import { Component, OnInit } from '@angular/core';

import { Trip } from '../classes/trip';

@Component({
  selector: 'app-trip-editor',
  templateUrl: './trip-editor.component.html',
  styleUrls: ['./trip-editor.component.css']
})
export class TripEditorComponent implements OnInit {
  currentTrip: Trip = new Trip();

  constructor() { }

  ngOnInit() {
  }

}
