import { Injectable } from '@angular/core';
import { SwalService } from './swal.service';
import { HttpErrorResponse } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ErrorService {

  constructor(
    private swal: SwalService,
    //private router:Router
    ) { }
    errorHandler(err: HttpErrorResponse){
      console.log(err);
      
      switch (err.status) {
        case 0:

            this.swal.callToast(err.error,"error");
            //document.location.href = "/under-maintenance";
           ; 
          break;
        
        case 400:
          this.swal.callToast(err.error.message,"error");
          break;
      
        case 404:
            this.swal.callToast(err.error.message,"error");
        
          break;
      
        case 500:
            this.swal.callToast(err.error.message,"error"); 
          break;
    
        default:
            this.swal.callToast(err.error.message,"error");
          break;
      }
    }
}
