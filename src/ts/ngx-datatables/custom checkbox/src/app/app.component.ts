import { Component } from '@angular/core';

@Component({
  selector: 'my-app',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  name = 'ngx-datatable';
  public rows: any[] = [];
  public selected: any[] = [];
  public isLoading = false;

  public messageTable = {
    emptyMessage: 'No data to display',
    totalMessage: 'total',
    selectedMessage: 'selected'
  }

  public pagination = {
    total_record: 14,
    page_number: 0,
    page_size: 5,
  }

  constructor() {
    [...Array(10).keys()].forEach((f, i) => {
      this.rows.push({ id: i, site_code: 'site_code_' + i })
    })
  }


  public onCheckboxChange(event: any, row: any): void {
    if (this.getChecked(row) === false) {
      this.selected.push(row);
    } else {
      for (let i = 0; i < this.selected.length; i++) {
        if (this.selected[i].id === row.id) {
          this.selected.splice(i, 1);
          break;
        }
      }
    }
  }

  public getChecked(row: any): boolean {
    const item = this.selected.filter((e) => e.id === row.id);
    return item.length > 0 ? true : false;
  }

  public getHeaderChecked(): boolean {
    const selectedIds = new Set(this.selected.map(item => item.id));
    return this.rows.every(item => selectedIds.has(item.id));
  }

}
