open System

// Struktura listy łączonej
type LinkedList<'T> =
    | Empty
    | Node of 'T * LinkedList<'T>

module LinkedListModule =
    // Tworzenie listy na podstawie zwykłej listy
    let rec fromList lst =
        match lst with
        | [] -> Empty
        | x::xs -> Node(x, fromList xs)

    // Wyświetlanie elementów listy
    let rec printList lst =
        match lst with
        | Empty -> ()
        | Node(value, next) ->
            printf "%A " value
            printList next

    // Sumowanie elementów listy
    let rec sumList lst =
        match lst with
        | Empty -> 0
        | Node(value, next) -> value + sumList next

    // Odwracanie listy
    let rec reverse lst =
        let rec helper acc lst =
            match lst with
            | Empty -> acc
            | Node(value, next) -> helper (Node(value, acc)) next
        helper Empty lst

    // Sprawdzanie obecności elementu
    let rec contains value lst =
        match lst with
        | Empty -> false
        | Node(v, next) -> if v = value then true else contains value next

    // Znajdowanie indeksu elementu
    let rec findIndex value lst idx =
        match lst with
        | Empty -> None
        | Node(v, next) -> if v = value then Some idx else findIndex value next (idx + 1)

    // Zliczanie wystąpień elementu
    let rec countOccurrences value lst =
        match lst with
        | Empty -> 0
        | Node(v, next) -> (if v = value then 1 else 0) + countOccurrences value next

// Program główny
module Program =
    let displayMenu() =
        printfn "\n1. Dodaj listę"
        printfn "2. Wyświetl listę"
        printfn "3. Oblicz sumę"
        printfn "4. Odwróć listę"
        printfn "5. Sprawdź obecność elementu"
        printfn "6. Znajdź indeks elementu"
        printfn "7. Zlicz wystąpienia elementu"
        printfn "0. Wyjdź"
        printf "Wybór: "
        Console.ReadLine() |> int

    let rec mainLoop userList =
        match displayMenu() with
        | 1 ->
            printf "Podaj elementy listy oddzielone spacją: "
            let input = Console.ReadLine().Split(' ') |> Array.map int |> Array.toList
            let newList = LinkedListModule.fromList input
            printfn "Lista została dodana."
            mainLoop newList
        | 2 ->
            printf "Lista: "
            LinkedListModule.printList userList
            printfn ""
            mainLoop userList
        | 3 ->
            let sum = LinkedListModule.sumList userList
            printfn "Suma wartości elementów z listy: %d" sum
            mainLoop userList
        | 4 ->
            let reversed = LinkedListModule.reverse userList
            printf "Odwrócona lista: "
            LinkedListModule.printList reversed
            printfn ""
            mainLoop reversed
        | 5 ->
            printf "Podaj liczbę do sprawdzenia: "
            let value = Console.ReadLine() |> int
            let exists = LinkedListModule.contains value userList
            if exists then
                printfn "Element %d znajduje się w liście." value
            else
                printfn "Element %d nie znajduje się w liście." value
            mainLoop userList
        | 6 ->
            printf "Podaj liczbę do znalezienia: "
            let value = Console.ReadLine() |> int
            match LinkedListModule.findIndex value userList 0 with
            | Some idx -> printfn "Element %d znajduje się na indeksie: %d" value idx
            | None -> printfn "Element %d nie istnieje w liście." value
            mainLoop userList
        | 7 ->
            printf "Podaj liczbę do policzenia: "
            let value = Console.ReadLine() |> int
            let count = LinkedListModule.countOccurrences value userList
            printfn "Liczba wystąpień %d: %d" value count
            mainLoop userList
        | 0 ->
            printfn "Zamykanie programu..."
        | _ ->
            printfn "Niepoprawna opcja, spróbuj ponownie."
            mainLoop userList

    [<EntryPoint>]
    let main argv =
        let userList = Empty
        mainLoop userList
        0
