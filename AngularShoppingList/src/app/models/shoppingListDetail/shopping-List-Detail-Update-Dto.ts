export interface ShoppingListDetailUpdateDto {
  id: number
  shoppingListId: number
  productId: number
  description?: string
  isBought: boolean
}
