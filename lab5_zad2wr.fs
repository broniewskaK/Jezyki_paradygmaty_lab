type BinaryTree <'T> =
    | Empty
    | Node of 'T * BinaryTree<'T> * BinaryTree<'T>



let rec searchTree value tree =
    match tree with
        | Empty -> false
        | Node (v, left, right) -> 
            if v = value then true
            else searchTree value left || searchTree value right
     




     
let tree = Node(10, 

    Node(5,
        Node(1,Empty,Empty),
        Node(18,Empty,Empty)), 


    Node(7,
        Node(51,Empty,Empty),
        Node(3,Empty,Empty)))



open System 

printfn "Podaj wartość:"
let input = Console.ReadLine()
let value = Int32.Parse(input)
let result = searchTree value tree
if result = true then
    printfn "Wartość %d została znaleziona w drzewie" value
else 
    printfn "Wartość %d nie została znaleziona w drzewie" value 