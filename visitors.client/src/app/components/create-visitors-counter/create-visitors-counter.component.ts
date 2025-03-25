import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { SitesService } from '../../services/sites.service';
import { environment } from '../../../environments/environment';
import { SpinnerloadingService } from '../../shared/services/spinnerloading.service';

@Component({
  selector: 'app-create-visitors-counter',
  templateUrl: './create-visitors-counter.component.html',
  styleUrls: ['./create-visitors-counter.component.css'],
  standalone: false
})
export class CreateVisitorsCounterComponent implements OnInit {
  codeToCopy: string = '';
  showCodeSection: boolean = false;
  copied: boolean = false;

  constructor(private toastrService: ToastrService,
              private sitesService: SitesService) { }

  ngOnInit(): void { }

  createNewSite() {
    this.sitesService.create().subscribe({
      next: (siteId) => {
        console.log(siteId)
        if (siteId && siteId.length > 0) {
          this.codeToCopy = `<a href="${environment.ui_URL}${siteId}" target="_blank">`;
          this.codeToCopy += `Show`
          this.codeToCopy += `</a>`

          this.showCodeSection = true;
        }
      }
    });
  }

  copyToClipboard(): void {
    // Use Clipboard API to write text to the clipboard
    navigator.clipboard.writeText(this.codeToCopy).then(() => {
      this.copied = true; // Update state to copied
    }).catch(err => {
      this.toastrService.error("Failed to copy text")
    });
  }
}
