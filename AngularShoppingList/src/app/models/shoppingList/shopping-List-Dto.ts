import { ShoppingListDetailDto } from "../shoppingListDetail/shopping-List-Detail-Dto"

export interface ShoppingListDto {
  shoppingListId: number
  shoppingListName: string
  userFullName: string
  isShopping: boolean
  details: ShoppingListDetailDto[]
}
