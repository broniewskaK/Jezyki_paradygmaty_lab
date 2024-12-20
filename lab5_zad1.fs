let rec Fib n = 
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ -> Fib ( n - 1 ) + Fib(n - 2)
   
let fibResult = Fib 3

printfn "Wynik: %d" fibResult


let FibTail n =
    let rec aux n a b =
        if n<= 0 then a 
        elif n = 1 then b
        else aux (n-1) b (a+b)
    aux n 0 1