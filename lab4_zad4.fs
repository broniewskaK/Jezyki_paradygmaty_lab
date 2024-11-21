open System
open System.Collections.Generic

// rekord konto bankowe
type Account = {
    AccountNumber: string
    mutable Balance: decimal
}

// Mapa do przechowywania kont
let accounts = new Dictionary<string, Account>()

// Funkcja tworzenia nowego konta
let createAccount() =
    printfn "Podaj numer konta:"
    let accountNumber = Console.ReadLine()
    if accounts.ContainsKey(accountNumber) then
        printfn "Konto z tym numerem już istnieje."
    else
        accounts.Add(accountNumber, { AccountNumber = accountNumber; Balance = 0m })
        printfn "Konto zostało utworzone."

// Funkcja depozytowania środków
let depositFunds() =
    printfn "Podaj numer konta:"
    let accountNumber = Console.ReadLine()
    if accounts.ContainsKey(accountNumber) then
        printfn "Podaj kwotę depozytu:"
        let amount = Decimal.Parse(Console.ReadLine())
        if amount > 0m then
            accounts.[accountNumber].Balance <- accounts.[accountNumber].Balance + amount
            printfn "Dodano %M do konta. Nowe saldo: %M" amount accounts.[accountNumber].Balance
        else
            printfn "Kwota depozytu musi być większa od zera."
    else
        printfn "Nie znaleziono konta o podanym numerze."

// Funkcja wypłacania środków
let withdrawFunds() =
    printfn "Podaj numer konta:"
    let accountNumber = Console.ReadLine()
    if accounts.ContainsKey(accountNumber) then
        printfn "Podaj kwotę wypłaty:"
        let amount = Decimal.Parse(Console.ReadLine())
        if amount > 0m then
            if accounts.[accountNumber].Balance >= amount then
                accounts.[accountNumber].Balance <- accounts.[accountNumber].Balance - amount
                printfn "Wypłacono %M z konta. Nowe saldo: %M" amount accounts.[accountNumber].Balance
            else
                printfn "Brak wystarczających środków na koncie."
        else
            printfn "Kwota wypłaty musi być większa od zera."
    else
        printfn "Nie znaleziono konta o podanym numerze."

// Funkcja wyświetlania salda konta
let displayBalance() =
    printfn "Podaj numer konta:"
    let accountNumber = Console.ReadLine()
    if accounts.ContainsKey(accountNumber) then
        printfn "Saldo konta %s wynosi: %M" accountNumber accounts.[accountNumber].Balance
    else
        printfn "Nie znaleziono konta o podanym numerze."

// interakcja z użytkownikiem
let rec menu() =
    printfn "1. Utwórz konto"
    printfn "2. Depozytuj środki"
    printfn "3. Wypłać środki"
    printfn "4. Wyświetl saldo"
    printfn "5. Wyjdź"
    printf "Wybierz opcję: "
    match Console.ReadLine() with
    | "1" -> createAccount(); menu()
    | "2" -> depositFunds(); menu()
    | "3" -> withdrawFunds(); menu()
    | "4" -> displayBalance(); menu()
    | "5" -> printfn "Do widzenia!"
    | _ -> printfn "Nieprawidłowy wybór, spróbuj ponownie."; menu()

// Uruchomienie aplikacji
[<EntryPoint>]
let main _ =
    
    menu()
    0
