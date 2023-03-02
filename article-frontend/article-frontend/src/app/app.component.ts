import {Component, OnInit} from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ArticleService } from 'src/services/article/article.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  public readonly articlesAttributes$ = this.articleService.getArticles$();

  constructor(private readonly articleService: ArticleService){
  }
}
