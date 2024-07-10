import { Component, inject } from '@angular/core';
import { ArticuloService } from '../common/articulo.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-articulo-listar-declarativo',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './articulo-listar-declarativo.component.html',
  styleUrl: './articulo-listar-declarativo.component.css'
})
export class ArticuloListarDeclarativoComponent {

  private articuloServicio = inject(ArticuloService)

  readonly articulos$ = this.articuloServicio.articulos$

}
