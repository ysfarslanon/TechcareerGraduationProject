import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShoppingListDetailAddDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Add-Dto';
import { ShoppingListDetailChangeDescriptiontDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Change-Description-Dto';
import { ShoppingListDetailChangeIsBoughtDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Change-Is-Bought-Dto';
import { ShoppingListDetailDeleteDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Delete-Dto';
import { ShoppingListDetailDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Dto';
import { ShoppingListDetailUpdateDto } from 'src/app/models/shoppingListDetail/shopping-List-Detail-Update-Dto';
import { environment } from 'src/environments/environment';



@Injectable({
  providedIn: 'root'
})
export class ShoppingListDetailService {

  constructor(private httpClient: HttpClient) {}

  add(shoppingListDetailAddDto: ShoppingListDetailAddDto):Observable<boolean> {
    return this.httpClient.post<boolean>(environment.shoppingListDetailApiUrl, shoppingListDetailAddDto)
  }
  update(shoppingListDetailUpdateDto: ShoppingListDetailUpdateDto) {}

  delete(shoppingListDetailDeleteDto: ShoppingListDetailDeleteDto): Observable<boolean> {
    return this.httpClient.delete<boolean>(environment.shoppingListDetailApiUrl, {body:shoppingListDetailDeleteDto})
  }
  
  getAll() {}
  getById(id: number): Observable<ShoppingListDetailDto> {
    const newApiUrl = environment.shoppingListDetailApiUrl + id
    return this.httpClient.get<ShoppingListDetailDto>(newApiUrl)
  }

  getAllByShoppingListId(shoppingListId: number): Observable<ShoppingListDetailDto[]> {
    const newApiUrl:string = environment.shoppingListDetailApiUrl + "listDetail?shoppingListId=" + shoppingListId
    return this.httpClient.get<ShoppingListDetailDto[]>(newApiUrl)
  }

  changeIsBoughtState(shoppingListDetailChangeIsBoughtDto:ShoppingListDetailChangeIsBoughtDto): Observable<boolean> {
    const newApiUrl = environment.shoppingListDetailApiUrl + "changeisboughtstate";
    return this.httpClient.patch<boolean>(newApiUrl, shoppingListDetailChangeIsBoughtDto)
  }

  changeDescriptionState(shoppingListDetailChangeDescriptionDto:ShoppingListDetailChangeDescriptiontDto): Observable<boolean> {
    const newApiUrl = environment.shoppingListDetailApiUrl + "changedescriptionstate";
    return this.httpClient.patch<boolean>(newApiUrl, shoppingListDetailChangeDescriptionDto)
  }
}
