# SavaAPI - SLO

SavaAPI je preprost API, ki omogoča upravljanje zahtevkov s pomočjo osnovnih CRUD operacij. Uporablja pomnilniško shranjevanje podatkov (InMemory Entity Framework)in je izdelan z uporabo .NET 8 in Clean arhitekture.

## Funkcionalnosti:
- **Kreiranje zahtevkov**: Dodajanje novih zahtevkov v sistem.
- **Branje zahtevkov**: Pridobivanje obstoječih zahtevkov.
- **Branje specifičnih zahtevkov**: Pridobivanje podatko specifičnih zahtevkov.
- **Posodabljanje zahtevkov**: Spreminjanje obstoječih zahtevkov.
- **Brisanje zahtevkov**: Odstranjevanje zahtevkov iz sistema.

## Zasnova:
- **Baza podatkov**: Uporablja se shranjevanje podatkov v pomnilniku (InMemory Entity Framework). Podatki so na voljo samo med izvajanjem aplikacije, po njenem izklopu so izgubljeni.

## Začetek uporabe:
1. Klonirajte repozitorij.
2. Odprite rešitev SavaAPI.sln s programom Visual Studio.
3. Kot zagonski projekt naj bo nastavlje SavaAPI
4. Zgradite in zaženite aplikacijo.

## Testiranje:
Projekt vključuje unit teste, ki preverjajo osnovne funkcionalnosti API-ja. Testi se nahajajo v projektu `SavaAPI-Test`. 

Testi se lahko zaženejo tako, da izberete projekt SavaAPI, kliknete z desnim klikom in izberete opcijo 'Run Tests', ali pa z uporabo funkcionalnost 'Test Explorer'.

## Tehnologije:
- **ASP.NET 8**
- **Entity Framework Core**
- **InMemory Database**

---


# SavaAPI - ENG

SavaAPI is a simple API that allows managing tasks through basic CRUD operations. It InMemory Entity Framework and is built with .NET 8 and Clean Architecture.

## Features:
- **Create requests**: Add new requests to the system.
- **Read requests**: Retrieve existing requests.
- **Read specific requests**: Get details of specific requests.
- **Update requests**: Modify existing requests.
- **Delete requests**: Remove requests from the system.

## Architecture:
- **Database**: he application uses InMemory Entity Framework for data storage. Data is available only during the application runtime and is cleared when the application is closed.

## Getting Started:
1. Clone the repository.
2. Open the solution `SavaAPI.sln` in Visual Studio.
3. Set `SavaAPI` as the startup project.
4. Build and run the application.

## Testing:
The project includes unit tests to check basic API functionality. The tests are located in the `SavaAPI-Test` project.

Tests can be run by right-clicking the `SavaAPI` project and selecting 'Run Tests', or by using the 'Test Explorer' functionality.

## Technologies:
- **ASP.NET 8**
- **Entity Framework Core**
- **InMemory Database******
