module Maths

type Expr =
    | Num of int
    | Dec of double
    | Plus of Expr * Expr
    | Minus of Expr * Expr
    | Mult of Expr * Expr
    | Div of Expr * Expr
    | Pow of Expr * Expr
    | Var of string

type Assignment = string * Expr


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
        