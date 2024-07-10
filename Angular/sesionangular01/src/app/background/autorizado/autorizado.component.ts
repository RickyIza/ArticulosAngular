import { Component } from '@angular/core';
import { MenuComponent } from '../../componentes/menu/menu.component';
import { RouterModule, RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-autorizado',
  standalone: true,
  imports: [MenuComponent, RouterModule, RouterOutlet],
  templateUrl: './autorizado.component.html',
  styleUrl: './autorizado.component.css'
})
export class AutorizadoComponent {

}
