﻿// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open System.IO
open Microsoft.FSharp.Text
open Ast

let printResult = function
| Double x -> printfn "%g" x
| Unit -> ()
//| Fun (name,args,returnType) -> printfn "%s(%s) -> %A" name (String.Join(", ", args)) returnType

//val evalFunc : Fun list -> Fun -> Expr list

let rec evalExpr vars funs = function
| Num x -> x
| Plus (left, right) -> (evalExpr vars funs left) + (evalExpr vars funs right)
| Minus (left, right) -> (evalExpr vars funs left) - (evalExpr vars funs right)
| Mult (left, right) -> (evalExpr vars funs left) * (evalExpr vars funs right)
| Div (left, right) -> (evalExpr vars funs left) / (evalExpr vars funs right)
| Pow (left, right) -> (evalExpr vars funs left) ** (evalExpr vars funs right)
| Grp (expr) -> evalExpr vars funs expr     
| Var name -> 
    match Map.tryFind name vars with 
        | Some num -> num
        | None -> failwith (name + " not defined")
| Apply(name, args) ->  
    match Map.tryFind name funs with
    | Some func -> 
        match evalFunc vars funs func args with
        | Double x -> x
        | _ -> 0.0
    | None -> failwith (name + " not defined")

and evalFunc vars funs (argVars, exprs) args = 
    let argVals = List.map (fun arg -> evalExpr vars funs arg) args
    let vars = Map.ofList (List.zip argVars argVals)
    let (res, _, _) = eval vars funs Unit exprs
    res

and eval vars funs lastResult = function
| [] -> (lastResult, vars, funs)
| Assign(name, expr)::rest -> eval (Map.add name (evalExpr vars funs expr) vars) funs Unit rest
| FunAssign(name, args, stmts)::rest -> eval vars (Map.add name (args, stmts) funs) Unit rest
| (Expr(expr))::rest -> 
    let result = evalExpr vars funs expr
    eval vars funs (Double result) rest

let rec run vars funs = 
    printf "> "
    let line = Console.ReadLine()
    let lexbuf = Lexing.LexBuffer<byte>.FromString line
    let prog = Parser.start Lexer.tokenize lexbuf
    try
        let (res, vars, funs) = eval vars funs Unit prog
        printResult res
        run vars funs
    with
    | Failure message -> 
        printfn "%s" message
        run vars funs
        
let evalFile fileName = 
    let script = Array.filter (fun s -> not (String.IsNullOrWhiteSpace s)) (File.ReadAllLines fileName)
    let lexbuf = Lexing.LexBuffer<byte>.FromString (String.Join("\n", script))
    let prog = Parser.start Lexer.tokenize lexbuf
    let (res, _, _) = eval Map.empty Map.empty Unit prog
    printResult res

[<EntryPoint>]
let main argv = 
    //run Map.empty Map.empty
    evalFile "C:/Users/gronex/git/maths/maths/test.mat"
    Console.WriteLine("(press any key)")
    Console.ReadKey(true) |> ignore
    0 // return an integer exit code
   