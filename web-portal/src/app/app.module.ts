import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule, CurrencyPipe, DatePipe, DecimalPipe, LowerCasePipe, PercentPipe, TitleCasePipe, UpperCasePipe } from '@angular/common';  
import { FormsModule, ReactiveFormsModule  }   from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatDividerModule } from '@angular/material/divider';
import { MatCardModule } from '@angular/material/card';

import { RouterModule } from '@angular/router';
import { AppRoutingModule, routingComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MenuNavComponent } from './components/menu-nav/menu-nav.component';
import { PrimaryToolbarComponent } from './components/primary-toolbar/primary-toolbar.component';
import { AuthManager } from 'src/app/core/helpers/auth/auth-manager';
import { NaturalPersonEditComponent } from './pages/natural-person-edit/natural-person-edit.component';

import {EnumDisplayNamePipe} from 'src/app/core/pipes/enum-display-name-pipe';

@NgModule({
  declarations: [
    AppComponent,
    MenuNavComponent,
    PrimaryToolbarComponent,
    routingComponent,
    NaturalPersonEditComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatInputModule,
    MatFormFieldModule,
    MatIconModule,
    MatMenuModule,
    MatToolbarModule,
    MatDividerModule,
    MatCardModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule
  ],
  exports: [
  ],
  providers: [
    AuthManager,
    EnumDisplayNamePipe,
    CommonModule,
    CurrencyPipe,
    DatePipe,
    DecimalPipe,
    LowerCasePipe, 
    PercentPipe, 
    TitleCasePipe, 
    UpperCasePipe
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
