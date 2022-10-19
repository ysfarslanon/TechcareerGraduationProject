import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { ProductDto } from 'src/app/models/product/productDto';
import { CategoryService } from 'src/app/services/category/category.service';
import { ProductService } from 'src/app/services/product/product.service';

@Component({
  selector: 'app-shopping-list-detail-list',
  templateUrl: './shopping-list-detail-list.component.html',
  styleUrls: ['./shopping-list-detail-list.component.css'],
})
export class ShoppingListDetailListComponent implements OnInit {
  filterText: string = '';
  selectedCategoryId: number = 0;
  selectedShoppingListId: number = 0
  categories:CategoryDto[]
  products: ProductDto[]
  constructor(private categoryService:CategoryService, private productService:ProductService, private activatedRoute:ActivatedRoute) {}

  ngOnInit(): void {
    this.getAllCategories()
    this.activatedRoute.params.subscribe(params=>{

      if (params['shoppingListId']){
        this.selectedShoppingListId = params['shoppingListId']
      }

      if (params['categoryId']) {
        this.getAllProductsByCategoryId(params['categoryId'])
      } else {
        this.getAllProducts()        
      }
    })

   
   
  }

  changeURL(){
    if(this.selectedCategoryId != 0){
        return "/shoppinglistdetail/"+this.selectedShoppingListId+"/products/category/"+this.selectedCategoryId
    }
    return "/shoppinglistdetail/" + this.selectedShoppingListId
  }

  getAllCategories(){
    this.categoryService.getAll().subscribe(response=>{
      this.categories = response
    })
  }

  getAllProducts(){
    this.productService.getAll().subscribe(response=>{
      this.products = response
    })
  }
  
  getAllProductsByCategoryId(categoryId:number){
    this.productService.getAllByCategoryId(categoryId).subscribe(response=>{
      this.products = response
    })
  }
}
