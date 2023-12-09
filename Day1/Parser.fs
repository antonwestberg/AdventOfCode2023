module Day1.Parser

open System

let findNumbers (str: string) : int seq =
    str 
    |> Seq.filter Char.IsNumber 
    |> Seq.map Char.GetNumericValue 
    |> Seq.map int
   
let spelledOutDigits = [
        ("one", 1)
        ("two", 2)
        ("three", 3)
        ("four", 4)
        ("five", 5)
        ("six", 6)
        ("seven", 7)
        ("eight", 8)
        ("nine", 9)
    ]
   
let findSpelledOutNumbers (str: string) : int seq =
    let digits = 
        [1..9]
        |> List.map (fun n -> (n.ToString(), n))
        |> List.append spelledOutDigits
    let nonNegative n = n >= 0
    
    digits
        |> Seq.map (fun (spelled, num) -> (str.IndexOf(spelled), num))
        |> Seq.filter (fun (i, _) -> nonNegative i)
        |> Seq.sortBy fst
        |> Seq.map snd
      
let parseLine findNumbers line =
    let numbers = findNumbers line
    let first = Seq.head numbers |> string
    let last = Seq.last numbers |> string
    let full = first + last
    int full
    
let parse1 lines =
    let parseLine = parseLine findNumbers 
    lines
    |> Seq.map parseLine
    |> Seq.sum
    
let parse2 lines =
    let parseLine = parseLine findSpelledOutNumbers 
    lines
    |> Seq.map parseLine
    |> Seq.sum