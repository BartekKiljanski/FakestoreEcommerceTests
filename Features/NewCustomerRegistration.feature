

    # language: pl
Właściwość: Rejestracja Nowego Klienta

    @smoke
    Scenariusz: Rejestracja Nowego Klienta
        Zakładając, że znajduje się na stronie FakeStore
        Kiedy wybieram "Moje konto"
        I Podaję przy rejestracji losowy email
        Oraz Wybieram pole "password" i <hasło>
        I wybieram "Zarejestruj się"
        

    Przykłady:
           | hasło             |
           | Haslo.1234!       |
           | Haslo.4567!       |
           | Haslo.7890!       |
