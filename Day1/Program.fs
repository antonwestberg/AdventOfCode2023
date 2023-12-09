// For more information see https://aka.ms/fsharp-console-apps
open System.IO
open Day1

printfn "Advent of code day 1"

let lines = File.ReadLines("data.txt")
let result1 = Parser.parse1 lines

printfn "Part One"
printfn $"Answer is: {result1}"

let result2 = Parser.parse2 lines

printfn "Part Two"
printfn $"Answer is: {result2}"

