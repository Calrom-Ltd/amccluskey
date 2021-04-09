import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { MessageComponent } from './message/message.component';
import { MessageDetailComponent } from './message-detail/message-detail.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    MessageComponent,
    MessageDetailComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    RouterModule.forRoot([
      {path: 'message', component: MessageComponent},
      {path: 'user', component: UserComponent},
      {path: 'messageDetail/:id', component: MessageDetailComponent}
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
