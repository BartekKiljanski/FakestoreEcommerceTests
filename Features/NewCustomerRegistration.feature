

    # language: pl
Właściwość: Rejestracja Nowego Klienta

    @smoke
    Scenariusz: Rejestracja Nowego Klienta
        Zakładając, że znajduje się na stronie FakeStore
        Kiedy wybieram "Moje konto"
        Wtedy Wyłączam link 
        I Wybieram pole "email" i wprowadzam losowy email
        Oraz Wybieram pole "new-password" i wprowadzam losowe hasło
        I wybieram "Zarejestruj się"
        Wtedy Znajduję się w edycji mojego konta i mam zakładkę "Kokpit".
        

