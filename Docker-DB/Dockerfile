FROM postgres:latest
COPY projeto_bloco_db.sql /docker-entrypoint-initdb.d/projeto_bloco_db.sql

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD 123456
ENV POSTGRES_DB projeto_bloco

EXPOSE 5432