import { CommonModule } from '@angular/common';
import { Component, OnInit, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { ActivatedRoute, Router, RouterModule } from '@angular/router';
import { ArticuloService } from '../common/articulo.service';

@Component({
  selector: 'app-articulo-editar',
  standalone: true,
  imports: [RouterModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './articulo-editar.component.html',
  styleUrl: './articulo-editar.component.css'
})
export class ArticuloEditarComponent implements OnInit {

  cod: number = 0

  private activateRoute = inject(ActivatedRoute)
  private articuloService = inject(ArticuloService)
  private router = inject(Router)

  namePattern = '^[a-zA-Z ]+$';

  articuloForm = new FormGroup({
    codigo: new FormControl(0, Validators.required),
    nombre: new FormControl('', [Validators.required, Validators.minLength(3), Validators.pattern(this.namePattern)]),
    precio: new FormControl(),
    stock: new FormControl(),
    costo: new FormControl()
  })


  ngOnInit(): void {
    const id = this.activateRoute.snapshot.params['cod']
    this.activateRoute.paramMap.subscribe((parametros) => {

      this.cod = parseInt(parametros.get("cod") || '0')
      if (this.cod > 0) {
        this.articuloService.getById(this.cod).subscribe(res => {
          this.articuloForm.setValue(res)

          // this.articuloForm.controls.codigo.setValue(res.codigo)
          // this.articuloForm.controls.nombre.setValue(res.nombre)
          // this.articuloForm.controls.precio.setValue(res.precio)
          // this.articuloForm.controls.costo.setValue(res.costo)
          // this.articuloForm.controls.stock.setValue(res.stock)
        })
      }
    })
  }


  //#region propiedades
  get nombreArticulo() {
    return this.articuloForm.controls.nombre
  }

  guardar() {
    console.log(this.articuloForm.controls.nombre.value)
    console.log(this.articuloForm.value)

    if (this.articuloForm.controls.codigo.value === 0) {
      this.articuloService.insert(this.articuloForm.value).subscribe(res => {

      })
    }
    else{
      this.articuloService.update(this.articuloForm.value).subscribe(res => {

      })
    }

    this.router.navigate(['/articulos'])

  }

  regresar() {
    this.router.navigate(['/articulos'])
  }
}