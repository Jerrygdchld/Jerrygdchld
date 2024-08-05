import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { SessionStorageService } from 'ngx-webstorage';
import { AuthService } from './auth.service';

export const canActiveRouteGuard: CanActivateFn = (route, state) => {

  const router = inject(Router);
  const auth = inject(AuthService);
  let storage = inject(SessionStorageService);

  if(auth.isAuthenication()) {
    return true;
  } else {
    storage.store('redirect', route.url);
    router.navigate(['/login']);
    return false;
  }
};
