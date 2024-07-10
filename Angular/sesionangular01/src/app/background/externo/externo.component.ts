import { Component } from '@angular/core';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-externo',
  standalone: true,
  imports: [RouterOutlet, RouterModule],
  templateUrl: './externo.component.html',
  styleUrl: './externo.component.css'
})
export class ExternoComponent {

}
