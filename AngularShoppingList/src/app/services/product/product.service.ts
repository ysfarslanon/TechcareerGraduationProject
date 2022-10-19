import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductAddDto } from 'src/app/models/product/productAddDto';
import { ProductDeleteDto } from 'src/app/models/product/productDeleteDto';
import { ProductDto } from 'src/app/models/product/productDto';
import { ProductUpdateDto } from 'src/app/models/product/productUpdateDto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) {}

  add(productAddDto: ProductAddDto): Observable<boolean> {
    return this.httpClient.post<boolean>(environment.productApiUrl, productAddDto)
  }

  update(productUpdateDto: ProductUpdateDto): Observable<boolean> {
    return this.httpClient.put<boolean>(environment.productApiUrl, productUpdateDto)
  }

  delete(productDeleteDto: ProductDeleteDto): Observable<boolean> {
    return this.httpClient.delete<boolean>(environment.productApiUrl, {body:productDeleteDto})
  }

  getAll(): Observable<ProductDto[]>  {
    return this.httpClient.get<ProductDto[]>(environment.productApiUrl)
  }

  getById(id: number): Observable<ProductDto> {
    return this.httpClient.get<ProductDto>(environment.productApiUrl + id)
  }

  getAllByCategoryId(categoryId: number): Observable<ProductDto[]> {
    return this.httpClient.get<ProductDto[]>(environment.productApiUrl + "category/" + categoryId)
  }
}
