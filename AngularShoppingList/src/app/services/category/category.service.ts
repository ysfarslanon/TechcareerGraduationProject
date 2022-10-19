import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CategoryAddDto } from 'src/app/models/category/categoryAddDto';
import { CategoryDeleteDto } from 'src/app/models/category/categoryDeleteDto';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { CategoryUpdateDto } from 'src/app/models/category/categoryUpdateDto';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CategoryService {
  constructor(private httpClient: HttpClient) {}

  add(categoryAddDto: CategoryAddDto): Observable<boolean> {
    return this.httpClient.post<boolean>(environment.categoryApiUrl,categoryAddDto)
  }

  update(categoryUpdateDto: CategoryUpdateDto): Observable<boolean> {
    return this.httpClient.put<boolean>(environment.categoryApiUrl,categoryUpdateDto)
  }

  delete(categoryDeleteDto: CategoryDeleteDto): Observable<boolean> {
    return this.httpClient.delete<boolean>(environment.categoryApiUrl, { body:categoryDeleteDto })
  }

  getAll(): Observable<CategoryDto[]> {
    return this.httpClient.get<CategoryDto[]>(environment.categoryApiUrl)
  }

  getById(id: number): Observable<CategoryDto> {
    return this.httpClient.get<CategoryDto>(environment.categoryApiUrl + id)
  }
}
