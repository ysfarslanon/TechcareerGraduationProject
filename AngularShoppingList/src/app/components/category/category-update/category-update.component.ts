import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CategoryDto } from 'src/app/models/category/categoryDto';
import { CategoryUpdateDto } from 'src/app/models/category/categoryUpdateDto';
import { CategoryService } from 'src/app/services/category/category.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-category-update',
  templateUrl: './category-update.component.html',
  styleUrls: ['./category-update.component.css']
})
export class CategoryUpdateComponent implements OnInit {

  categoryUpdateForm:FormGroup
  selectedCategory:CategoryDto

  constructor(private categoryService: CategoryService, private formBuilder:FormBuilder, private activatedRoute: ActivatedRoute,  private router:Router, private toastr:ToastrService) { }

  ngOnInit(): void {
    this.createCategoryUpdateFrom()
    this.activatedRoute.params.subscribe(params=>{
      if(params['categoryId'])
      {
        this.getById(params['categoryId'])
      }
    }) 
  }

  createCategoryUpdateFrom(){
    this.categoryUpdateForm = this.formBuilder.group({
      name:["", [Validators.required, Validators.minLength(2)]]
    })
  }

  getById(id:number){
    this.categoryService.getById(id).subscribe(response=>{
      this.selectedCategory = response
    })
  }

  update(categoryUpdateDto: CategoryUpdateDto){
    this.categoryService.update(categoryUpdateDto).subscribe(response=>{
      this.toastr.success("Kategori güncellendi")
      this.router.navigate(["/category"])
    }, errorResponse=>{
      this.toastr.error("Aynı kategoriden iki tane olamaz")
    })
  }

  submit(){
    if (this.categoryUpdateForm.valid) {
      let updatedModel = Object.assign({}, this.categoryUpdateForm.value)
      updatedModel.id = this.selectedCategory.id
      this.update(updatedModel)
      
    } else {
      this.toastr.warning(environment.formNotValid, "UYARI")
    }
  }

  
}
