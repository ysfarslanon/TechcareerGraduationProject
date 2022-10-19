import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ShoppingListAddDto } from 'src/app/models/shoppingList/shopping-List-Add-Dto';
import { ShoppingListChangeIsShoppingDto } from 'src/app/models/shoppingList/shopping-List-Change-Is-Shopping-Dto';
import { ShoppingListDeleteDto } from 'src/app/models/shoppingList/shopping-List-Delete-Dto';
import { ShoppingListDto } from 'src/app/models/shoppingList/shopping-List-Dto';
import { ShoppingListUpdateDto } from 'src/app/models/shoppingList/shopping-List-Update-Dto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ShoppingListService {

  constructor(private httpClient: HttpClient) {}

  add(shoppingListAddDto: ShoppingListAddDto): Observable<boolean> {
    return this.httpClient.post<boolean>(environment.shoppingListApiUrl, shoppingListAddDto)
  }

  update(shoppingListUpdateDto: ShoppingListUpdateDto): Observable<boolean> {
    return this.httpClient.put<boolean>(environment.shoppingListApiUrl, shoppingListUpdateDto)
  }

  delete(shoppingListDeleteDto: ShoppingListDeleteDto): Observable<boolean> {
    return this.httpClient.delete<boolean>(environment.shoppingListApiUrl, { body: shoppingListDeleteDto })
  }

  getAll(): Observable<ShoppingListDto[]> {
    return this.httpClient.get<ShoppingListDto[]>(environment.shoppingListApiUrl)
  }

  getById(id: number): Observable<ShoppingListDto> {
    return this.httpClient.get<ShoppingListDto>(environment.shoppingListApiUrl + id)
  }

  getAllByUserId(userId: number): Observable<ShoppingListDto[]> {
    return this.httpClient.get<ShoppingListDto[]>(environment.shoppingListApiUrl + "list?userId=" + userId)
  }

  changeIsShoppingState(shopppingListChangeIsShoppingDto:ShoppingListChangeIsShoppingDto): Observable<boolean> {
    return this.httpClient.patch<boolean>(environment.shoppingListApiUrl + "changeisshoppingstate", shopppingListChangeIsShoppingDto)
  }

}
