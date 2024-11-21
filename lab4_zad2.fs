open System

// kursy wymiany wzg PLN
let exchangeRates = 
    Map.ofList [
        ("USD", 4.20) // 1 USD = 4.20 PLN
        ("EUR", 4.57) // 1 EUR = 4.57 PLN
        ("GBP", 5.62) // 1 GBP = 5.62 PLN
        ("PLN", 1.0)  //  bazowa
    ]

// Funkcja obliczająca przeliczoną kwotę
let convertCurrency amount sourceCurrency targetCurrency =
    if exchangeRates.ContainsKey(sourceCurrency) && exchangeRates.ContainsKey(targetCurrency) then
        let rateSourceToPLN = exchangeRates.[sourceCurrency]
        let ratePLNToTarget = 1.0 / exchangeRates.[targetCurrency]
        let convertedAmount = amount * rateSourceToPLN * ratePLNToTarget
        Some convertedAmount
    else
        None

// Funkcja pobierająca dane od użytkownika
let rec getUserInput prompt =
    printf "%s" prompt
    Console.ReadLine()

// Główna funkcja programu
let main () =
    try
        // Pobranie danych od użytkownika
        let amount = getUserInput "Podaj kwotę do przeliczenia: " |> decimal
        let sourceCurrency = getUserInput "Podaj walutę źródłową (np. USD, EUR, GBP, PLN): "
        let targetCurrency = getUserInput "Podaj walutę docelową (np. USD, EUR, GBP, PLN): "

        //  konwersja waluty
        match convertCurrency (float amount) sourceCurrency targetCurrency with
        | Some convertedAmount ->
            printfn "Przeliczona kwota: %.2f %s" convertedAmount targetCurrency
        | None ->
            printfn "Nieobsługiwane waluty lub niepoprawne dane."
    with
    | :? FormatException ->
        printfn "Nieprawidłowy format danych. Spróbuj ponownie."


main ()
