open System

// do przechowywania danych u¿ytkownika
type UserData = {
    Weight: float
    Height: float
}

// Funkcja do obliczania BMI
let calculateBMI (weight: float) (height: float) : float =
    weight / ((height / 100.0) ** 2.0)

// Funkcja do okreœlania kategorii BMI
let categorizeBMI (bmi: float) : string =
    if bmi < 18.5 then "Niedowaga"
    elif bmi < 24.9 then "Waga prawid³owa"
    elif bmi < 29.9 then "Nadwaga"
    else "Oty³oœæ"

// g³ówna funkcja programu
[<EntryPoint>]
let main argv =
    // do uzytkownika
    printfn "Podaj swoj¹ wagê w kg:"
    let weightInput = Console.ReadLine()
    
    printfn "Podaj swój wzrost w cm:"
    let heightInput = Console.ReadLine()

    // konwersja danych wejœciowych z string na float
    match (System.Double.TryParse(weightInput), System.Double.TryParse(heightInput)) with
    | (true, weight), (true, height) when weight > 0.0 && height > 0.0 ->
        // Tworzenie rekordu z danymi u¿ytkownika
        let userData = { Weight = weight; Height = height }
        
        // Obliczanie BMI
        let bmi = calculateBMI userData.Weight userData.Height
        
        // Okreœlenie kategorii BMI
        let category = categorizeBMI bmi
        
        //Wyœwietlenie wyniku
        printfn "Twoje BMI wynosi: %.2f" bmi
        printfn "Kategoria BMI: %s" category
    | _ ->
        // Obs³uga b³êdnych danych wejœciowych
        printfn "Podano nieprawid³owe dane. Proszê wprowadziæ poprawne wartoœci liczbowe dla wagi i wzrostu."
    
    0 // Kod zakoñczenia programu
