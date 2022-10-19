import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProductDto } from 'src/app/models/product/productDto';
import { ShoppingListDetailAddDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Add-Dto';
import { ProductService } from 'src/app/services/product/product.service';
import { ShoppingListDetailService } from 'src/app/services/shoppingListDetail/shopping-list-detail.service';

@Component({
  selector: 'app-shopping-list-detail-add',
  templateUrl: './shopping-list-detail-add.component.html',
  styleUrls: ['./shopping-list-detail-add.component.css']
})
export class ShoppingListDetailAddComponent implements OnInit {

  selectedProduct: ProductDto
  selectedShoppingListId: number
  shoppingListDetailAddForm: FormGroup
  constructor(private sListDetailService:ShoppingListDetailService, private productService:ProductService, private formBuilder:FormBuilder, private activatedRoute:ActivatedRoute, private router:Router, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if (params['productId']) {
        this.getByProductById(params['productId'])
      }
      if (params['shoppingListId']) {
        this.selectedShoppingListId = params['shoppingListId']
      }
    })
    this.createShoppingListDetailAddForm()
  }

  createShoppingListDetailAddForm(){
    this.shoppingListDetailAddForm = this.formBuilder.group({
      description:[]
    })
  }

  getByProductById(productId:number){
    this.productService.getById(productId).subscribe(response=>{
      this.selectedProduct = response
    })
  }
  
  addShoppingListDetail(){
    let addedModel : ShoppingListDetailAddDto = Object.assign({}, this.shoppingListDetailAddForm.value)
    addedModel.IsBought = false
    addedModel.productId = this.selectedProduct.id
    addedModel.shoppingListId = this.selectedShoppingListId
    this.sListDetailService.add(addedModel).subscribe(response=>{
     this.toastr.success("Ürün listenize eklendi")
    },errorResponse=>{
     this.toastr.error("Ürün listeye eklenemedi")
      
    })
  }

  
}
