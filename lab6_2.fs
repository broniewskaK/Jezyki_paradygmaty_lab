open System
open System.Collections.Generic

// Klasa reprezentująca konto bankowe
type BankAccount(accountNumber: string, initialBalance: decimal) =
    let mutable balance = initialBalance

    member this.AccountNumber = accountNumber
    member this.Balance = balance

    member this.Deposit(amount: decimal) =
        if amount <= 0m then
            raise (ArgumentException("Kwota wpłaty musi być większa od zera."))
        balance <- balance + amount

    member this.Withdraw(amount: decimal) =
        if amount <= 0m then
            raise (ArgumentException("Kwota wypłaty musi być większa od zera."))
        if amount > balance then
            raise (InvalidOperationException("Brak wystarczających środków na koncie."))
        balance <- balance - amount

// Klasa zarządzająca kontami bankowymi
type Bank() =
    let accounts = Dictionary<string, BankAccount>()

    member this.CreateAccount(accountNumber: string, initialBalance: decimal) =
        if accounts.ContainsKey(accountNumber) then
            raise (ArgumentException("Konto o podanym numerze już istnieje."))
        let account = BankAccount(accountNumber, initialBalance)
        accounts.Add(accountNumber, account)
        account

    member this.GetAccount(accountNumber: string) =
        match accounts.TryGetValue(accountNumber) with
        | true, account -> account
        | false, _ -> raise (KeyNotFoundException("Konto o podanym numerze nie istnieje."))

    member this.UpdateAccount(accountNumber: string, operation: BankAccount -> unit) =
        let account = this.GetAccount(accountNumber)
        operation(account)

    member this.DeleteAccount(accountNumber: string) =
        if not (accounts.Remove(accountNumber)) then
            raise (KeyNotFoundException("Konto o podanym numerze nie istnieje."))

// Program główny
[<EntryPoint>]
let main argv =
    let bank = Bank()

    // Tworzenie kont
    let account1 = bank.CreateAccount("12345", 1000m)
    let account2 = bank.CreateAccount("67890", 500m)
    
    printfn "Utworzono konto %s z saldem: %M" account1.AccountNumber account1.Balance
    printfn "Utworzono konto %s z saldem: %M" account2.AccountNumber account2.Balance

    // Wpłata na konto
    bank.UpdateAccount("12345", fun acc -> acc.Deposit(200m))
    printfn "Saldo konta 12345 po wpłacie: %M" (bank.GetAccount("12345").Balance)

    // Wypłata z konta
    bank.UpdateAccount("67890", fun acc -> acc.Withdraw(100m))
    printfn "Saldo konta 67890 po wypłacie: %M" (bank.GetAccount("67890").Balance)

    // Usuwanie konta
    bank.DeleteAccount("67890")
    try
        bank.GetAccount("67890") |> ignore
    with
    | :? KeyNotFoundException -> printfn "Konto 67890 zostało usunięte."

    0
