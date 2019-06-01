import { Component, OnInit } from '@angular/core';
import { UserService } from '../../services/user.service';
import { FormControl, FormGroup, FormBuilder, FormArray } from '@angular/forms';
import { User } from 'src/app/Models/UserModel';
import { ToastrService } from 'ngx-toastr';
import { LoadingScreenService } from '../../services/loading-screen.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  form: FormGroup;
  flag = false;
  users: any[] = [];

  constructor(private userService: UserService, private fb: FormBuilder,
              private toastr: ToastrService,
              private screenService: LoadingScreenService) {

  }

  ngOnInit() {

    this.form = this.fb.group({
      Email: [''],
      FirstName: [''],
      LastName: [''],
      Date: [''],
      Telephones: this.fb.array([this.fb.group({Telephone: ['']})])
    });
  }

  showSuccess() {
    this.toastr.success('Hello world!', 'Toastr fun!');
    this.toastr.error('Hello world!', 'Toastr ERROR!');
    this.toastr.warning('Hello world!', 'Toastr Warning!');
    this.toastr.info('Hello world!', 'Toastr Info!');
  }

  onSubmit(formValue: any) {

    // this.screenService.startLoading();
    const user = new User();
    user.Email = formValue.Email;
    user.FirstName = formValue.FirstName;
    user.LastName = formValue.LastName;
    user.Date = new Date(formValue.Date.year, formValue.Date.month, formValue.Date.day);
    user.Telephones = formValue.Telephones;

    this.userService.addUser(user);

    this.flag = !this.flag;

    this.userService.getUsers()
      .subscribe((resp: any) => {
        this.users = resp;
        // this.screenService.hideLoading();
        // console.log(resp);
      });
    this.showSuccess();
  }

  get getTelephones() {

    return this.form.get('Telephones') as FormArray;
  }

  addTelephone() {

    const control = <FormArray>this.form.controls['Telephones'];
    control.push(this.fb.group({Telephone: []}));
  }

  removeTelephone(index: number) {

    const control = <FormArray>this.form.controls['Telephones'];
    control.removeAt(index);
  }
}
