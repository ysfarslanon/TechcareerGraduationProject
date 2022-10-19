import { Pipe, PipeTransform } from '@angular/core';
import { ProductDto } from 'src/app/models/product/productDto';

@Pipe({
  name: 'productFilterText'
})
export class ProductFilterTextPipe implements PipeTransform {

  transform(value: ProductDto[], filterText: string): ProductDto[] {
    filterText = filterText.toLocaleLowerCase()
    
    return filterText 
      ? value.filter((p:ProductDto)=> p.name.toLocaleLowerCase().indexOf(filterText)!== -1)
      : value
  }

}
