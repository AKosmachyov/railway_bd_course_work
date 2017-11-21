import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-table',
  templateUrl: './table.component.html',
  styleUrls: ['./table.component.css']
})
export class TableComponent {
  @Input() arr;
  @Output() onRemoveElement: EventEmitter<any> = new EventEmitter();
  @Output() onEditElement: EventEmitter<any> = new EventEmitter();
  headers: string[] = [];

  onEdit(el) {
    this.onEditElement.emit(el);
  }
  onRemove(el) {
    this.onRemoveElement.emit(el);
  }
}

