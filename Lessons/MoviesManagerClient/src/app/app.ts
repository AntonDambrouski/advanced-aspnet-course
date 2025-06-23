import { Component, signal } from '@angular/core';
import { RouterOutlet } from '@angular/router';

import { ToolBar } from './tool-bar/tool-bar';
import { SidenavNavigation } from './sidenav-navigation/sidenav-navigation';

import { MatSidenavModule } from '@angular/material/sidenav';
import { MoviesTable } from './movies-table/movies-table';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    MatSidenavModule,
    ToolBar,
    SidenavNavigation,
    MoviesTable,
  ],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App {
  protected title = 'MoviesManagerClient';
  sidenavOpened = signal<boolean>(false);

  onToggleSidenav() {
    let currentState = this.sidenavOpened();
    this.sidenavOpened.set(!currentState);
  }
}
