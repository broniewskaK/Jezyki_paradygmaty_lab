open System

// Reprezentacja planszy jako tablica
let mutable board = Array.create 9 " "

// Funkcja wyświetlająca planszę
let printBoard() =
    printfn "\n %s | %s | %s " board.[0] board.[1] board.[2]
    printfn "---+---+---"
    printfn " %s | %s | %s " board.[3] board.[4] board.[5]
    printfn "---+---+---"
    printfn " %s | %s | %s \n" board.[6] board.[7] board.[8]

// Funkcja sprawdzająca, czy podana pozycja jest dostępna
let isPositionFree position =
    board.[position] = " "

// Funkcja umieszczająca znak na planszy
let makeMove position symbol =
    if isPositionFree position then
        board.[position] <- symbol
        true
    else
        false

// Funkcja sprawdzająca, czy jest zwycięzca
let checkWinner symbol =
    let winningCombos = [
        [0; 1; 2]; [3; 4; 5]; [6; 7; 8] // Wiersze
        [0; 3; 6]; [1; 4; 7]; [2; 5; 8] // Kolumny
        [0; 4; 8]; [2; 4; 6]            // Przekątne
    ]
    winningCombos
    |> List.exists (fun combo -> combo |> List.forall (fun index -> board.[index] = symbol))

// Funkcja sprawdzająca, czy plansza jest pełna czy jest remis
let isBoardFull() =
    board |> Array.forall (fun cell -> cell <> " ")

// Funkcjagenerująca losowy ruch komputera
let computerMove() =
    let random = Random()
    let mutable position = random.Next(0, 9)
    while not (isPositionFree position) do
        position <- random.Next(0, 9)
    makeMove position "O"

// Funkcja zarządzająca ruchem gracza
let playerMove() =
    printfn "Wybierz pozycję (0-8):"
    let mutable validMove = false
    while not validMove do
        try
            let position = int (Console.ReadLine())
            if position >= 0 && position < 9 then
                if makeMove position "X" then
                    validMove <- true
                else
                    printfn "Pozycja zajęta, wybierz inną."
            else
                printfn "Nieprawidłowa pozycja. Wprowadź liczbę od 0 do 8."
        with
        | :? FormatException -> printfn "Nieprawidłowe dane. Wprowadź liczbę od 0 do 8."

// Główna funkcja gry
let rec gameLoop() =
    printBoard()
    playerMove()
    if checkWinner "X" then
        printBoard()
        printfn "Wygrałeś!"
    elif isBoardFull() then
        printBoard()
        printfn "Remis"
    else
        computerMove() |> ignore
        if checkWinner "O" then
            printBoard()
            printfn "Przegrałeś"
        elif isBoardFull() then
            printBoard()
            printfn "Remis"
        else
            gameLoop()

// Uruchomienie gry
[<EntryPoint>]
let main _ =
    printfn "Witamy w grze Kółko i Krzyżyk!"
    printfn "Plansza ma numerację od 0 do 8, jak poniżej:"
    printfn " 0 | 1 | 2 "
    printfn "---+---+---"
    printfn " 3 | 4 | 5 "
    printfn "---+---+---"
    printfn " 6 | 7 | 8 "
    gameLoop()
    0
