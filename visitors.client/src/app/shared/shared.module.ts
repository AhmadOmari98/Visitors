import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ToastrModule } from 'ngx-toastr';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    SpinnerComponent,
  ],
  imports: [
    CommonModule,
    FormsModule,  // For template-driven forms
    ReactiveFormsModule,  // For reactive forms
    ToastrModule.forRoot({ // ToastrModule added
      timeOut: 20000, // Sets the duration of the toast to 20 seconds
      extendedTimeOut: 1000, // Keeps the toast for an additional second when hovering over it
      progressBar: true, // Displays a progress bar on the toast
      positionClass: 'toast-top-right', // Positions the toast in the top-right corner
      preventDuplicates: true, // Prevents the same message from appearing multiple times
      newestOnTop: true, // Display the newest toasts at the top
      tapToDismiss: true, // Allow tapping to dismiss the toast
    })
  ],
  exports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    SpinnerComponent,
    ToastrModule
  ]
})
export class SharedModule { }
