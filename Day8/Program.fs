// For more information see https://aka.ms/fsharp-console-apps


open System.Diagnostics
open System.IO
open Day8
open Network
    
let lines = File.ReadAllLines("data.txt")
let instructions =
    lines
    |> Array.head
    |> Seq.map parseInstruction
    |> Seq.toArray
    |> CircularList.create
    
let nodes =
    lines
    |> Seq.skip 2
    |> Seq.map parseNode
    
let lookup =
    nodes
    |> Seq.map (fun n -> (n.label, n))
    |> Map.ofSeq
    
let startNode (label: string) = label[label.Length-1] = 'A'

let startNodes =
    nodes
    |> Seq.filter (fun n -> startNode n.label)
    |> Seq.take 1
    |> Seq.toList

let timer = Stopwatch.StartNew()
let answer2 = ghostStepsLoops lookup instructions startNodes

timer.Stop()
printfn $"Answer2 = {answer2} in {timer.Elapsed}"