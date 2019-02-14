module Tests

open Xunit
open FsUnit.Xunit
open Resolver.AStar.FSharp

[<Fact>]
let ``Solve required case #1 [ 1, 2, 3, 4, 6, 5, 0, 7, 8, 9 ]`` () =
    Implementation.computeFrom([ 1; 2; 3; 4; 6; 5; 0; 7; 8; 9 ]) |> should equal [6;4]

[<Fact>]
let ``Solve required case #2 [ 1, 2, 3, 4, 6, 5, 8, 9, 7, 0 ]`` () =
    Implementation.computeFrom([ 1; 2; 3; 4; 6; 5; 8; 9; 7; 0 ]) |> should equal [9;7;8;6;4]
