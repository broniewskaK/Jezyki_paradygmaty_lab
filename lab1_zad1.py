# Problem podziału paczek
def podziel_paczki(wagi, max_waga):
    wagi_sort = sorted(wagi, reverse=True)  # sortowanie paczek malejaco
    kursy = []

    for waga in wagi_sort: # iteracja po posortowanych wagach
        if waga > max_waga:
            raise ValueError(f" paczka o wadze {waga} przekracza max dozwolona wage")
        dodano = False
        for kurs in kursy:  # szukanie kursu do którego mozna dodac paczke
            if sum(kurs) + waga <= max_waga:
                kurs.append(waga)  # dodanie do kursu wagi
                dodano = True
                break
        if not dodano:
            kursy.append([waga])
    return len(kursy), kursy


if __name__ == "__main__":
    wagi = [5, 5, 1]
    max_waga = 10
    liczba_kursow, kursy = podziel_paczki(wagi, max_waga)
    print(f"liczba kursów: {liczba_kursow}")
    for i, kurs in enumerate(kursy,1):
        print(f"Kurs {i}: {kurs} - suma wag: {sum(kurs)} kg")
