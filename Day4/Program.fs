// For more information see https://aka.ms/fsharp-console-apps

open System.IO
open Day4.Cards


printfn "Hello from F#"


let lines = File.ReadLines("example.txt")

let cards =
    lines
    |> Seq.map parseLine
let answer1 =
    cards
    |> Seq.map calculatePoints
    |> Seq.sum
    
printfn $"Answer to question 1: {answer1}"


