# Dockerisert Applikasjon med Nginx, .NET REST API og MySQL

Dette prosjektet demonstrerer hvordan du kan sette opp en fullstack-applikasjon ved hjelp av Docker, bestående av:

- **Nginx**: Webserver og reverse proxy.
- **.NET REST API**: Backend-applikasjon bygget med .NET Framework.
- **MySQL**: Relasjonsdatabase for lagring av data.

## Forutsetninger

Før du begynner, sørg for at du har følgende installert på systemet ditt:

- [Docker](https://docs.docker.com/get-docker/)
- [Docker Compose](https://docs.docker.com/compose/install/)



## Mapper

- `docker-compose.yml`: Definerer og konfigurerer alle tjenestene.
- `nginx/nginx.conf`: Konfigurasjonsfil for Nginx.
- `DockerRestApiMySql/`: Inneholder koden for REST API-et og nødvendige Docker-filer.

## Konfigurasjon

### Docker Compose


`docker-compose.yml` definerer tre tjenester/containere:

1. **Nginx**: Konfigurert til å lytte på port 80 og videresende forespørsler til REST API-et.
2. **REST API**: Bygget fra `DockerRestApiMySql`-katalogen og koblet til MySQL-databasen.
3. **MySQL**: Bruker offisielt MySQL 8.0-bilde og setter opp databasen `productdb`.

### Nginx

`nginx.conf` konfigurerer Nginx som en reverse proxy som videresender forespørsler til REST API-et.

### REST API

REST API-et er bygget med .NET Entity Framework og konfigurerer en tilkobling til MySQL-databasen ved hjelp av en tilkoblingsstreng definert i `appsettings.json`.

### Docker-hub repository

Docker Hub Repository
Alle Docker-images som brukes i dette prosjektet finnes her:

https://hub.docker.com/repository/docker/renatehem/dockernginx/tags
--------------------------------------------------------------------

### Bygg og kjør prosjektet, fra rootmappen der yml filen er.

1. **Start Docker**:

   ```bash
   docker-compose up -d
2. **Verifiser at tjenestene kjører**:

   ```bash
   docker-compose ps
3. **Tilgang til applikasjonen**:

Åpne postman eller ett annet api vertøy for å få tilgang til databasen.

###Endepunkt

For å hente alle produktene:
````
GET http://localhost/product
````
For å hente ett spesifikt produkt:
````
GET http://localhost/product/id
````
For å poste nye produkter:
````
POSTE http://localhost/product
````
For å oppdatere ett spesifikt produkt:
````
PUT http://localhost/product/id
````
For å slette ett spesifikt produkt:
````
DELETE http://localhost/product/id
````
## Eksempler på JSON-data.
Data som sendes til apiet for PUT skal strukturers slik
````json:
{
        "id": 4,
        "name": "Slim jacket",
        "description": "Leather",
        "price": 4990
}
````
Data for POST request struktureres slik:
````json: 
{
        "name": "Slim jacket",
        "description": "Leather",
        "price": 4990
}
````
## Database
MySQL-databasen er konfigurert med følgende miljøvariabler:

`MYSQL_ROOT_PASSWORD`: Rotpassordet for MySQL.

`MYSQL_DATABASE`: Navnet på databasen som skal opprettes (productdb).

### Merk:
Sørg for at port 80 er ledig på vertsmaskinen din før du starter tjenestene.

For å stoppe og fjerne tjenestene, kjør:

````bash
docker-compose down
````



 