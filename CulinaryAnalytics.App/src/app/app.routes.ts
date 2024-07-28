import { Routes } from '@angular/router';
import { AddRecipeComponent } from './main/add-recipe/add-recipe.component';
import { BeverageInvComponent } from './main/beverage-inv/beverage-inv.component';
import { DailyProdComponent } from './main/daily-prod/daily-prod.component';
import { DashComponent } from './main/dash/dash.component';
import { DetailRecipeComponent } from './main/detail-recipe/detail-recipe.component';
import { ExpenseComponent } from './main/expense/expense.component';
import { FoodInventoryComponent } from './main/food-inventory/food-inventory.component';
import { LoginComponent } from './main/login/login.component';
import { OrdersComponent } from './main/orders/orders.component';
import { RecipePageComponent } from './main/recipe-page/recipe-page.component';
import { RestaurantComponent } from './main/restaurant/restaurant.component';
import { SalesOverviewComponent } from './main/sales-overview/sales-overview.component';

export const routes: Routes = [
    { path: "addrecipe", component: AddRecipeComponent },
    { path: "beverageinventory", component: BeverageInvComponent },
    { path: "dailyproduction", component: DailyProdComponent },
    { path: "dashboard", component: DashComponent  },
    { path: "detailrecipe", component: DetailRecipeComponent  },
    { path: "expense", component: ExpenseComponent },
    { path: "foodinventory", component: FoodInventoryComponent },
    { path: "login", component: LoginComponent },
    { path: "orders", component: OrdersComponent  },
    { path: "recipepage", component: RecipePageComponent },
    { path: "restaurant", component: RestaurantComponent },
    { path: "salesoverview", component: SalesOverviewComponent }

];
