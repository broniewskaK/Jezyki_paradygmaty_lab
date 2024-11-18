import os

class Employee:
    def __init__(self, name: str, age: int, salary: float):
        self.name = name
        self.age = age
        self.salary = salary

    def get_info(self):
        # zwracanie info o pracowniku
        return f"Pracownik: {self.name}, Wiek: {self.age}, Wynagrodzenie: {self.salary:.2f} zł"

    def to_str(self):
        #Zamienia obiekt pracownika na tekst
        return f"{self.name},{self.age},{self.salary:.2f}"

    @staticmethod
    def from_str(data: str):

        name, age, salary = data.split(',')
        return Employee(name.strip(), int(age.strip()), float(salary.strip()))

class EmployeesManager:
    #Zarządza listą pracowników i zapisuje dane w pliku txt
    def __init__(self, data_file="employees.txt"):
        self.data_file = data_file
        self.employees = self.load_employees()

    def load_employees(self):
        # ładowanie pracownikow z pliku
        if os.path.exists(self.data_file):
            with open(self.data_file, "r", encoding="utf-8") as file:
                data = file.readlines()
                return [Employee.from_str(emp.strip()) for emp in data if emp.strip()]
        return []

    def save_employees(self):
        # zapis do pliku
        with open(self.data_file, "w", encoding="utf-8") as file:
            for employee in self.employees:
                file.write(employee.to_str() + "\n")

    def add_employee(self, employee: Employee):
        # dodanie pracownika do listy
        self.employees.append(employee)
        self.save_employees()
        print(f"Pracownik {employee.name} został dodany do listy.")

    def view_employees(self):
        # wyswietlanie listy pracownikow
        if not self.employees:
            print("Lista pracowników jest pusta.")
        else:
            for employee in self.employees:
                print(employee.get_info())

    def remove_employees_by_age_range(self, min_age: int, max_age: int):
        """Usuwa pracowników w określonym przedziale wiekowym."""
        initial_count = len(self.employees)
        self.employees = [
            employee for employee in self.employees
            if not (min_age <= employee.age <= max_age)
        ]
        self.save_employees()
        removed_count = initial_count - len(self.employees)
        print(f"Usunięto {removed_count} pracowników w wieku od {min_age} do {max_age} lat.")

    def update_salary_by_name(self, name: str, new_salary: float):
        #aktualizacja wynagrodzenia na podstawie name
        for employee in self.employees:
            if employee.name == name:
                old_salary = employee.salary
                employee.salary = new_salary
                self.save_employees()
                print(f"Wynagrodzenie pracownika {name} zostało zaktualizowane z {old_salary:.2f} zł na {new_salary:.2f} zł.")
                return
        print(f"Nie znaleziono pracownika o imieniu i nazwisku: {name}.")

class FrontendManager:
    def __init__(self):
        self.manager = EmployeesManager()

    def login(self):
        #logowanie
        username = input("Podaj nazwę użytkownika: ")
        password = input("Podaj hasło: ")

        if username == "admin" and password == "admin":
            print("Logowanie udane")
            return True
        else:
            print("Błędne dane logowania")
            return False

    def start(self):
        if not self.login():
            print("Zbyt wiele nieudanych prób logowania. Program zakończony.")
            return

        while True:
            print("1. Dodaj pracownika")
            print("2. Wyświetl listę pracowników")
            print("3. Usuń pracowników na podstawie przedziału wiekowego")
            print("4. Zaktualizuj wynagrodzenie pracownika")
            print("5. Zakończ")
            choice = input("Wybierz opcję: ")

            if choice == "1":
                name = input("Podaj imię i nazwisko: ")
                age = int(input("Podaj wiek: "))
                salary = float(input("Podaj wynagrodzenie: "))

                # Walidacja danych
                if age < 18 or salary < 0:
                    print("Błąd: Wiek pracownika musi wynosić co najmniej 18 lat, a wynagrodzenie nie może być ujemne.")
                    continue

                employee = Employee(name, age, salary)
                self.manager.add_employee(employee)

            elif choice == "2":
                self.manager.view_employees()

            elif choice == "3":
                min_age = int(input("Podaj minimalny wiek: "))
                max_age = int(input("Podaj maksymalny wiek: "))
                self.manager.remove_employees_by_age_range(min_age, max_age)

            elif choice == "4":
                name = input("Podaj imię i nazwisko pracownika: ")
                new_salary = float(input("Podaj nowe wynagrodzenie: "))
                self.manager.update_salary_by_name(name, new_salary)

            elif choice == "5":
                print("Zakończono program")
                break

            else:
                print("Nieprawidłowa opcja. Spróbuj ponownie.")

if __name__ == "__main__":
    frontend = FrontendManager()
    frontend.start()
