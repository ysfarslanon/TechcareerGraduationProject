import { Component, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { ProductAddDto } from 'src/app/models/product/productAddDto';
import { CategoryService } from 'src/app/services/category/category.service';
import { ProductService } from 'src/app/services/product/product.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html',
  styleUrls: ['./product-add.component.css'],
})
export class ProductAddComponent implements OnInit {
  productAddForm: FormGroup;
  categories: CategoryDto[] = [];
  selectedCategoryId: number = 0;
  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private formBuilder: FormBuilder,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.createProductAddForm();
    this.getAllCategories();
  }


  createProductAddForm() {
    this.productAddForm = this.formBuilder.group({
      name: ['', [Validators.required, Validators.minLength(2)]],
      categoryId: ['', Validators.required],
      pictureURL: ['', [Validators.required, Validators.minLength(2)]],
    });
  }

  getAllCategories() {
    this.categoryService.getAll().subscribe((response) => {
      this.categories = response;
    });
  }

  add(productAddDto: ProductAddDto) {
    this.productService.add(productAddDto).subscribe(
      (response) => {
        this.toastr.success('Ürün ekleme başarılı.');
        
      },
      (errorResponse) => {
        this.toastr.error('Aynı isimde ürün olamaz.');
        
      }
    );
  }

  submit() {
    if (this.productAddForm.valid) {
      let productAddModel = Object.assign({}, this.productAddForm.value);
      this.productService.add(productAddModel)
    } else {
      this.toastr.warning(environment.formNotValid, "UYARI");
      
    }
  }
}
