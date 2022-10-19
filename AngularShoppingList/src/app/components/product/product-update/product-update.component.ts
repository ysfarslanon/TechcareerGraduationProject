import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoggedGuard } from 'src/app/guards/logged/logged.guard';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { ProductDto } from 'src/app/models/product/productDto';
import { ProductUpdateDto } from 'src/app/models/product/productUpdateDto';
import { CategoryService } from 'src/app/services/category/category.service';
import { ProductService } from 'src/app/services/product/product.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.css'],
})
export class ProductUpdateComponent implements OnInit {
  productUpdateForm: FormGroup;
  categories: CategoryDto[];
  selectedProduct:ProductDto

  constructor(
    private productService: ProductService,
    private categoryService: CategoryService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private toastr:ToastrService
  ) {}

  ngOnInit(): void {
    this.createProductUpdateForm()
    this.getAllCategories();
    this.activatedRoute.params.subscribe(params=>{
      if (params['productId']) {
        this.getById(params['productId'])
      }
    })
  }

  submit() {
    if (this.productUpdateForm.valid) {
        let productUpdateModel = Object.assign({}, this.productUpdateForm.value)
        productUpdateModel.id = this.selectedProduct.id
        this.update(productUpdateModel)
        this.router.navigate(['/products'])
      } else {
        this.toastr.warning(environment.formNotValid, "UYARI")
      
    }
  }

  update(productUpdateDto: ProductUpdateDto){
    this.productService.update(productUpdateDto).subscribe(response=>{
      this.toastr.success("Ürün güncelleme başarılı")
      
    }, errorResponse=>{
      this.toastr.error("Ürün güncelleme başarısız")      
    })
  }

  getAllCategories(){
    this.categoryService.getAll().subscribe(response=>{
      this.categories = response
    })
  }

  createProductUpdateForm(){
    this.productUpdateForm = this.formBuilder.group({
      name:['', [Validators.required, Validators.minLength(2)]],
      categoryId:['', Validators.required],
      pictureURL:['', [Validators.required, Validators.minLength(2)]]

    })
  }

  getById(id:number){
    this.productService.getById(id).subscribe(response=>{
      this.selectedProduct = response
    })
  }
}
