import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MealTableComponent} from "../components/meal-table/meal-table.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, MealTableComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'iron-bite';
}
