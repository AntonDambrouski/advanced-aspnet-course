import { Component } from '@angular/core';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-sidenav-navigation',
  imports: [MatListModule, MatIconModule],
  templateUrl: './sidenav-navigation.html',
  styleUrl: './sidenav-navigation.css',
})
export class SidenavNavigation {}
