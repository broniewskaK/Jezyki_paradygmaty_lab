import numpy as np

# słownik do przechowywania macierzy
matrices = {}


def add_matrix(name, matrix):
    # dodaje macierz do słownika.
    matrices[name] = np.array(matrix)


def validate_addition(matrix1, matrix2):
    # sprawdzenie czy mozna dodac macierze czy jest ten sam wymiar, shape to wymiar macierzy z numpy np. (2,2)
    return matrix1.shape == matrix2.shape


def validate_multiplication(matrix1, matrix2):
    # sprawdzenie warunku na mnożenie czy liczba kolumn w pierwszej macierzy jest równa liczbie wierzy w drugiej
    return matrix1.shape[1] == matrix2.shape[0]


def add(name1, name2):
    # dodawanie macierzy
    matrix1 = matrices[name1]
    matrix2 = matrices[name2]

    if validate_addition(matrix1, matrix2):
        return matrix1 + matrix2
    else:
        raise ValueError("błędne wymiary macierzy - nie można dodać")


def multiply(name1, name2):
    # mnożenie macierzy
    matrix1 = matrices[name1]
    matrix2 = matrices[name2]

    if validate_multiplication(matrix1, matrix2):
        return matrix1 @ matrix2
    else:
        raise ValueError("błędne wymiary macierzy - nie można pomnożyć")


def transpose(name):
    # transponowanie
    matrix = matrices[name]
    return matrix.T  # z numpy


def execute_operations(name1, name2):
    # wykonywanie operacji
    try:
        matrix1 = matrices[name1]
        matrix2 = matrices[name2]

        # transponowanie
        transposed_matrix1 = transpose(name1)
        transposed_matrix2 = transpose(name2)

        # dodawanie i mnożenie
        addition_result = add(name1, name2)
        multiplication_result = multiply(name1, name2)

        return {
            "matrix1": matrix1,
            "matrix2": matrix2,
            "transposed_matrix1": transposed_matrix1,
            "transposed_matrix2": transposed_matrix2,
            "addition_result": addition_result,
            "multiplication_result": multiplication_result
        }
    except Exception as e:
        print(f"Błąd: {e}")


if __name__ == "__main__":
    add_matrix("A", [[1, 2], [3, 4]])
    add_matrix("B", [[4, 1], [2, 4]])

    results = execute_operations("A", "B")

    print("Macierz A\n", results["matrix1"])
    print("Macierz B\n", results["matrix2"])
    print("Transponowana A\n", results["transposed_matrix1"])
    print("Transponowana B\n", results["transposed_matrix2"])
    print(" A + B\n", results["addition_result"])
    print(" A * B\n", results["multiplication_result"])
