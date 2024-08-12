import { Routes } from '@angular/router';
import { SignUpComponent } from '../app/OneOffPages/sign-up/sign-up.component';
import { LoginComponent } from '../app/OneOffPages/login/login.component';
import { HomeComponent } from '../app/Main/home/home.component';
import { canActiveRouteGuard } from '../app/auth/can-active-route.guard'
import { DashboardComponent } from './Main/views/dashboard/dashboard.component';
import { RecipesComponent } from './Main/views/recipes/recipes.component';
import { InventoryComponent } from './Main/views/inventory/inventory.component';
import { SalesComponent } from './Main/views/sales/sales.component';
import { DailyProductionComponent } from './Main/views/daily-production/daily-production.component';
import { OrderManagementComponent } from './Main/views/order-management/order-management.component';
import { ExpensesComponent } from './Main/views/expenses/expenses.component';

export const routes: Routes = [
    { path: "", component: SignUpComponent },
    { path: "signup", component: SignUpComponent },
    { path: "login", component: LoginComponent },
    { 
        path: "home", component: HomeComponent, canActivate: [canActiveRouteGuard] ,
        children : [
            { path: "dashboard", component: DashboardComponent, canActivate: [canActiveRouteGuard] },
            { path: "recipes", component: RecipesComponent, canActivate: [canActiveRouteGuard] },
            { path: "inventory", component: InventoryComponent, canActivate: [canActiveRouteGuard] },
            { path: "sales", component: SalesComponent, canActivate: [canActiveRouteGuard] },
            { path: "dailyproduction", component: DailyProductionComponent, canActivate: [canActiveRouteGuard] },
            { path: "ordermanagement", component: OrderManagementComponent, canActivate: [canActiveRouteGuard] },
            { path: "expenses", component: ExpensesComponent, canActivate: [canActiveRouteGuard] }
        ]
    }
];
