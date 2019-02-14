namespace Resolver.AStar.FSharp

type Move = { 
    Breadcrumb:int list
    BoardState:int list
    Heuristic: int
    Parent: Move option 
}

module private Implementation =
    open Resolver.Contracts

    let movesMap = Rules.MovesMap |> List.ofArray |> List.map (List.ofArray)

    let finalState = Rules.FinalState |> List.ofArray

    let compute initialBoardState =

        let a = Resolver.Contracts.Rules.FinalState

        let heuristic stepnumber state =
            List.zip state finalState
            |> List.fold (fun acc (a,b) -> if a <> b then acc + 1 else acc) 0
            |> (+) stepnumber

        let rec nextNodes stepnumber (move:Move) = 
    
            let emptyElementIndex = move.BoardState |> List.findIndex ((=) 0)

            let swapZeroWith targetIndex =
                let permute (i,v) = 
                    match i with
                    | x when x = emptyElementIndex -> move.BoardState.[targetIndex]
                    | x when x = targetIndex -> 0
                    | _ -> v

                let nextState = move.BoardState |> List.indexed |> List.map permute
        
                { 
                    Breadcrumb= move.Breadcrumb @ [move.BoardState.[targetIndex]]
                    BoardState = nextState
                    Heuristic = heuristic (stepnumber + 1) nextState
                    Parent = Some move
                }
    
            let nextBestMove = 
                movesMap 
                |> List.item emptyElementIndex 
                |> List.map swapZeroWith 
                |> List.sortBy (fun x -> x.Heuristic)
                |> List.head

            match nextBestMove.BoardState with
            | x when x = finalState -> nextBestMove
            | _ -> nextNodes (stepnumber + 1) nextBestMove


        let initialMove = { 
            Breadcrumb = []
            BoardState = initialBoardState
            Heuristic = (heuristic 0 initialBoardState)
            Parent = None 
        }
    
        let bestPath = nextNodes 0 initialMove
        bestPath.Breadcrumb
