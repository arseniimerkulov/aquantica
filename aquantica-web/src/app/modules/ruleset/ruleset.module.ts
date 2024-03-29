import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RulesetRoutingModule } from './ruleset-routing.module';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormsModule} from "@angular/forms";
import {MatButtonModule} from "@angular/material/button";
import {MatDialogConfig, MatDialogModule} from "@angular/material/dialog";
import {CoreModule} from "../../@core/core.module";


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RulesetRoutingModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatButtonModule,
    MatDialogModule,
    CoreModule
  ]
})
export class RulesetModule { }
