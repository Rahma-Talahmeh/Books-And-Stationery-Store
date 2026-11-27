import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contactus',
  standalone: true,
  imports: [FormsModule],
  template: `
    <section class="contact-box">
      <h2>Contact Us</h2>
      <input type="text" placeholder="Your name" [(ngModel)]="senderName" />
      <input type="email" placeholder="Your email" [(ngModel)]="senderEmail" />
      <button type="button" (click)="sendMessage()">Send</button>
      <p *ngIf="submittedMessage">{{ submittedMessage }}</p>
    </section>
  `,
  styles: [`
    .contact-box {
      max-width: 460px;
      margin: 40px auto;
      padding: 24px;
      background-color: #faf6f0;
      border-radius: 10px;
      display: flex;
      flex-direction: column;
      gap: 12px;
    }
    input {
      padding: 10px;
      border: 1px solid #d5c3ae;
      border-radius: 6px;
    }
    button {
      background-color: #2b1d16;
      color: #fdf8f2;
      padding: 10px;
      border: none;
      border-radius: 6px;
      cursor: pointer;
    }
  `]
})
export class Contactus {
  senderName = '';
  senderEmail = '';
  submittedMessage = '';

  sendMessage(): void {
    if (this.senderName.trim()) {
      this.submittedMessage = `Thank you, ${this.senderName}! Your message has been received.`;
    }
  }
}