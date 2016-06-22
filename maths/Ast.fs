module Ast

type Expr =
    | Num of double
    | Plus of Expr * Expr
    | Minus of Expr * Expr
    | Mult of Expr * Expr
    | Div of Expr * Expr
    | Pow of Expr * Expr
    | Var of string
    | Grp of Expr

type Stmt = 
    | Assign of string * Expr
    | Expr of Expr
    | Apply of string * Expr list

type Fun = string * string list * Expr list

type Prog = Stmt list

type ReturnType =
    | Double of double
    | Unit