// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open Microsoft.FSharp.Text

[<EntryPoint>]
let main argv = 
    let x = "5 + 10"
    let lexbuf = Lexing.LexBuffer<byte>.FromString x
    while not lexbuf.IsPastEndOfStream do  
        printfn "%A" (Lexer.tokenize lexbuf)
    Console.WriteLine("(press any key)")   
    Console.ReadKey(true) |> ignore
    0 // return an integer exit code
