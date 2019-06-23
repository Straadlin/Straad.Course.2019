import { Component } from '@angular/core';

@Component({
  selector: 'chat-app',
  templateUrl: './chat.component.html'
})
export class ChatComponent {
  public name = "Alfredo Estrada"

  public ChangeName() {
    this.name = "Straad"
  }
}
