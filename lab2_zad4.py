from functools import reduce
import numpy as np

def get_matrices():
    #Pobiera listę macierzy od użytkownika
    matrices = []
    print("Wprowadź macierze . Wpisz 'x', aby zakończyć wprowadzanie macierzy.")
    while True:
        user_input = input("Podaj macierz (np. [[1, 2], [3, 4]]): ")
        if user_input.lower() == 'x':
            break
        try:
            # Konwersja wejścia do numpy array
            matrix = np.array(eval(user_input))
            if isinstance(matrix, np.ndarray):
                matrices.append(matrix)
            else:
                print("Podano nieprawidłowy format macierzy. Spróbuj ponownie.")
        except Exception as e:
            print(f"Błąd podczas wprowadzania macierzy: {e}. Spróbuj ponownie.")
    return matrices

def perform_operation(matrices, operation):

    # wykonuje operację na macierzach za pomocą reduce() i eval().

    try:
        # sprawdzenie, czy macierze są zgodne wymiarowo
        shapes = [mat.shape for mat in matrices]
        if not all(s == shapes[0] for s in shapes) and operation in ["x + y", "x - y"]:
            print("Macierze muszą mieć takie same wymiary dla operacji dodawania lub odejmowania.")
            return None

        # użycie reduce do zastosowania operacji na liście macierzy
        result = reduce(lambda x, y: eval(operation), matrices)
        return result
    except Exception as e:
        print(f"Błąd podczas wykonywania operacji: {e}")
        return None

def main():
    matrices = get_matrices()
    if not matrices:
        print("Brak wprowadzonych macierzy. Program zakończony.")
        return

    print("\nPodaj operację na macierzach (np. 'x+y' , 'x@y' , 'x-y':")
    operation = input("Operacja (użyj 'x' i 'y' jako zmienne): ")

    result = perform_operation(matrices, operation)
    if result is not None:
        print("\nWynik operacji:")
        print(result)

if __name__ == "__main__":
    main()
