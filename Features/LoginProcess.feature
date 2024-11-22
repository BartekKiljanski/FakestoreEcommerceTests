  # language: pl

Właściwość: Logowanie na klienta

  Założenia:
    Zakładając, że znajduje się na stronie FakeStore
    Kiedy wybieram "Moje konto"
    Wtedy Wyłączam link

  @smoke
  Scenariusz: Logowanie na klienta
    Zakładając, że znajduje się na podstronie "Moje konto"
    Wtedy Wybieram pole do logowania i wprowadzam "<email>"
    Oraz Wybieram pole z hasłem i wprowadzam "<haslo>"
    I wybieram "Zaloguj się"
    Wtedy Znajduję się w edycji mojego konta i mam zakładkę "Kokpit".

    Przykłady:
      | email              | haslo            |
      | test@admin.pl      | testhaslo12345!  |
      | example@domain.com | examplepass123!  |
