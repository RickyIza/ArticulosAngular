import { Component, OnInit, inject } from '@angular/core';
import { RouterModule } from '@angular/router';
import { OpcionService } from '../../comunes/seguridad/opcion.service';
import { OpcionModel } from './opcion-model';
import { LoginService } from '../../procesos/seguridad/login/commons/login.service';
import { PedidoService } from '../../procesos/pedidos/common/pedido.service';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [RouterModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {
 
  private opcionService = inject(OpcionService)
  private loginService = inject(LoginService)
  private pedidoServie = inject(PedidoService)

  opciones: OpcionModel[] = []

  cantidadCar = this.pedidoServie.cantidadBase

  ngOnInit(): void {
    this.opciones = this.opcionService.getOpciones()
  }

  cerrarSesion(){
    this.loginService.cierraSesion()
  }
}
