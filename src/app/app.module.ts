import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserEditorComponent } from './user-editor/user-editor.component';
import { TripEditorComponent } from './trip-editor/trip-editor.component';
import { TrainEditorComponent } from './train-editor/train-editor.component';
import { TicketEditorComponent } from './ticket-editor/ticket-editor.component';

@NgModule({
  declarations: [
    AppComponent,
    UserEditorComponent,
    TripEditorComponent,
    TrainEditorComponent,
    TicketEditorComponent
  ],
  imports: [
    BrowserModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
