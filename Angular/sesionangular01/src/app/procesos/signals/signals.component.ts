import { Component, OnInit, computed, effect, signal } from '@angular/core';

@Component({
  selector: 'app-signals',
  standalone: true,
  imports: [],
  templateUrl: './signals.component.html',
  styleUrl: './signals.component.css'
})
export class SignalsComponent implements OnInit {

  x = 5
  y = 10
  z = this.x + this.y

  a = signal(5)
  b = signal(10)
  c = computed(() => this.a() + this.b())


  ngOnInit(): void {
    console.log(this.z)
    console.log("Calculado", this.c())
  }


  cambios = effect(() =>{
    console.log("cambios ejecutados", this.a())
  })

  cambiar(){
    this.x = 100
    this.a.set(100)
    console.log(this.z)
    console.log("Calculado 2", this.c())

  }

}
