import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar'
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import { TopBarComponent } from '../top-bar/top-bar.component';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MatToolbarModule, EmployeeListComponent, TopBarComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
