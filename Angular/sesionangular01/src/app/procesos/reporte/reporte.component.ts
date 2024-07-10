import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { IncrementadorComponent } from '../../componentes/incrementador/incrementador.component';

@Component({
  selector: 'app-reporte',
  standalone: true,
  imports: [FormsModule, IncrementadorComponent],
  templateUrl: './reporte.component.html',
  styleUrl: './reporte.component.css'
})
export class ReporteComponent {

  nombre1: string = "Grafico Verde 1"
  porcentajeReporte: number = 50
  procentajeCeleste: number = 85
 
  actualiza(cantidad : number){
    this.porcentajeReporte = cantidad
    console.log("Recibimos", cantidad)
  }
  

  actualizaCeleste(cantidad : number){
    this.procentajeCeleste = cantidad
    console.log("Recibimos", cantidad)
  }
}
