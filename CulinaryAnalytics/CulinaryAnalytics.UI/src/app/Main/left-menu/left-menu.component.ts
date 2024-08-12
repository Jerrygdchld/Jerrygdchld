import { Component, OnInit } from '@angular/core';
import { LeftMenuOption } from '../../../models/left-menu-option';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../../environments/environment';
import { StandardReply } from '../../../models/standard-reply';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';

const url = environment.target + "/user/menu";

@Component({
  selector: 'app-left-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './left-menu.component.html',
  styleUrl: './left-menu.component.scss'
})
export class LeftMenuComponent implements OnInit {
  public menuItems?: LeftMenuOption[];

  constructor(private http: HttpClient, private router: Router, private currentRoute: ActivatedRoute) {}
  ngOnInit(): void {
    this.http.get<StandardReply<LeftMenuOption[]>>(url)
    .subscribe((res) => {
      this.menuItems = res.response;
    });
  }

  public itemClicked = (item: any) =>
  {
    this.menuItems?.forEach(i => {
      i.selected = false;
    });
    item.selected = true;
    this.router.navigate([item.route], { relativeTo: this.currentRoute });
  }
}
