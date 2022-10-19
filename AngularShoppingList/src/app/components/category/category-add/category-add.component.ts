import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  Validators,
  FormGroup,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CategoryAddDto } from 'src/app/models/category/categoryAddDto';
import { CategoryService } from 'src/app/services/category/category.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-category-add',
  templateUrl: './category-add.component.html',
  styleUrls: ['./category-add.component.css'],
})
export class CategoryAddComponent implements OnInit {
  categoryAddForm: FormGroup;
  constructor(
    private categoryService: CategoryService,
    private formBuilder: FormBuilder,
    private router:Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.createCategoryAddForm();
  }

  add(categoryAddDto: CategoryAddDto) {
    this.categoryService.add(categoryAddDto).subscribe(
      (resposne) => {
        this.toastr.success('Kategori ekleme işlemi başarılı');
        this.router.navigate(["/category"])
      },
      (errorResponse) => {
        this.toastr.error('Kategori eklenemedi');
      }
    );
  }

  createCategoryAddForm() {
    this.categoryAddForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
    });
  }

  submit() {
    if (this.categoryAddForm.valid) {
      let addedCategoryModel = Object.assign({}, this.categoryAddForm.value)
      this.add(addedCategoryModel)
    } 
    else {
      this.toastr.warning(environment.formNotValid, "UYARI");
    }
  }
}
