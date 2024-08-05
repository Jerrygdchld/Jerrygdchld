import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SessionStorageService } from 'ngx-webstorage';
import { environment } from '../../environments/environment';
import { Router } from '@angular/router';
import { LoginResponse } from '../../models/login-response';
import { LoginDto } from '../../models/login-dto';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  public isAuthorized!: Observable<boolean>;
  constructor(private http: HttpClient, private storage: SessionStorageService, private router: Router) { }

  public loginMeIn() {
    this.login(<LoginDto>{ email: 'will4u2@gmail.com', password: 'Just2g@tn2!', twoFactorCode: '', twoFactorRecoveryCode: '' });
  }

  public login(loginInfo: LoginDto) : void {
    let url = `${environment.target}/login?useCookies=false&useSessionCookies=false`;
    this.http.post<LoginResponse>(url, loginInfo).subscribe((res) => {
      if(res != null) {
        this.storage.store('accessToken', res.accessToken);
        this.storage.store('refreshToken', res.refreshToken);
        this.storage.store('expiration', this.addSeconds(new Date(), res.expiresIn - 30));
        this.storage.store('isAuthenicated', true);
        let redirect = this.storage.retrieve('redirect');
        if(redirect) {
          this.storage.clear('redirect');
          this.router.navigateByUrl(redirect);
        } else {
          this.router.navigate(['home']);
        }
        this.isAuthorized = of(true);
      } else {
        this.storage.store('isAuthenicated', false);
      }
    });
  }

  refresh() {
    var refreshToken = this.storage.retrieve('refreshToken');
    let url = `${environment.target}/refresh`;
    this.http.post<LoginResponse>(url, {'refreshToken': refreshToken}).subscribe((res) => {
      if(res != null) {
        this.storage.store('accessToken', res.accessToken);
        this.storage.store('refreshToken', res.refreshToken);
        this.storage.store('expiration', this.addSeconds(new Date(), res.expiresIn - 30));
        this.storage.store('isAuthenicated', true);
      } else {
        this.storage.store('isAuthenicated', false);
      }
    });
  }

  public isAuthenication(): boolean {
    let isAuthenicated = this.storage.retrieve('isAuthenicated');
    if(!isAuthenicated) {
      this.router.navigate(['login']);
    }
    let expiration = this.storage.retrieve('expiration');
    if(isAuthenicated && expiration < new Date()) {
      this.refresh();
    }
    return isAuthenicated;
  }

  addSeconds(date: Date, seconds: number) {
    date.setSeconds(date.getSeconds() + seconds);
    return date;
  }
}
