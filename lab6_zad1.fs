open System

// Klasa reprezentująca książkę
 type Book(title: string, author: string, pages: int) =
     member this.Title = title
     member this.Author = author
     member this.Pages = pages
     member this.GetInfo() = sprintf "'%s' autorstwa %s, %d stron" this.Title this.Author this.Pages

// Klasa reprezentująca użytkownika biblioteki
type User(name: string) =
    let mutable borrowedBooks = []
    member this.Name = name
    member this.BorrowBook(book: Book) =
        borrowedBooks <- book :: borrowedBooks
        printfn "%s wypożyczył(a): %s" this.Name (book.GetInfo())
    member this.ReturnBook(book: Book) =
        borrowedBooks <- List.filter (fun b -> b <> book) borrowedBooks
        printfn "%s zwrócił(a): %s" this.Name (book.GetInfo())

// Klasa reprezentująca bibliotekę
type Library() =
    let mutable books = []
    member this.AddBook(book: Book) =
        books <- book :: books
        printfn "Dodano do biblioteki: %s" (book.GetInfo())
    member this.RemoveBook(book: Book) =
        books <- List.filter (fun b -> b <> book) books
        printfn "Usunięto z biblioteki: %s" (book.GetInfo())
    member this.ListBooks() =
        if books.IsEmpty then
            printfn "Brak dostępnych książek w bibliotece."
        else
            books |> List.iter (fun book -> printfn "%s" (book.GetInfo()))

// Program główny
[<EntryPoint>]
let main argv =
    let library = Library()
    let user = User("Alicja")

    let book1 = Book("Władca Pierścieni#", "Tolkien", 300)
    let book2 = Book("Hobbit", "Tolkien", 250)

    library.AddBook(book1)
    library.AddBook(book2)

    printfn "\nAktualne książki w bibliotece:"
    library.ListBooks()

    printfn "\nUżytkownik wypożycza książki:"
    user.BorrowBook(book1)
    library.RemoveBook(book1)

    printfn "\nAktualne książki w bibliotece:"
    library.ListBooks()

    printfn "\nUżytkownik zwraca książkę:"
    user.ReturnBook(book1)
    library.AddBook(book1)

    printfn "\nKońcowy stan biblioteki:"
    library.ListBooks()

    0
