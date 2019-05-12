import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { User } from 'src/app/Models/UserModel';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  form: FormGroup;
  flag = false;
  users: any[] = [];

  constructor(private userService: UserService, private fb: FormBuilder) {

  }

  ngOnInit() {

    this.form = this.fb.group({
      Email: [''],
      FirstName: [''],
      LastName: [''],
      Date: ['']
    });
  }

  onSubmit(formValue: any) {

    const user = new User();
    user.Email = formValue.Email;
    user.FirstName = formValue.FirstName;
    user.LastName = formValue.LastName;
    user.Date = new Date(formValue.Date.year, formValue.Date.month, formValue.Date.day);
    this.userService.addUser(user);
    this.flag = !this.flag;
    this.userService.getUsers()
      .subscribe((resp: any) => {
        this.users = resp;
        // console.log(resp);
      });
  }
}
