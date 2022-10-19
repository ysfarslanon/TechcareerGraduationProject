export interface ShoppingListDetailDto {
  shoppingListDetailId: number
  productId:number
  productName: string
  productPictureURL: string
  listName: string
  description?: string
  isBought: boolean
}
