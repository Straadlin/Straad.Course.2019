import { Component, OnInit, OnDestroy } from '@angular/core';
import { LoadingScreenService } from '../../services/loading-screen.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-loading-screen',
  templateUrl: './loading-screen.component.html',
  styleUrls: ['./loading-screen.component.css']
})
export class LoadingScreenComponent implements OnInit, OnDestroy {
  loading = false;
  LoadingSubscription: Subscription;
  constructor(private loadingScreenService: LoadingScreenService) { }

  ngOnInit() {

    this.LoadingSubscription = this.loadingScreenService.loadingStatus
    .subscribe((value: boolean) => {
      this.loading = value;
    });
  }

  ngOnDestroy() {
    this.LoadingSubscription.unsubscribe();
  }

}
