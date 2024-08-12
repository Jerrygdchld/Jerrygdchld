import { Component, OnInit } from '@angular/core';
import { GroupedRecipe } from '../../../../models/grouped-recipe';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../../environments/environment';
import { StandardReply } from '../../../../models/standard-reply';
import { Recipe } from '../../../../models/recipe';
import { CommonModule } from '@angular/common';

const url = environment.target + "/recipe/all";

@Component({
  selector: 'app-recipes',
  standalone: true,
  imports: [ CommonModule ],
  templateUrl: './recipes.component.html',
  styleUrl: './recipes.component.scss'
})
export class RecipesComponent implements OnInit {
  public recipes: GroupedRecipe[] = [];

  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.http.get<StandardReply<Recipe[]>>(url)
      .subscribe((res) => {
        res.response.forEach(i => {
          let firstLetter = i.name?.charAt(0);
          if(firstLetter) {
            var thisGroup = this.recipes.find(x => x.group == firstLetter);
            if(thisGroup) {
              thisGroup.recipes.push(i);
            } else {
              thisGroup = <GroupedRecipe>{
                group: firstLetter,
                recipes: [],
                total: 0,
                selected: false
              };
              thisGroup.recipes.push(i);
              this.recipes.push(thisGroup);
            }
          }
        });
        this.recipes.sort((a, b) => (a.group > b.group) ? 1 : ((b.group > a.group) ? -1 : 0));
        this.recipes.forEach(i => { i.total = i.recipes.length; });
        this.recipes[0].selected = true;
      });
  }

  public itemClicked = (item: any) =>
  {
    this.recipes?.forEach(i => {
      i.selected = false;
    });
    item.selected = true;
  }
}
