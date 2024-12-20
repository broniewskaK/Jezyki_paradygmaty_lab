
let rec permutations list =
    match list with
    | [] -> [[]] // jezeli lista pusta to zwróć listę pusta
    | _ -> 
        list
        |> List.collect(fun x -> 
                  permutations (List.filter ((<>) x ) list)
                  |> List.map( fun perm -> x :: perm))


let perm = permutations [1;2;3]


printfn "permutacja dla listy [1;2;3]: "

perm |> List.iter (fun item -> printfn "%A" item)