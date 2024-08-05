import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, ElementRef, inject, TemplateRef, ViewChild } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule } from '@angular/forms';
import { AuthService } from '../../auth/auth.service';

export class loginDto {
  email: string = "";
  password: string = "";
  twoFactorCode: string = "";
  twoFactorRecoveryCode: string = "";
}

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent implements AfterViewInit {
	private modalService = inject(NgbModal);
  public loginFailureMessage: string = "";
  public loginInfo: loginDto = new loginDto();

  constructor(private auth: AuthService) {}

  @ViewChild('openModelButton') showButton!: ElementRef;

	open(content: TemplateRef<any>) {
		this.modalService.open(content, {backdrop: 'static', keyboard: false});
	}
  
  ngAfterViewInit(): void {
    this.showButton.nativeElement.click();
  }

  login(content: TemplateRef<any>) {
    this.loginFailureMessage = '';
    this.auth.login(this.loginInfo);

    this.auth.isAuthorized.subscribe((res) => {
      if(res) {
        this.modalService.dismissAll();
      } else {
        this.loginInfo.password = '';
        this.loginFailureMessage = "Login failed.";
      }
    });
  }

}
