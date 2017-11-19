import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserEditorComponent } from './user-editor/user-editor.component';
import { TripEditorComponent } from './trip-editor/trip-editor.component';
import { TrainEditorComponent } from './train-editor/train-editor.component';
import { TicketEditorComponent } from './ticket-editor/ticket-editor.component';

import { ServerService } from '../app/services/server.service';

import { AppRoutingModule } from './app-routing.module';
import { TableComponent } from './table/table.component';
import { KeysPipe } from './pipes/keys.pipe';

@NgModule({
  declarations: [
    AppComponent,
    UserEditorComponent,
    TripEditorComponent,
    TrainEditorComponent,
    TicketEditorComponent,
    TableComponent,
    KeysPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [ ServerService ],
  bootstrap: [AppComponent]
})
export class AppModule { }
