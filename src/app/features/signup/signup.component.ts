import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import validateForm from '../../helpers/validateForm';
import { AuthService } from '../login/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrl: './signup.component.css'
})
export class SignupComponent implements OnInit{

  type: String = "password";

  isText: boolean = false;
  eyeIcon: string = "fa-eye-slash";
  signUpForm!: FormGroup;
  constructor(private fb: FormBuilder, private auth: AuthService, private router: Router) {}
  
  hideShowPass(){
      this.isText = !this.isText;
      this.isText ? this.eyeIcon = "fa-eye":this.eyeIcon= "fa-eye-slash";
      this.isText ? this.type = "text":this.type = "password";
  }


  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      username: ['',Validators.required],
      password: ['',Validators.required],
      firstname: ['',Validators.required],
      lastname: ['',Validators.required],
      email: ['',Validators.required]

    })
  }

  onSignUp(){
    if(this.signUpForm.valid){
      console.log(this.signUpForm.value);
      this.auth.signUp(this.signUpForm.value)
      .subscribe({
        next: (response) => {
          alert("SignUp Successfull")
          this.router.navigate(['/login']);

        },
        error: (err) =>{
          alert(err?.error.message)
        }
      })
    }else{
      validateForm.validateAllFormFields(this.signUpForm);
      alert("Your form is invalid");
    }
  }

  


}
