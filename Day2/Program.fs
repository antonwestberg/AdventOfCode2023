// For more information see https://aka.ms/fsharp-console-apps

open System.IO
open Day2
open type Cubes.Color

printfn "Advent of code Day 2"


let lines = File.ReadLines("data.txt")

let games =
    lines
    |> Seq.map Parser.parseLine


printfn "Exercise 1"

let constr = Cubes.createConstraint [
    Cubes.createCubes 12 Red
    Cubes.createCubes 13 Green
    Cubes.createCubes 14 Blue
]
let isPossible = Cubes.isPossible constr 
let answer1 =
    games
    |> Seq.filter isPossible
    |> Seq.map (fun game -> game.id)
    |> Seq.sum
    
printfn $"The answer is: {answer1}"

printfn "Exercise 2"

let answer2 =
    games
    |> Seq.map Cubes.findMinimumSet
    |> Seq.map Cubes.power
    |> Seq.sum
    
printfn $"The answer is: {answer2}"