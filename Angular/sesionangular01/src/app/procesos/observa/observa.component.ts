import { Component, OnDestroy } from '@angular/core';
import {  Subscription, fromEvent, of } from 'rxjs';

@Component({
  selector: 'app-observa',
  standalone: true,
  imports: [],
  templateUrl: './observa.component.html',
  styleUrl: './observa.component.css'
})
export class ObservaComponent implements OnDestroy{

suscripcionEvento! : Subscription 

  ngOnDestroy(): void {
    this.suscripcionEvento.unsubscribe()
  }

  ngOnInit(){

    //of(2, 6, 7, 9).subscribe(item => console.log("Llego", item))

    of(2, 6, 7, 9).subscribe({
      next: item => console.log("Llego", item),
      error: err => console.log("Errores", err),
      complete: () => console.log("Termino de procesar")
    })

    this.suscripcionEvento = fromEvent(document, "keydown").subscribe({
      next: item => console.log("Llego", (item as KeyboardEvent).key),
      error: err => console.log("Errores", err),
      complete: () => console.log("Termino de procesar")
    })

  }
}
