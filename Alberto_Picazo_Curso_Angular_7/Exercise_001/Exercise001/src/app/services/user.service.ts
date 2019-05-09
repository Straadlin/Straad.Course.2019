import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../Models/UserModel';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUserName() {

    this.http.get('http://localhost:53368/api/User/1')
    .subscribe(resp => {

      console.log(resp);
    });
  }

  addUser(user: User) {

    const data = new User();
    data.FirstName = user.FirstName;
    data.LastName = user.LastName;
    data.Email = user.Email;
    this.http.post('http://localhost:53368/api/User/adduser', data)
    .subscribe(resp => {
      console.log(resp);
    });
  }
}
