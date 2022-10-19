import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { ShoppingListAddDto } from 'src/app/models/shoppingList/shopping-List-Add-Dto';
import { ShoppingListService } from 'src/app/services/shoppingList/shopping-list.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-shopping-list-add',
  templateUrl: './shopping-list-add.component.html',
  styleUrls: ['./shopping-list-add.component.css'],
})
export class ShoppingListAddComponent implements OnInit {
  shoppingListAddForm: FormGroup;

  loggedUserId: number = this.setLoggedUserId();
  constructor(
    private sListSerive: ShoppingListService,
    private router: Router,
    private formBuilder: FormBuilder,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.createShoppingListAddForm();
  }

  createShoppingListAddForm() {
    this.shoppingListAddForm = this.formBuilder.group({
      userId: [this.loggedUserId, Validators.required],
      name: ['', [Validators.required, Validators.minLength(2)]],
    });
  }

  setLoggedUserId() {
    const jwtHelper = new JwtHelperService();
    const rawToken: any = localStorage.getItem('token');
    const decodedToken = jwtHelper.decodeToken(rawToken);
    return decodedToken.id;
  }

  add(shoppingListAddDto: ShoppingListAddDto) {
    this.sListSerive.add(shoppingListAddDto).subscribe(
      (response) => {
        this.toastr.success('Alışveriş listesi oluşturuldu');
        this.router.navigate(['shoppingList']);
      },
      (errorResponse) => {
        this.toastr.error('Aynı isimde iki tane liste olamaz');
      }
    );
  }

  submit() {
    if (this.shoppingListAddForm.valid) {
      const addeddModel = Object.assign({}, this.shoppingListAddForm.value);
      this.add(addeddModel);
    } else {
      this.toastr.warning(environment.formNotValid, "UYARI");
    }
  }
}
