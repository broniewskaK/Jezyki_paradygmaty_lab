open System
open System.Text.RegularExpressions

let countWords (text: string) =
    let words = text.Split([| ' '; '\t'; '\n'; '\r' |], StringSplitOptions.RemoveEmptyEntries)
    words.Length

let countCharacters (text: string) =
    text |> Seq.filter (fun c -> not (Char.IsWhiteSpace(c))) |> Seq.length

let mostFrequentWord (text: string) =
    let words = 
        Regex.Matches(text, @"\b\w+\b")
        |> Seq.cast<Match> //  rzutuje wyniki na `Match`
        |> Seq.map (fun m -> m.Value) 
        |> Seq.toList

    let wordCounts = 
        words 
        |> List.groupBy id 
        |> List.map (fun (word, instances) -> word, List.length instances)
        |> List.sortByDescending snd

    match wordCounts with
    | (word, count) :: _ -> Some(word, count)
    | [] -> None

[<EntryPoint>]
let main argv =
    // Wy�wietlanie informacji i wczytanie danych
    printfn "Podaj tekst:"
    let inputText = Console.ReadLine()

    if String.IsNullOrWhiteSpace(inputText) then
        printfn "Nie podano tekstu."
    else
        let wordCount = countWords inputText
        let charCount = countCharacters inputText
        let mostFrequent = mostFrequentWord inputText

        // Wy�wietlenie wynik�w
        printfn "Liczba s��w: %d" wordCount
        printfn "Liczba znak�w (bez spacji): %d" charCount

        match mostFrequent with
        | Some(word, count) ->
            printfn "Najcz�ciej wyst�puj�ce s�owo: '%s' (wyst�puje %d razy)" word count
        | None ->
            printfn "Nie znaleziono s��w w podanym tek�cie."

  
