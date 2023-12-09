open System.IO
open Day9
open Oasis

let parseList (data: string) = data.Split(' ') |> Seq.map int |> Seq.toList

let lines = File.ReadLines("data.txt")

let answer1 =
    lines
    |> Seq.map parseList
    |> Seq.map nextValue
    |> Seq.sum
    
printfn $"answer1 is {answer1}"

let answer2 =
    lines
    |> Seq.map parseList
    |> Seq.map prevValue
    |> Seq.sum
    
printfn $"answer2 is {answer2}"