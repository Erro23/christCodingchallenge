import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ArticleAttribute } from 'src/interfaces/attribute';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  constructor(private readonly httpClient: HttpClient) { }

  public getArticles$(): Observable<Array<ArticleAttribute>> {
    console.log('getArticles');
    return this.httpClient.get<Array<ArticleAttribute>>('http://localhost:5000/articles');
  }
}
