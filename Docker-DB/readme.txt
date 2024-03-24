DELETING
docker stop -t=0 pb-db
docker rm pb-db
docker image rm renatonhack/pb-db

-----------------------------------------------------------------------------------------------

EXPORT DB
pg_dump -U postgres -d projeto_bloco -Fp -f projeto_bloco_db.sql
(password: 123456)

-----------------------------------------------------------------------------------------------

DOCKERFILE
FROM postgres:latest
COPY projeto_bloco_db.sql /docker-entrypoint-initdb.d/projeto_bloco_db.sql

ENV POSTGRES_USER postgres
ENV POSTGRES_PASSWORD 123456
ENV POSTGRES_DB projeto_bloco

EXPOSE 5432

-----------------------------------------------------------------------------------------------

BUILD
docker build -t renatonhack/pb-db .
docker push renatonhack/pb-db

-----------------------------------------------------------------------------------------------

RUNNING
running the db: docker run --name pb-db -e POSTGRES_PASSWORD=123456 -d -p 5432:5432 renatonhack/pb-db
checking if db was successfully restored: docker exec -it pb-db psql -U postgres projeto_bloco
checking in host: psql -h localhost -p 5432 -U postgres projeto_bloco

-----------------------------------------------------------------------------------------------

CHAT GPT HISTORY
https://chat.openai.com/share/f52b8db8-f2ff-4699-86d9-0bc2b641bbc2