import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { User } from '../../models/UserModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private userService: UserService) {

    const user = new User();
    user.Email = 'alfredo.estrada@straad.mx';
    user.FirstName = 'Alfredo';
    user.LastName = 'Estrada';

    this.userService.addUser(user);
  }

  ngOnInit() {
  }

}
