import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ShoppingListDetailDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Dto';
import { ShoppingListDetailService } from 'src/app/services/shoppingListDetail/shopping-list-detail.service';

@Component({
  selector: 'app-shopping-list-detail-update',
  templateUrl: './shopping-list-detail-update.component.html',
  styleUrls: ['./shopping-list-detail-update.component.css']
})
export class ShoppingListDetailUpdateComponent implements OnInit {

  shoppingListDetailUpdateForm:FormGroup
  selectedShoppingListDetail: ShoppingListDetailDto 
  constructor(private sListDetailService:ShoppingListDetailService, private formBuilder:FormBuilder, private router:Router, private activatedRoute:ActivatedRoute, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if (params['shoppingListDetailId']) {
        this.getShoppingListDetailById(params['shoppingListDetailId'])
      }
    })
    this.createShoppingListDetailAddForm()
  }

  createShoppingListDetailAddForm(){
    this.shoppingListDetailUpdateForm = this.formBuilder.group({
      description:[]
    })
  }

  getShoppingListDetailById(shoppingListDetailId:number){
    this.sListDetailService.getById(shoppingListDetailId).subscribe(response=>{
      this.selectedShoppingListDetail = response
    })
  }

  changeDescription(){
    let updatedModel = Object.assign({}, this.shoppingListDetailUpdateForm.value)
    updatedModel.id = this.selectedShoppingListDetail.shoppingListDetailId
    this.sListDetailService.changeDescriptionState(updatedModel).subscribe(response=>{
      this.toastr.success("Açıklama değiştirildi")
      this.toastr.info("Listelerinize yönlendiriliyorsunuz")
      this.router.navigate(['/shoppinglist'])
    })
    
  }

}
