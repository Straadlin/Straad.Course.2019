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

  constructor(private userService: UserService, private fb: FormBuilder) {
    
  }

  ngOnInit() {

    this.form = this.fb.group({
      Email: [''],
      FirstName: [''],
      LastName: ['']
    });
  }

  onSubmit(formValue: any) {

    const user = new User();
    user.Email = formValue.Email;
    user.FirstName = formValue.FirstName;
    user.LastName = formValue.LastName;
    this.userService.addUser(user);
  }
}
