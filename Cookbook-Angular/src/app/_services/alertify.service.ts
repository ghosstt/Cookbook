import { Injectable } from '@angular/core';
declare let alertify: any;

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {
  constructor() {
  }

  confirm(message: string, okHandler: () => any) {
    alertify.confirm(message, (e: any) => {
      if (e) {
        okHandler();
      } else {
      }
    });
  }

  alert(title: string, message: string) {
    alertify.alert(title, message).set('movable', false);
  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  warning(message: string) {
    alertify.warning(message);
  }

  message(message: string) {
    alertify.message(message);
  }
}
