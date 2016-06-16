// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open Microsoft.FSharp.Text
open Ast

let printResult = function
| Double x -> printfn "%g" x
| Unit -> ()

let rec evalExpr vars = function
| Num x -> x
| Plus (left, right) -> (evalExpr vars left) + (evalExpr vars right)
| Minus (left, right) -> (evalExpr vars left) - (evalExpr vars right)
| Mult (left, right) -> (evalExpr vars left) * (evalExpr vars right)
| Div (left, right) -> (evalExpr vars left) / (evalExpr vars right)
| Pow (left, right) -> (evalExpr vars left) ** (evalExpr vars right)
| Grp (expr) -> evalExpr vars expr
| Var name -> 
    match Map.tryFind name vars with 
        | Some num -> num
        | None -> failwith (name + " not defined")

let rec eval vars lastResult = function
| [] -> (lastResult, vars)
| Assign(name, expr)::rest -> eval (Map.add name (evalExpr vars expr) vars) Unit rest
| (Expr(expr))::rest -> 
    let result = evalExpr vars expr
    eval vars (Double result) rest


let rec run vars = 
    printf "> "
    let line = Console.ReadLine()
    let lexbuf = Lexing.LexBuffer<byte>.FromString line
    let prog = Parser.start Lexer.tokenize lexbuf
    let (res, vars) = eval vars Unit prog
    printResult res
    run vars


[<EntryPoint>]
let main argv = 
    run Map.empty
    Console.WriteLine("(press any key)")   
    Console.ReadKey(true) |> ignore
    0 // return an integer exit code
   