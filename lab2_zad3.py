def extract_numbers(item):
    # funkcja do szukania liczb w obiektach wewnętrznych
    if isinstance(item, (int, float)):  # sprawdzenie czy jest to liczba
        return [item]
    elif isinstance(item, (tuple, list)):
        # wyciaganie liczb dla krotek i list
        return [num for subitem in item for num in extract_numbers(subitem)]
    elif isinstance(item, dict):
        # dla słowników przeszukiwanie po kluczach i wartosściach
        numbers_from_keys = [num for key in item.keys() for num in extract_numbers(key)]
        numbers_from_values = [num for value in item.values() for num in extract_numbers(value)]
        return numbers_from_keys + numbers_from_values  # połączenie wynikow w listę
    return []  # zwraca pustą listę, jeśli item nie jest liczbą, krotką, listą ani słownikiem

def analyze_data(data):
    # szukanie największej wartości
    numbers_from_data = list(filter(lambda x: isinstance(x, (int, float)), data))
    numbers_from_tuples = sum(map(extract_numbers, data), [])  # z krotek
    all_numbers = numbers_from_data + numbers_from_tuples  # łączenie wszystkich liczb
    max_number = max(all_numbers) if all_numbers else None  # największa liczba

    strings = list(filter(lambda x: isinstance(x, str), data))
    longest_string = max(strings, key=len) if strings else None  # szukanie najdłuższego napisu

    tuples = list(filter(lambda x: isinstance(x, tuple), data))
    largest_tuple = max(tuples, key=len) if tuples else None  # szukanie krotki z największą liczbą elementów

    return max_number, longest_string, largest_tuple


if __name__ == "__main__":
    data = [
         "tekst", 3.14, "konstantynopolitańczykowianeczka",
        "aaaaaaaaaaa", {"key": "value"}, [1, 2, 3, 23244], 100, (1, 2, 3, 4), -50, {'klucz': 8888888}
    ]

    max_num, longest_str, largest_tup = analyze_data(data)

    print(f"Największa liczba: {max_num}")
    print(f"Najdłuższy napis: '{longest_str}'")
    print(f"Krotka o największej liczbie elementów: {largest_tup}")
