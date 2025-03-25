import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SpinnerloadingService {
  private _isLoading = new BehaviorSubject<boolean>(false); // BehaviorSubject to track loading state
  public isLoading$ = this._isLoading.asObservable(); // Observable to expose the state
  constructor() { }

  show(): void {
    this._isLoading.next(true); // Set loading to true
  }

  hide(): void {
    this._isLoading.next(false); // Set loading to false
  }
}
