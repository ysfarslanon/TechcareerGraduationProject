import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { ShoppingListChangeIsShoppingDto } from 'src/app/models/shoppingList/shopping-List-Change-Is-Shopping-Dto';
import { ShoppingListDeleteDto } from 'src/app/models/shoppingList/shopping-List-Delete-Dto';
import { ShoppingListDto } from 'src/app/models/shoppingList/shopping-List-Dto';
import { ShoppingListDetailChangeIsBoughtDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Change-Is-Bought-Dto';
import { ShoppingListDetailDeleteDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Delete-Dto';
import { ShoppingListService } from 'src/app/services/shoppingList/shopping-list.service';
import { ShoppingListDetailService } from 'src/app/services/shoppingListDetail/shopping-list-detail.service';

@Component({
  selector: 'app-shopping-list-list',
  templateUrl: './shopping-list-list.component.html',
  styleUrls: ['./shopping-list-list.component.css']
})
export class ShoppingListListComponent implements OnInit {

  loggedUserId:number = Number(this.decodedToken().id)
  userShoppingLists: ShoppingListDto[]
  constructor(private sListService: ShoppingListService, private sListDetailService: ShoppingListDetailService, private router:Router, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getAllByUserId(this.loggedUserId)

  }


  decodedToken(): any{
    const jwtHelper = new JwtHelperService
    const rawToken: string | undefined | any =
    localStorage.getItem('token');
    const decodeToken: any = jwtHelper.decodeToken(rawToken);

    return decodeToken
  }

  changeIsShoppingState(listId:number, state:boolean){
    const model: ShoppingListChangeIsShoppingDto = {
      id: listId,
      isShopping: state
    }
    
    this.sListService.changeIsShoppingState(model).subscribe(response=>{
        this.ngOnInit()
        if (state) this.toastr.error("Ürünlere müdahele edilemez")
        if (!state) this.toastr.success("Ürünlere müdahele edilebilir")
     })
  }

  changeIsBoughtState(sListDetailId:number, state:boolean){
    const model: ShoppingListDetailChangeIsBoughtDto = {
      id:sListDetailId,
      isBought: !state
    }

    this.sListDetailService.changeIsBoughtState(model).subscribe(response=>{
      this.ngOnInit()
    })
  }

  getAllByUserId(userId:number){
    this.sListService.getAllByUserId(userId).subscribe(response=>{
      this.userShoppingLists = response
      
    })
  }

  deleteDetail(detailId:number){
    const deleteModel : ShoppingListDetailDeleteDto = {
        id : detailId
    }
    this.sListDetailService.delete(deleteModel).subscribe(response=>{
      this.ngOnInit()
      this.toastr.success("Ürün silme işlemi yapıldı")
    })
  }

  delete(id:number){
    const deleteModel : ShoppingListDeleteDto = {
      id : id
    }
    this.sListService.delete(deleteModel).subscribe(response=>{
      this.ngOnInit()
      this.toastr.success("Liste silindi")
    })
  }

 
   style(condition:boolean){
    if (condition) {
      return 'text-decoration: line-through; font-style: italic;'
    }
    
    return 'text-decoration: none;'

   }           
}
