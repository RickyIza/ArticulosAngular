import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-incrementador',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './incrementador.component.html',
  styleUrl: './incrementador.component.css'
})
export class IncrementadorComponent {

 
  @Input() porcentaje: number = 10
  @Input() tetoPrueba: string = ""

  @Output() cambioValor : EventEmitter<number> = new EventEmitter();

  ngOnInit(){
    console.log("llego testPrueba", this.tetoPrueba)
  }

  sumar(cantidad: number) {

    this.porcentaje += cantidad
    console.log(this.porcentaje)
    //Enviando un evento con el valor del nuevo porcentaje
    this.cambioValor.emit(this.porcentaje)
    
  }
}
