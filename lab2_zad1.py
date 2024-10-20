from collections import Counter

def analyzeText(text):
    paragraphs = text.split('\n')
    sentences = text.split(".")
    words = [word.strip('.,!?()[]{};:"\'') for word in text.lower().split() if word.strip('.,!?()[]{};:"\'')]

    print(f"Liczba akapitów: {len(paragraphs)- 2}")  # odjęcie 2 bo liczy """ jako akapit na poczatku i na koncu
    print(f"Liczba zdań: {len(sentences)-1}")  # -1 bo sentences to lista elementow rozdzielonych kropka i na koncu
    # dochodzi 1 element pusty (liczy jeszcze jeden pusty element po ostatniej kropce)
    print(f"Liczba słów: {len(words)}")

    # słowa najczestrze z wykluczeniem stop words
    stop_words = {'a', 'w', 'z', 'i', 'o', 'the', 'or', 'to', ' '}
    filtered_words = filter(lambda word: word not in stop_words, words)

    word_count = Counter(filtered_words)
    most_common = word_count.most_common(5)
    print(f"Najczęstsze słowa: {most_common}")

    reverse_a_words = []

    for word in words:
        # przechodzenie po slowach i sprawdzenie czy slowo zaczyna sie na "a"
        if word == 'a':  # omijanie slowa "a"
            break
        if word.lower().startswith('a'):
            reverse_a_words.append(word[::-1])  # gdy slowo zaczyna się na "a" odwraca i  dodaje do listy

    print(f"Odwrócone słowa rozpoczynające się na 'a': {reverse_a_words}")
    # print(sentences)

text = """
        apple
        apple
        apple
        apple
        apple
        apple
        Ala ma kota
        kot ma ale.
        Nawet kawa nie pomoże
        -zimno, śnieżno jest na dworze.
        Ale trzeba jakoś wstać
        znów za bary życie brać,
        z tą nadzieją, że być może
        będzie lepiej, a nie gorzej.
        """


analyzeText(text)
