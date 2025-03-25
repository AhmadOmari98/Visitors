import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { catchError, finalize, throwError } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
import { SpinnerloadingService } from '../../shared/services/spinnerloading.service';

// Define the Auth Interceptor as an HttpInterceptorFn
export const authInterceptor: HttpInterceptorFn = (req, next) => {
  const spinnerloadingService = inject(SpinnerloadingService); // Inject SpinnerloadingService
  const toastr = inject(ToastrService); // Inject ToastrService
 
  spinnerloadingService.show(); // Show spinner

  // Clone the request and modify headers to accept JSON
  const clonedRequest = req.clone({
    setHeaders: {
      'Content-Type': 'application/json',  // Ensure the request sends JSON
      'Accept': 'application/json'          // Ensure the server sends JSON in response
    }
  });

  return next(clonedRequest).pipe(
    finalize(() => spinnerloadingService.hide()), // Hide spinner when the request completes (success or failure)
    catchError((error) => {
      // Show an error notification
      toastr.error(error.error || 'An error occurred while processing the request')
      return throwError(() => error);
    })
  );

};
