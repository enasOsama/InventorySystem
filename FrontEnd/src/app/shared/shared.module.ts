import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NotfoundComponent } from './notfound/notfound.component';
import { HeaderComponent } from './components/header/header.component';
import { ProductItemComponent } from './product-item/product-item.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  imports: [
    CommonModule,
    NgbModule
  ],
  exports: [
    HeaderComponent,
    ProductItemComponent
  ],
  declarations: [ HeaderComponent, NotfoundComponent,
    ProductItemComponent, ProductItemComponent]
})
export class SharedModule { }
