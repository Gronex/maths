// Signature file for parser generated by fsyacc
module Parser
type token = 
  | NEWLINE
  | EOF
  | ASSIGN
  | PLUS
  | MINUS
  | MULT
  | DIV
  | FLOAT of (float)
  | INT of (int)
  | ID of (string)
type tokenId = 
    | TOKEN_NEWLINE
    | TOKEN_EOF
    | TOKEN_ASSIGN
    | TOKEN_PLUS
    | TOKEN_MINUS
    | TOKEN_MULT
    | TOKEN_DIV
    | TOKEN_FLOAT
    | TOKEN_INT
    | TOKEN_ID
    | TOKEN_end_of_input
    | TOKEN_error
type nonTerminalId = 
    | NONTERM__startstart
    | NONTERM_start
    | NONTERM_Prog
    | NONTERM_Expr
    | NONTERM_Stmt
    | NONTERM_StmtList
/// This function maps tokens to integer indexes
val tagOfToken: token -> int

/// This function maps integer indexes to symbolic token ids
val tokenTagToTokenId: int -> tokenId

/// This function maps production indexes returned in syntax errors to strings representing the non terminal that would be produced by that production
val prodIdxToNonTerminal: int -> nonTerminalId

/// This function gets the name of a token as a string
val token_to_string: token -> string
val start : (Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> token) -> Microsoft.FSharp.Text.Lexing.LexBuffer<'cty> -> (Ast.Prog) 
