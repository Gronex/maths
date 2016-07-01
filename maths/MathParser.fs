// Implementation file for parser generated by fsyacc
module Parser
#nowarn "64";; // turn off warnings that type variables used in production annotations are instantiated to concrete type
open Microsoft.FSharp.Text.Lexing
open Microsoft.FSharp.Text.Parsing.ParseHelpers
# 1 "MathParser.fsp"

open Ast

# 10 "MathParser.fs"
// This type is the type of tokens accepted by the parser
type token = 
  | NEWLINE
  | EOF
  | ASSIGN
  | POW
  | PLUS
  | MINUS
  | MULT
  | DIV
  | LPAREN
  | RPAREN
  | LBRACKET
  | RBRACKET
  | COMMA
  | FLOAT of (float)
  | INT of (int)
  | ID of (string)
// This type is used to give symbolic names to token indexes, useful for error messages
type tokenId = 
    | TOKEN_NEWLINE
    | TOKEN_EOF
    | TOKEN_ASSIGN
    | TOKEN_POW
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_MULT
    | TOKEN_DIV
    | TOKEN_LPAREN
    | TOKEN_RPAREN
    | TOKEN_LBRACKET
    | TOKEN_RBRACKET
    | TOKEN_COMMA
    | TOKEN_FLOAT
    | TOKEN_INT
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
// This type is used to give symbolic names to token indexes, useful for error messages
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_ArgList
    | NONTERM_ExprList
    | NONTERM_StmtList
    | NONTERM_start
    | NONTERM_Prog
    | NONTERM_Expr
    | NONTERM_Stmt
    | NONTERM_assign

// This function maps tokens to integer indexes
let tagOfToken (t:token) = 
  match t with
  | NEWLINE  -> 0 
  | EOF  -> 1 
  | ASSIGN  -> 2 
  | POW  -> 3 
  | PLUS  -> 4 
  | MINUS  -> 5 
  | MULT  -> 6 
  | DIV  -> 7 
  | LPAREN  -> 8 
  | RPAREN  -> 9 
  | LBRACKET  -> 10 
  | RBRACKET  -> 11 
  | COMMA  -> 12 
  | FLOAT _ -> 13 
  | INT _ -> 14 
  | ID _ -> 15 

// This function maps integer indexes to symbolic token ids
let tokenTagToTokenId (tokenIdx:int) = 
  match tokenIdx with
  | 0 -> TOKEN_NEWLINE 
  | 1 -> TOKEN_EOF 
  | 2 -> TOKEN_ASSIGN 
  | 3 -> TOKEN_POW 
  | 4 -> TOKEN_PLUS 
  | 5 -> TOKEN_MINUS 
  | 6 -> TOKEN_MULT 
  | 7 -> TOKEN_DIV 
  | 8 -> TOKEN_LPAREN 
  | 9 -> TOKEN_RPAREN 
  | 10 -> TOKEN_LBRACKET 
  | 11 -> TOKEN_RBRACKET 
  | 12 -> TOKEN_COMMA 
  | 13 -> TOKEN_FLOAT 
  | 14 -> TOKEN_INT 
  | 15 -> TOKEN_ID 
  | 18 -> TOKEN_end_of_input
  | 16 -> TOKEN_error
  | _ -> failwith "tokenTagToTokenId: bad token"

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
let prodIdxToNonTerminal (prodIdx:int) = 
  match prodIdx with
    | 0 -> NONTERM__startstart 
    | 1 -> NONTERM_ArgList 
    | 2 -> NONTERM_ArgList 
    | 3 -> NONTERM_ExprList 
    | 4 -> NONTERM_ExprList 
    | 5 -> NONTERM_StmtList 
    | 6 -> NONTERM_StmtList 
    | 7 -> NONTERM_start 
    | 8 -> NONTERM_Prog 
    | 9 -> NONTERM_Expr 
    | 10 -> NONTERM_Expr 
    | 11 -> NONTERM_Expr 
    | 12 -> NONTERM_Expr 
    | 13 -> NONTERM_Expr 
    | 14 -> NONTERM_Expr 
    | 15 -> NONTERM_Expr 
    | 16 -> NONTERM_Expr 
    | 17 -> NONTERM_Expr 
    | 18 -> NONTERM_Expr 
    | 19 -> NONTERM_Expr 
    | 20 -> NONTERM_Stmt 
    | 21 -> NONTERM_Stmt 
    | 22 -> NONTERM_assign 
    | 23 -> NONTERM_assign 
    | 24 -> NONTERM_assign 
    | _ -> failwith "prodIdxToNonTerminal: bad production index"

let _fsyacc_endOfInputTag = 18 
let _fsyacc_tagOfErrorTerminal = 16

// This function gets the name of a token as a string
let token_to_string (t:token) = 
  match t with 
  | NEWLINE  -> "NEWLINE" 
  | EOF  -> "EOF" 
  | ASSIGN  -> "ASSIGN" 
  | POW  -> "POW" 
  | PLUS  -> "PLUS" 
  | MINUS  -> "MINUS" 
  | MULT  -> "MULT" 
  | DIV  -> "DIV" 
  | LPAREN  -> "LPAREN" 
  | RPAREN  -> "RPAREN" 
  | LBRACKET  -> "LBRACKET" 
  | RBRACKET  -> "RBRACKET" 
  | COMMA  -> "COMMA" 
  | FLOAT _ -> "FLOAT" 
  | INT _ -> "INT" 
  | ID _ -> "ID" 

// This function gets the data carried by a token as an object
let _fsyacc_dataOfToken (t:token) = 
  match t with 
  | NEWLINE  -> (null : System.Object) 
  | EOF  -> (null : System.Object) 
  | ASSIGN  -> (null : System.Object) 
  | POW  -> (null : System.Object) 
  | PLUS  -> (null : System.Object) 
  | MINUS  -> (null : System.Object) 
  | MULT  -> (null : System.Object) 
  | DIV  -> (null : System.Object) 
  | LPAREN  -> (null : System.Object) 
  | RPAREN  -> (null : System.Object) 
  | LBRACKET  -> (null : System.Object) 
  | RBRACKET  -> (null : System.Object) 
  | COMMA  -> (null : System.Object) 
  | FLOAT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | INT _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
  | ID _fsyacc_x -> Microsoft.FSharp.Core.Operators.box _fsyacc_x 
let _fsyacc_gotos = [| 0us; 65535us; 1us; 65535us; 39us; 3us; 2us; 65535us; 38us; 7us; 39us; 7us; 2us; 65535us; 0us; 11us; 47us; 12us; 1us; 65535us; 0us; 1us; 1us; 65535us; 0us; 16us; 16us; 65535us; 0us; 28us; 8us; 9us; 13us; 28us; 14us; 28us; 30us; 21us; 31us; 22us; 32us; 23us; 33us; 24us; 34us; 25us; 35us; 26us; 37us; 27us; 38us; 6us; 39us; 6us; 42us; 29us; 44us; 28us; 47us; 28us; 5us; 65535us; 0us; 10us; 13us; 15us; 14us; 15us; 44us; 45us; 47us; 10us; 5us; 65535us; 0us; 41us; 13us; 41us; 14us; 41us; 44us; 41us; 47us; 41us; |]
let _fsyacc_sparseGotoTableRowOffsets = [|0us; 1us; 3us; 6us; 9us; 11us; 13us; 30us; 36us; |]
let _fsyacc_stateToProdIdxsTableElements = [| 1us; 0us; 1us; 0us; 3us; 1us; 9us; 19us; 3us; 2us; 23us; 24us; 1us; 2us; 1us; 2us; 6us; 3us; 12us; 13us; 14us; 15us; 18us; 2us; 4us; 19us; 1us; 4us; 6us; 4us; 12us; 13us; 14us; 15us; 18us; 1us; 5us; 2us; 6us; 8us; 2us; 6us; 24us; 1us; 6us; 2us; 6us; 24us; 1us; 6us; 1us; 7us; 2us; 9us; 19us; 5us; 9us; 19us; 22us; 23us; 24us; 1us; 10us; 1us; 11us; 6us; 12us; 12us; 13us; 14us; 15us; 18us; 6us; 12us; 13us; 13us; 14us; 15us; 18us; 6us; 12us; 13us; 14us; 14us; 15us; 18us; 6us; 12us; 13us; 14us; 15us; 15us; 18us; 6us; 12us; 13us; 14us; 15us; 16us; 18us; 6us; 12us; 13us; 14us; 15us; 17us; 18us; 6us; 12us; 13us; 14us; 15us; 18us; 18us; 6us; 12us; 13us; 14us; 15us; 18us; 21us; 6us; 12us; 13us; 14us; 15us; 18us; 22us; 1us; 12us; 1us; 13us; 1us; 14us; 1us; 15us; 1us; 16us; 1us; 17us; 1us; 17us; 1us; 18us; 1us; 19us; 3us; 19us; 23us; 24us; 1us; 19us; 1us; 20us; 1us; 22us; 2us; 23us; 24us; 2us; 23us; 24us; 1us; 23us; 1us; 24us; 1us; 24us; 1us; 24us; |]
let _fsyacc_stateToProdIdxsTableRowOffsets = [|0us; 2us; 4us; 8us; 12us; 14us; 16us; 23us; 26us; 28us; 35us; 37us; 40us; 43us; 45us; 48us; 50us; 52us; 55us; 61us; 63us; 65us; 72us; 79us; 86us; 93us; 100us; 107us; 114us; 121us; 128us; 130us; 132us; 134us; 136us; 138us; 140us; 142us; 144us; 146us; 150us; 152us; 154us; 156us; 159us; 162us; 164us; 166us; 168us; |]
let _fsyacc_action_rows = 49
let _fsyacc_actionTableElements = [|5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 18us; 0us; 49152us; 6us; 16385us; 3us; 16393us; 4us; 16393us; 5us; 16393us; 6us; 16393us; 7us; 16393us; 8us; 38us; 2us; 32768us; 9us; 43us; 12us; 4us; 1us; 32768us; 15us; 5us; 0us; 16386us; 5us; 16387us; 3us; 37us; 4us; 30us; 5us; 31us; 6us; 32us; 7us; 33us; 2us; 32768us; 9us; 40us; 12us; 8us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 16388us; 3us; 37us; 4us; 30us; 5us; 31us; 6us; 32us; 7us; 33us; 0us; 16389us; 1us; 16392us; 0us; 13us; 1us; 32768us; 0us; 14us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 18us; 6us; 32768us; 5us; 34us; 8us; 35us; 11us; 48us; 13us; 20us; 14us; 19us; 15us; 18us; 0us; 16390us; 0us; 16391us; 1us; 16393us; 8us; 38us; 2us; 16393us; 2us; 42us; 8us; 39us; 0us; 16394us; 0us; 16395us; 3us; 16396us; 3us; 37us; 6us; 32us; 7us; 33us; 3us; 16397us; 3us; 37us; 6us; 32us; 7us; 33us; 1us; 16398us; 3us; 37us; 1us; 16399us; 3us; 37us; 3us; 16400us; 3us; 37us; 6us; 32us; 7us; 33us; 6us; 32768us; 3us; 37us; 4us; 30us; 5us; 31us; 6us; 32us; 7us; 33us; 9us; 36us; 0us; 16402us; 5us; 16405us; 3us; 37us; 4us; 30us; 5us; 31us; 6us; 32us; 7us; 33us; 5us; 16406us; 3us; 37us; 4us; 30us; 5us; 31us; 6us; 32us; 7us; 33us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 0us; 16401us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 2us; 0us; 16403us; 0us; 16404us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 17us; 1us; 32768us; 2us; 44us; 6us; 32768us; 5us; 34us; 8us; 35us; 10us; 46us; 13us; 20us; 14us; 19us; 15us; 18us; 0us; 16407us; 1us; 32768us; 0us; 47us; 5us; 32768us; 5us; 34us; 8us; 35us; 13us; 20us; 14us; 19us; 15us; 18us; 0us; 16408us; |]
let _fsyacc_actionTableRowOffsets = [|0us; 6us; 7us; 14us; 17us; 19us; 20us; 26us; 29us; 35us; 41us; 42us; 44us; 46us; 52us; 59us; 60us; 61us; 63us; 66us; 67us; 68us; 72us; 76us; 78us; 80us; 84us; 91us; 92us; 98us; 104us; 110us; 116us; 122us; 128us; 134us; 140us; 141us; 147us; 153us; 159us; 160us; 161us; 167us; 169us; 176us; 177us; 179us; 185us; |]
let _fsyacc_reductionSymbolCounts = [|1us; 1us; 3us; 1us; 3us; 1us; 3us; 1us; 1us; 1us; 1us; 1us; 3us; 3us; 3us; 3us; 2us; 3us; 3us; 4us; 1us; 1us; 3us; 6us; 10us; |]
let _fsyacc_productionToNonTerminalTable = [|0us; 1us; 1us; 2us; 2us; 3us; 3us; 4us; 5us; 6us; 6us; 6us; 6us; 6us; 6us; 6us; 6us; 6us; 6us; 6us; 7us; 7us; 8us; 8us; 8us; |]
let _fsyacc_immediateActions = [|65535us; 49152us; 65535us; 65535us; 65535us; 16386us; 65535us; 65535us; 65535us; 65535us; 16389us; 65535us; 65535us; 65535us; 65535us; 16390us; 16391us; 65535us; 65535us; 16394us; 16395us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 65535us; 16401us; 65535us; 65535us; 65535us; 16403us; 16404us; 65535us; 65535us; 65535us; 16407us; 65535us; 65535us; 16408us; |]
let _fsyacc_reductions ()  =    [| 
# 187 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : Ast.Prog)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
                      raise (Microsoft.FSharp.Text.Parsing.Accept(Microsoft.FSharp.Core.Operators.box _1))
                   )
                 : '_startstart));
# 196 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 26 "MathParser.fsp"
                                [_1] 
                   )
# 26 "MathParser.fsp"
                 : 'ArgList));
# 207 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'ArgList)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 27 "MathParser.fsp"
                                           _3 :: _1 
                   )
# 27 "MathParser.fsp"
                 : 'ArgList));
# 219 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 31 "MathParser.fsp"
                                  [_1] 
                   )
# 31 "MathParser.fsp"
                 : 'ExprList));
# 230 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'ExprList)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 32 "MathParser.fsp"
                                                 _3 :: _1 
                   )
# 32 "MathParser.fsp"
                 : 'ExprList));
# 242 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Stmt)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 36 "MathParser.fsp"
                                  [_1] 
                   )
# 36 "MathParser.fsp"
                 : 'StmtList));
# 253 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'StmtList)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Stmt)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 37 "MathParser.fsp"
                                                _3 :: _1 
                   )
# 37 "MathParser.fsp"
                 : 'StmtList));
# 265 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Prog)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 40 "MathParser.fsp"
                                    _1 
                   )
# 40 "MathParser.fsp"
                 : Ast.Prog));
# 276 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'StmtList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 42 "MathParser.fsp"
                                      List.rev(_1) 
                   )
# 42 "MathParser.fsp"
                 : 'Prog));
# 287 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 45 "MathParser.fsp"
                                Var(_1) 
                   )
# 45 "MathParser.fsp"
                 : 'Expr));
# 298 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : int)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 46 "MathParser.fsp"
                              Num(double _1) 
                   )
# 46 "MathParser.fsp"
                 : 'Expr));
# 309 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : float)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 47 "MathParser.fsp"
                                Num(_1) 
                   )
# 47 "MathParser.fsp"
                 : 'Expr));
# 320 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 48 "MathParser.fsp"
                                         Plus(_1, _3) 
                   )
# 48 "MathParser.fsp"
                 : 'Expr));
# 332 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 49 "MathParser.fsp"
                                          Minus(_1, _3) 
                   )
# 49 "MathParser.fsp"
                 : 'Expr));
# 344 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 50 "MathParser.fsp"
                                         Mult(_1, _3) 
                   )
# 50 "MathParser.fsp"
                 : 'Expr));
# 356 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 51 "MathParser.fsp"
                                        Div(_1, _3) 
                   )
# 51 "MathParser.fsp"
                 : 'Expr));
# 368 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 52 "MathParser.fsp"
                                     Minus(Num(0.0), _2) 
                   )
# 52 "MathParser.fsp"
                 : 'Expr));
# 379 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _2 = (let data = parseState.GetInput(2) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 53 "MathParser.fsp"
                                             Grp(_2) 
                   )
# 53 "MathParser.fsp"
                 : 'Expr));
# 390 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 54 "MathParser.fsp"
                                           Pow(_1, _3) 
                   )
# 54 "MathParser.fsp"
                 : 'Expr));
# 402 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'ExprList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 55 "MathParser.fsp"
                                                       Apply(_1, List.rev(_3)) 
                   )
# 55 "MathParser.fsp"
                 : 'Expr));
# 414 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'assign)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 58 "MathParser.fsp"
                                    _1 
                   )
# 58 "MathParser.fsp"
                 : 'Stmt));
# 425 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 59 "MathParser.fsp"
                               Expr(_1) 
                   )
# 59 "MathParser.fsp"
                 : 'Stmt));
# 436 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'Expr)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 63 "MathParser.fsp"
                                            Assign(_1, _3) 
                   )
# 63 "MathParser.fsp"
                 : 'assign));
# 448 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'ArgList)) in
            let _6 = (let data = parseState.GetInput(6) in (Microsoft.FSharp.Core.Operators.unbox data : 'Stmt)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 64 "MathParser.fsp"
                                                                  FunAssign(_1, List.rev(_3), [_6]) 
                   )
# 64 "MathParser.fsp"
                 : 'assign));
# 461 "MathParser.fs"
        (fun (parseState : Microsoft.FSharp.Text.Parsing.IParseState) ->
            let _1 = (let data = parseState.GetInput(1) in (Microsoft.FSharp.Core.Operators.unbox data : string)) in
            let _3 = (let data = parseState.GetInput(3) in (Microsoft.FSharp.Core.Operators.unbox data : 'ArgList)) in
            let _8 = (let data = parseState.GetInput(8) in (Microsoft.FSharp.Core.Operators.unbox data : 'StmtList)) in
            Microsoft.FSharp.Core.Operators.box
                (
                   (
# 65 "MathParser.fsp"
                                                                                                        FunAssign(_1, List.rev(_3), List.rev(_8)) 
                   )
# 65 "MathParser.fsp"
                 : 'assign));
|]
# 475 "MathParser.fs"
let tables () : Microsoft.FSharp.Text.Parsing.Tables<_> = 
  { reductions= _fsyacc_reductions ();
    endOfInputTag = _fsyacc_endOfInputTag;
    tagOfToken = tagOfToken;
    dataOfToken = _fsyacc_dataOfToken; 
    actionTableElements = _fsyacc_actionTableElements;
    actionTableRowOffsets = _fsyacc_actionTableRowOffsets;
    stateToProdIdxsTableElements = _fsyacc_stateToProdIdxsTableElements;
    stateToProdIdxsTableRowOffsets = _fsyacc_stateToProdIdxsTableRowOffsets;
    reductionSymbolCounts = _fsyacc_reductionSymbolCounts;
    immediateActions = _fsyacc_immediateActions;
    gotos = _fsyacc_gotos;
    sparseGotoTableRowOffsets = _fsyacc_sparseGotoTableRowOffsets;
    tagOfErrorTerminal = _fsyacc_tagOfErrorTerminal;
    parseError = (fun (ctxt:Microsoft.FSharp.Text.Parsing.ParseErrorContext<_>) -> 
                              match parse_error_rich with 
                              | Some f -> f ctxt
                              | None -> parse_error ctxt.Message);
    numTerminals = 19;
    productionToNonTerminalTable = _fsyacc_productionToNonTerminalTable  }
let engine lexer lexbuf startState = (tables ()).Interpret(lexer, lexbuf, startState)
let start lexer lexbuf : Ast.Prog =
    Microsoft.FSharp.Core.Operators.unbox ((tables ()).Interpret(lexer, lexbuf, 0))
