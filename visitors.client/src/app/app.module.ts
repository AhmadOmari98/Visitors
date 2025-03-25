import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CreateVisitorsCounterComponent } from './components/create-visitors-counter/create-visitors-counter.component';
import { SharedModule } from './shared/shared.module';
import { authInterceptor } from './core/interceptors/auth.interceptor';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    CreateVisitorsCounterComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    SharedModule,
    AppRoutingModule
  ],
  providers: [
    provideHttpClient(
      withInterceptors([authInterceptor])
    )],
  bootstrap: [AppComponent]
})
export class AppModule { }
