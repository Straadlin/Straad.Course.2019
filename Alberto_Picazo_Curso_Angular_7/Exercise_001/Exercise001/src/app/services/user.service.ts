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

  getUsers() {

    return this.http.get('http://localhost:53368/api/User/users');
  }

  addUser(user: User) {

    this.http.post('http://localhost:53368/api/User/adduser', user)
    .subscribe(resp => {
      console.log(resp);
    });
  }
}
