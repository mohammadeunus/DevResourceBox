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
    debugger
    if (this.getChecked(row) === false) {
      // add
      this.selected.push(row);
    } else {
      // remove
      for (let i = 0; i < this.selected.length; i++) {
        if (this.selected[i].id === row.id && this.selected[i].site_code === row.site_code) {
          this.selected.splice(i, 1);
          break;
        }
      }
    }
  }

  public getChecked(row: any): boolean {
    const item = this.selected.filter((e) => e.id === row.id && e.site_code === row.site_code);
    return item.length > 0 ? true : false;
  }

  onSelectRow(data) {
    this.selected = data.selected
  }

}
