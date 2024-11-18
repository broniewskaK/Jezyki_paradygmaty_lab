class Employee:
    def __init__(self, name: str, age: int, salary: float):
        self.name = name
        self.age = age
        self.salary = salary

    def get_info(self):
        return f"Pracownik: {self.name}, Wiek: {self.age}, Wynagrodzenie: {self.salary:.2f} zł"

class EmployeesManager:
    # zarzadzanie pracownikami
    def __init__(self):
        self.employees = []

    def add_employee(self, employee: Employee):
        # dodaje pracownika
        self.employees.append(employee)
        print(f"Pracownik {employee.name} został dodany do listy.")

    def view_employees(self):
        # wyświetla pracowników
        if not self.employees:
            print("Lista pracowników jest pusta.")
        else:
            for employee in self.employees:
                print(employee.get_info())

    def remove_employees_by_age_range(self, min_age: int, max_age: int):
        # usuwanie pracownikow w odpowiednim przedziale wiekowym
        initial_count = len(self.employees)
        self.employees = [
            employee for employee in self.employees
            if not (min_age <= employee.age <= max_age)
        ]
        removed_count = initial_count - len(self.employees)
        print(f"Usunięto {removed_count} pracowników w wieku od {min_age} do {max_age} lat.")

    def update_salary_by_name(self, name: str, new_salary: float):
        # aktualizacja wynagordzenia na podstawie name
        for employee in self.employees:
            if employee.name == name:
                old_salary = employee.salary
                employee.salary = new_salary
                print(f"Wynagrodzenie pracownika {name} zostało zaktualizowane z {old_salary:.2f} zł na {new_salary:.2f} zł.")
                return
        print(f"Nie znaleziono pracownika o imieniu i nazwisku: {name}.")

class FrontendManager:
    #interfejs użytkownika do zarządzania pracownikami
    def __init__(self):
        self.manager = EmployeesManager()

    def start(self):
        #menu
        while True:
            print("1. Dodaj pracownika")
            print("2. Wyświetl listę pracowników")
            print("3. Usuń pracowników na podstawie przedziału wiekowego")
            print("4. Zaktualizuj wynagrodzenie pracownika")
            print("5. Koniec")
            choice = input("Wybierz opcję: ")

            if choice == "1":
                name = input("Podaj imię i nazwisko: ")
                age = int(input("Podaj wiek: "))
                salary = float(input("Podaj wynagrodzenie: "))
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
                print("Dziękujemy za korzystanie z systemu!")
                break

            else:
                print("Nieprawidłowa opcja. Spróbuj ponownie.")
if __name__ == "__main__":
    frontend = FrontendManager()
    frontend.start()
