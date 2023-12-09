// For more information see https://aka.ms/fsharp-console-apps

open System
open System.Diagnostics
open System.IO

open Day6.Race

let parseLine1 (line: string) =
    let parseInt (str: string) =
        match Int32.TryParse str with
        | true, num -> Some num
        | _ -> None
        
    let parts = line.Split(' ')
    parts
    |> Seq.map parseInt
    |> Seq.filter (fun n -> n.IsSome)
    |> Seq.map (fun n -> n.Value)
    
let parseLine2 (line: string) =
    let parts = line.Split(':')
    parts[1]
    |> Seq.filter (fun c -> c <> ' ')
    |> String.Concat
    |> Int64.Parse

let lines = File.ReadLines("data.txt")

let times = lines |> Seq.head |> parseLine1
let distances = lines |> Seq.last |> parseLine1

let races = 
    Seq.zip times distances
    |> Seq.map (fun (t, d) -> { time = t; distance = d })
    
let answer1 =
    races
    |> Seq.map numberOfWins
    |> Seq.fold (fun acc n -> acc*n) 1
    
printfn $"answer: {answer1}"

let race2 = {
    time = lines |> Seq.head |> parseLine2
    distance = lines |> Seq.last |> parseLine2
}

printfn "trying part 2..."

let timer = Stopwatch.StartNew()
let answer2 = numberOfWinsVeryFast race2
timer.Stop()
printfn $"answer2: {answer2} in {timer.Elapsed}"