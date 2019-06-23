import { Component } from '@angular/core';

@Component({
  selector: 'chat-app',
  templateUrl: './chat.component.html'
})
export class ChatComponent {
  public lstMessage: string[] = ["Hello world", "I love Amanda", "I don't wanna cray her."];
}
