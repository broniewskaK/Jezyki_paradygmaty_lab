open System

// do przechowywania danych u�ytkownika
type UserData = {
    Weight: float
    Height: float
}

// Funkcja do obliczania BMI
let calculateBMI (weight: float) (height: float) : float =
    weight / ((height / 100.0) ** 2.0)

// Funkcja do okre�lania kategorii BMI
let categorizeBMI (bmi: float) : string =
    if bmi < 18.5 then "Niedowaga"
    elif bmi < 24.9 then "Waga prawid�owa"
    elif bmi < 29.9 then "Nadwaga"
    else "Oty�o��"

// g��wna funkcja programu
[<EntryPoint>]
let main argv =
    // do uzytkownika
    printfn "Podaj swoj� wag� w kg:"
    let weightInput = Console.ReadLine()
    
    printfn "Podaj sw�j wzrost w cm:"
    let heightInput = Console.ReadLine()

    // konwersja danych wej�ciowych z string na float
    match (System.Double.TryParse(weightInput), System.Double.TryParse(heightInput)) with
    | (true, weight), (true, height) when weight > 0.0 && height > 0.0 ->
        // Tworzenie rekordu z danymi u�ytkownika
        let userData = { Weight = weight; Height = height }
        
        // Obliczanie BMI
        let bmi = calculateBMI userData.Weight userData.Height
        
        // Okre�lenie kategorii BMI
        let category = categorizeBMI bmi
        
        //Wy�wietlenie wyniku
        printfn "Twoje BMI wynosi: %.2f" bmi
        printfn "Kategoria BMI: %s" category
    | _ ->
        // Obs�uga b��dnych danych wej�ciowych
        printfn "Podano nieprawid�owe dane. Prosz� wprowadzi� poprawne warto�ci liczbowe dla wagi i wzrostu."
    
    0 // Kod zako�czenia programu
