import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UserEditorComponent } from './user-editor/user-editor.component';
import { TicketEditorComponent } from './ticket-editor/ticket-editor.component';
import { TrainEditorComponent } from './train-editor/train-editor.component';
import { TripEditorComponent } from './trip-editor/trip-editor.component';

const appRoutes: Routes = [
  {
    path: 'users',
    component: UserEditorComponent
  },
  {
    path: 'tickets',
    component: TicketEditorComponent
  },
  {
    path: 'trains',
    component: TrainEditorComponent
  },
  {
    path: 'trips',
    component: TripEditorComponent
  },
  { path: '**', redirectTo: '/users', pathMatch: 'full' },
];

@NgModule({
  imports: [ RouterModule.forRoot(appRoutes) ],
  exports: [ RouterModule ]
})

export class AppRoutingModule { }
