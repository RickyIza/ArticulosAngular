import { Component, inject } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { AutenticaReqModel } from '../commons/models/autentica-req-model';
import { CommonModule } from '@angular/common';
import { LoginService } from '../commons/login.service';
import { StorageManagerService } from '../../../../comunes/storage/storage-manager.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-autentica',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './autentica.component.html',
  styleUrl: './autentica.component.css'
})
export class AutenticaComponent {

  private loginService = inject(LoginService)
  private storageManager = inject(StorageManagerService)
  private router = inject(Router)

  usuarioAutentica: AutenticaReqModel = {
    user: '', password: ""
  }

  validar(forma: NgForm) {
     this.loginService.autentica(this.usuarioAutentica).subscribe(res => {
      this.storageManager.asignar("usertoken", res.token)
      this.loginService.getMenus().subscribe(res2 => {
        this.storageManager.asignar("opciones", res2)

        this.router.navigate(["/"])
      })
    })
  }
}
