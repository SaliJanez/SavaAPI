# SavaAPI

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
3. Kot zagonski projekt naj bo nastavljen SavaAPI.
4. Zgradite in zaženite aplikacijo.

## Testiranje:
Projekt vključuje unit teste, ki preverjajo osnovne funkcionalnosti API-ja. Testi se nahajajo v projektu `SavaAPI-Test`. 

Testi se lahko zaženejo tako, da izberete projekt SavaAPI, kliknete z desnim klikom in izberete opcijo 'Run Tests', ali pa z uporabo funkcionalnost 'Test Explorer'.

## Tehnologije:
- **ASP.NET 8**
- **Entity Framework Core**
- **InMemory Database**