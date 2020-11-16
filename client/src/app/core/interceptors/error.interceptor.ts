import {
  HttpEvent,
  HttpHandler,
  HttpInterceptor,
  HttpRequest,
} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router: Router, private toastr: ToastrService) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((err) => {
        if (err) {
          if (err.status === 400) {
            if (err.error.errors) {
              throw err.error;
            } else {
              this.toastr.error(err.error.message, err.error.statuscode);
            }
          }

          if (err.status === 401) {
            this.toastr.error(err.error.message, err.error.statuscode);
          }

          if (err === 404) {
            this.router.navigateByUrl('/not-found');
          }

          if (err === 500) {
            this.router.navigateByUrl('/server-error');
          }
        }
        return throwError(err);
      })
    );
  }
}
