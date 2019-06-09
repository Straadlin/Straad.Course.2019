import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../Models/UserModel';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  apiUrl;

  constructor(private http: HttpClient) { 

    this.apiUrl = environment.apiendpoint;
  }

  getUserName() {

    this.http.get(this.apiUrl + 'api/User/1')
    .subscribe(resp => {

      console.log(resp);
    });
  }

  getUsers() {

    return this.http.get(this.apiUrl + 'api/User/users');
  }

  addUser(user: User) {

    this.http.post(this.apiUrl + 'api/User/adduser', user)
    .subscribe(resp => {
      console.log(resp);
    });
  }

  postImage(img: File) {
    const formData = new FormData();
    formData.append('image', img);

    this.http.post(this.apiUrl + 'api/User/image', formData)
    .subscribe(resp => {
      console.log(resp);
    });
  }
}
