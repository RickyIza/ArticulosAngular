import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-no-autorizado',
  standalone: true,
  imports: [],
  templateUrl: './no-autorizado.component.html',
  styleUrl: './no-autorizado.component.css'
})
export class NoAutorizadoComponent {

 private router = inject(Router)


  redirigir(){
    this.router.navigate(["/"])
  }
}
