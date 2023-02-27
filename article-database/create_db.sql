CREATE DATABASE IF NOT EXISTS article;

USE article;

CREATE TABLE IF NOT EXISTS articles (
  articleId INT NOT NULL,
  articleKey VARCHAR(255),
  source VARCHAR(255),
  articleValue VARCHAR(255),
  label VARCHAR(255),
  language VARCHAR(255),
  PRIMARY KEY (articleId)
);