// rekurencyjna Hanoi
let rec hanoiRecursive n source target auxiliary =
    if n = 1 then
        printfn "Przenieś dysk z %s do %s" source target
    else
        hanoiRecursive (n - 1) source auxiliary target
        printfn "Przenieś dysk z %s do %s" source target
        hanoiRecursive (n - 1) auxiliary target source

printfn "Rekurencyjne rozwiązanie problemu wież Hanoi dla 3 dysków:"
hanoiRecursive 3 "A" "C" "B"