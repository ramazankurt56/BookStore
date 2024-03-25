import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { ErrorService } from './error.service';
import { SwalService } from './swal.service';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(
    private http: HttpClient,
    private auth: AuthService,
    private error: ErrorService,
    private swal:SwalService
  ) { }
  get(api: string, callBack: (res: any) => void) {
    this.http.get(`https://localhost:7250/api/${api}`, {
      headers: {
        "Authorization": "Bearer " + this.auth.tokenString
      }
    })
      .subscribe({
        next: (res: any) => {
          callBack(res);
        },
        error: (err: HttpErrorResponse) => {
          this.error.errorHandler(err);
        }
      })
  }
  post(api: string, data: any, callBack: (res: any) => void) {
    this.http.post(`https://localhost:7250/api/${api}`, data, {
      headers: {
        "Authorization": "Bearer " + this.auth.tokenString
      }
    })
      .subscribe({
        next: (res: any) => {
          callBack(res);
          this.swal.callToast(res.message)
        },
        error: (err: HttpErrorResponse) => {
          this.error.errorHandler(err);
        }
      })
  }
}
