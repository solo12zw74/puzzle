namespace Resolver.AStar.FSharp

type public AStarResolver() =     
    interface Resolver.Contracts.IResolver with
        member x.Resolve(input: int []): int [] = 
            Implementation.computeFrom (List.ofArray input) |> Array.ofList