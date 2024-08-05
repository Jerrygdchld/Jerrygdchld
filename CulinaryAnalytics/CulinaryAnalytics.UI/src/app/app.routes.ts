import { Routes } from '@angular/router';
import { SignUpComponent } from '../app/OneOffPages/sign-up/sign-up.component';
import { LoginComponent } from '../app/OneOffPages/login/login.component';
import { HomeComponent } from '../app/Main/home/home.component';
import { canActiveRouteGuard } from '../app/auth/can-active-route.guard'

export const routes: Routes = [
    { path: "", component: SignUpComponent },
    { path: "signup", component: SignUpComponent },
    { path: "login", component: LoginComponent },
    { path: "home", component: HomeComponent, canActivate: [canActiveRouteGuard] }
];
