import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import validateForm from '../../helpers/validateForm';
import { AuthService } from './services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent implements OnInit {

  type: String = "password";

  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";

  loginForm!: FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService, private router:Router) {}
  hideShowPass(){
      this.isText = !this.isText;
      this.isText ? this.eyeIcon = "fa-eye":this.eyeIcon= "fa-eye-slash";
      this.isText ? this.type = "text":this.type = "password";
  }



  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['',Validators.required],
      password: ['',Validators.required]
    })
  }

  onLogin(){
    if(this.loginForm.valid){
      console.log(this.loginForm.value);
      this.auth.login(this.loginForm.value)
      .subscribe({
        next: (response) =>{
          alert(response.message);
          this.router.navigate(['/lists/cities']);

        },
        error: (er) =>{
          alert(er?.error.message);
        }
      })
    }else{
      validateForm.validateAllFormFields(this.loginForm);
      alert("Your form is invalid");
    }
  }

}
