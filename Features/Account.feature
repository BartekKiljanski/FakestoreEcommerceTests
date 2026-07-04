# language: pl

Właściwość: Konto klienta

  @smoke
  Scenariusz: Rejestracja i ponowne logowanie nowego klienta
    Zakładając, że otwieram stronę rejestracji
    Kiedy rejestruję nowego losowego klienta
    Wtedy widzę kokpit konta klienta
    Kiedy wylogowuję klienta
    I loguję się ostatnio utworzonym klientem
    Wtedy widzę kokpit konta klienta

  @regression
  Scenariusz: Logowanie niepoprawnego klienta
    Zakładając, że otwieram stronę logowania
    Kiedy loguję się jako użytkownik "invalidUser"
    Wtedy widzę komunikat błędu logowania

  @smoke
  Scenariusz: Rejestracja nowego klienta
    Zakładając, że otwieram stronę rejestracji
    Kiedy rejestruję nowego losowego klienta
    Wtedy widzę kokpit konta klienta

  @regression
  Scenariusz: Rejestracja bez hasła
    Zakładając, że otwieram stronę rejestracji
    Kiedy próbuję zarejestrować klienta bez hasła
    Wtedy widzę walidację wymaganego hasła
