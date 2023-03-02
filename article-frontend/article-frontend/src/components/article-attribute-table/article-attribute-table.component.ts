import { Component, Input } from '@angular/core';
import { CommonModule, NgFor } from '@angular/common';
import { ArticleAttribute } from '../../interfaces/attribute';

@Component({
  selector: 'article-attribute-table',
  templateUrl: './article-attribute-table.component.html',
  styleUrls: ['./article-attribute-table.component.scss'],
  standalone: true,
  imports: [
    CommonModule,
    NgFor
  ],
})
export class ArticleAttributeTableComponent {
  @Input()
  public articleAttributes!: Array<ArticleAttribute> | null;
}
