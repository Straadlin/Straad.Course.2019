import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

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
}
