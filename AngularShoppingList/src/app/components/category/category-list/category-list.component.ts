import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CategoryDeleteDto } from 'src/app/models/category/categoryDeleteDto';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { CategoryService } from 'src/app/services/category/category.service';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.css']
})
export class CategoryListComponent implements OnInit {

  categories: CategoryDto[]
  constructor(private categoryService:CategoryService, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.getAll()
  }

  getAll(){
    this.categoryService.getAll().subscribe(response=>{
      this.categories = response
    })
  }

  delete(categoryId:number){
    let deletedCategory:CategoryDeleteDto= {id:categoryId}
    this.categoryService.delete(deletedCategory).subscribe(response=>{
      this.ngOnInit()
      this.toastr.success("Kategori silindi")
    },errorResponse=>{
      
    })
  }
}
