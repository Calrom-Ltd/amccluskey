import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { UserComponent } from './user/user.component';
import { MessageComponent } from './message/message.component';
import { MessageDetailComponent } from './message-detail/message-detail.component';
import { LoginComponent } from './login/login.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { AddUserComponent } from './add-user/add-user.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    MessageComponent,
    MessageDetailComponent,
    LoginComponent,
    ChangePasswordComponent,
    AddUserComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    RouterModule.forRoot([
      {path: 'login', component: LoginComponent},
      {path: 'message', component: MessageComponent},
      {path: 'user', component: UserComponent},
      {path: 'addUser', component: AddUserComponent},
      {path: 'changePassword', component: ChangePasswordComponent},
      {path: 'messageDetail/:id', component: MessageDetailComponent}
    ]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
