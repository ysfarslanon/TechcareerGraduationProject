import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { ProductDeleteDto } from 'src/app/models/product/productDeleteDto';
import { ProductDto } from 'src/app/models/product/productDto';
import { CategoryService } from 'src/app/services/category/category.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  filterText:string = ''
  products:ProductDto[]
  categories: CategoryDto[]
  selectedCategoryId: number = 0 // sıfır bütün kategorilerdir
  constructor(private productService:ProductService, private categoryService:CategoryService, private activatedRoute:ActivatedRoute, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getAllCategory()
    this.activatedRoute.params.subscribe(params=>{
      if (params['categoryId']) {
        this.getAllByCategoryId(params['categoryId'])
        this.selectedCategoryId = Number(params['categoryId'])
      } else {
        this.getAll()        
      }
    })
    
  }
  getAll(){
    this.productService.getAll().subscribe(response=>{
      this.products = response
    })
  }

  getAllByCategoryId(categoryId:number){
    this.productService.getAllByCategoryId(categoryId).subscribe(response=>{
      this.products = response
    })
  }

  delete(productId:number){
    let deletedProduct:ProductDeleteDto= {id:productId}
    this.productService.delete(deletedProduct).subscribe(response=>{
      this.ngOnInit()
      this.toastr.success("Ürün silindi")
    },errorResponse=>{
      
    })
  }

  getAllCategory(){
    this.categoryService.getAll().subscribe(response=>{
      this.categories = response
    })
  }

  changeURL(){
    if(this.selectedCategoryId != 0){
      return '/products/category/' + this.selectedCategoryId
    }
    return '/products'
  }

}
