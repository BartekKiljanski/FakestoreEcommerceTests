# language: pl

Właściwość: Koszyk

  Założenia:
    Zakładając, że otwieram stronę sklepu

  @smoke
  Scenariusz: Dodanie produktu do koszyka
    Kiedy dodaję produkt "Egipt - El Gouna" do koszyka
    Wtedy widzę komunikat dodania produktu "Egipt - El Gouna"
    I produkt "Egipt - El Gouna" znajduje się w koszyku

  @regression
  Scenariusz: Zmiana ilości produktu w koszyku
    Kiedy dodaję produkt "Egipt - El Gouna" do koszyka
    I przechodzę do koszyka
    I zmieniam ilość produktu "Egipt - El Gouna" na "2"
    Wtedy produkt "Egipt - El Gouna" ma ilość "2" w koszyku

  @regression
  Scenariusz: Usunięcie produktu z koszyka
    Kiedy dodaję produkt "Egipt - El Gouna" do koszyka
    I przechodzę do koszyka
    I usuwam produkt "Egipt - El Gouna" z koszyka
    Wtedy koszyk jest pusty

  @regression
  Scenariusz: Przejście do checkoutu
    Kiedy dodaję produkt "Egipt - El Gouna" do koszyka
    I przechodzę do koszyka
    I przechodzę do zamówienia
    Wtedy widzę stronę zamówienia
