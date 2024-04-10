import { Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { AddEmployeeComponent } from './components/add-employee/add-employee.component';
import { EmployeeListComponent } from './components/employee-list/employee-list.component';

export const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'add-employee', component: AddEmployeeComponent},
    { path: 'employee-list', component: EmployeeListComponent },
    // { path: 'login', component: LoginComponent },
    // { path: 'logout', component: LogoutComponent },
    // { path: '**', component: NotFoundComponent },
];
