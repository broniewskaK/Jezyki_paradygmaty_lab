
// iteracyjna Hanoi bez stosu
let hanoiIterative n source target auxiliary =
    let moves = pown 2 n - 1
    let rods = [|source; auxiliary; target|]
    for i in 1..moves do
        let fromRod = (i &&& (i - 1)) % 3
        let toRod = ((i ||| (i - 1)) + 1) % 3
        printfn "Przenieś dysk z %s do %s" rods.[fromRod] rods.[toRod]


printfn "\nIteracyjne rozwiązanie problemu wież Hanoi dla 3 dysków:"
hanoiIterative 3 "A" "C" "B"