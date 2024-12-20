let quickSortIterative (input: 'a list) =
    let arr = input |> List.toArray

    let swap i j =
        let tmp = arr.[i]
        arr.[i] <- arr.[j]
        arr.[j] <- tmp

    let partition (low:int) (high:int) =
        // wybieram pivot jako ostatni element
        let pivot = arr.[high]
        let mutable i = low - 1
        for j in low .. high - 1 do
            if arr.[j] <= pivot then
                i <- i + 1
                swap i j
        swap (i + 1) high
        i + 1

    // stos do przechowywania zakresów (low, high)
    let stack = System.Collections.Generic.Stack<int>()
    stack.Push(0)
    stack.Push(arr.Length - 1)

    while stack.Count > 0 do
        let high = stack.Pop()
        let low = stack.Pop()

        if low < high then
            let p = partition low high

            // lewy przedział
            if p - 1 > low then
                stack.Push(low)
                stack.Push(p - 1)

            // prawy 
            if p + 1 < high then
                stack.Push(p + 1)
                stack.Push(high)

    arr |> Array.toList


let unsortedList = [6778; 6; 8; 10; 1; 2; 1]
let sortedIterative = quickSortIterative unsortedList
printfn "Posortowana lista iteracyjnie: %A" sortedIterative
 // wersja rekurencyjna o wiele krótsza i łatwiejsza do napisania