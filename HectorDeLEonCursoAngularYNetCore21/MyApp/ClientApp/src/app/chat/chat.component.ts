import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'chat-app',
  templateUrl: './chat.component.html'
})
export class ChatComponent {
  public lstMessages: Message[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log("Entra");
    http.get<Message[]>(baseUrl + "api/Chat/Message").subscribe(result => {
      this.lstMessages = result;
    }, error => console.error(error));
  }
}

interface Message {
  Id: number,
  Name: string,
  Message: string;
}
