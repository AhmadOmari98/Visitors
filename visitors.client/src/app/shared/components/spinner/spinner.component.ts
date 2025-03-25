import { Component, OnInit } from '@angular/core';
import { SpinnerloadingService } from '../../services/spinnerloading.service';

@Component({
  selector: 'app-spinner',
  standalone: false,

  templateUrl: './spinner.component.html',
  styleUrl: './spinner.component.css'
})
export class SpinnerComponent implements OnInit {
  isLoading: boolean = false;

  constructor(private spinnerloadingService: SpinnerloadingService) {}

  ngOnInit(): void {
    this.spinnerloadingService.isLoading$.subscribe((loading) => {
      this.isLoading = loading; // Subscribe to loading state changes
    });
  }
}
