type BinaryTree<'T> =
    | Empty
    | Node of 'T * BinaryTree<'T> * BinaryTree<'T>

// iteracyjna
let searchTreeIterative value tree =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: rest -> loop rest
        | Node (v, left, right) :: rest ->
            if v = value then true
            else loop (left :: right :: rest)
    loop [tree]


let tree = Node(10, 
    Node(5,
        Node(1, Empty, Empty),
        Node(18, Empty, Empty)), 
    Node(7,
        Node(51, Empty, Empty),
        Node(3, Empty, Empty)))



let testIterative2 = searchTreeIterative 5 tree
printfn "Iteracyjnie: Element 5 %s" (if testIterative2 then "znaleziony" else "nie znaleziony")
