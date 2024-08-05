import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { SessionStorageService } from 'ngx-webstorage';

export const addWithCredentialHeaderInterceptor: HttpInterceptorFn = (req, next) => {

  if(req.url.includes('login') || req.url.includes('refresh')) {
    return next(req);
  }
  
  const sessionStorageService = inject(SessionStorageService);
  let isAuthenicated = sessionStorageService.retrieve('isAuthenicated');

  let accessToken = sessionStorageService.retrieve('accessToken');

  if(isAuthenicated) {
    const clonedRequest = req.clone({ headers: req.headers.set('Authorization', `Bearer ${accessToken}`), withCredentials: true });
    return next(clonedRequest);
  } else {
    return next(req); 
  }
};
