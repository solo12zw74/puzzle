namespace Resolver.AStar.FSharp

type Move = { 
    Breadcrumb:int list
    BoardState:int list
    Heuristic: int
    Parent: Move option 
}