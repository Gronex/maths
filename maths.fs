module maths

type Expr =
    | Num of int
    | Dec of double
    | Plus of Expr * Expr
    | Minus of Expr * Expr
    | Mult of Expr * Expr
    | Div of Expr * Expr
    | Pow of Expr * Expr
    | Var of string


let rec calculate vars = function
| Dec x -> x
| Num x -> double x
| Plus (left, right) -> (calculate vars left) + (calculate vars right)
| Minus (left, right) -> (calculate vars left) - (calculate vars right)
| Mult (left, right) -> (calculate vars left) * (calculate vars right)
| Div (left, right) -> (calculate vars left) / (calculate vars right)
| Pow (left, right) -> (calculate vars left) ** (calculate vars right)
| Var name -> 
    try
        Map.find name vars
    with 
    | :? System.Collections.Generic.KeyNotFoundException -> failwith (sprintf "'%s' not in vars" name)
        
//| _ -> failwith "Not supported"

let x = calculate Map.empty (Mult (Div (Num 5, Num 10), Dec 0.5))

[<EntryPoint>]
let main argv =
    printfn "%A" argv
    let y = calculate (Map.ofList [("x", 10.0)]) (Mult (Num 5, Var "x"))
    printfn "%f" y
    ignore (System.Console.ReadLine())
    0 // return an integer exit code
