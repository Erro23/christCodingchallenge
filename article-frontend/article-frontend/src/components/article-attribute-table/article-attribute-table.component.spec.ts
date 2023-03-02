import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ArticleAttributeTableComponent } from './article-attribute-table.component';

describe('ArticleAttributeTableComponent', () => {
  let component: ArticleAttributeTableComponent;
  let fixture: ComponentFixture<ArticleAttributeTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ ArticleAttributeTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ArticleAttributeTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
