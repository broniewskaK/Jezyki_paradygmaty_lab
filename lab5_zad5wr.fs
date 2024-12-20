
// Funkcja rekurencyjna QuickSort
let rec quickSortRecursive list =
    match list with
    | [] -> []
    | pivot :: tail ->
        let smaller = List.filter (fun x -> x <= pivot) tail
        let greater = List.filter (fun x -> x > pivot) tail
        (quickSortRecursive smaller) @ [pivot] @ (quickSortRecursive greater)

let unsortedList = [89999; 6; 8; 10; 1; 87; 1]

let sortedRecursive = quickSortRecursive unsortedList
printfn "Posortowana lista rekurencyjnie: %A" sortedRecursive