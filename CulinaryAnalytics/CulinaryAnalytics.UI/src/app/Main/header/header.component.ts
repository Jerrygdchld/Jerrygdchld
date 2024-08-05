import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { AuthService } from '../../auth/auth.service';
import { HttpClient } from '@angular/common/http';
import { SessionStorageService } from 'ngx-webstorage';
import { environment } from '../../../environments/environment';
import { StandardReply } from '../../../models/standard-reply';
import { UserDto } from '../../../models/user-dto';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.scss'
})
export class HeaderComponent implements OnInit {
  public isAuthenticated: boolean = false;
  public searchValue: string = '';
  public userInfo: UserDto = <UserDto>{ email: "", firstName: "", lastName: "", imageUrl: "", companyCode: "" }

  constructor(private auth: AuthService, private http: HttpClient, private sessionStorage: SessionStorageService) {}

  ngOnInit(): void {
    this.isAuthenticated = this.auth.isAuthenication();
    if(this.isAuthenticated)
    {
      this.getUserInfo();
    }
    this.sessionStorage.observe('isAuthenicated').subscribe((val) => {
      if(val) {
                this.getUserInfo();
            };
    });
  }

  getUserInfo() : void {
    let url = `${environment.target}/user/current`
    this.http.get<StandardReply<UserDto>>(url).subscribe((res) => {
      this.userInfo = res.response;
      this.isAuthenticated = true;
    });
  }
}
