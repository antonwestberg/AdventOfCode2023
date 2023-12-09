module Day2.Parser
open Cubes

open System


let parseColor = function
    | "blue" -> Blue
    | "red" -> Red
    | "green" -> Green
    | s -> failwith $"unknown color {s}"

let parseLine (line: string) =
    let parseGameId (str: string) = 
        str.Split(' ')[1]
        |> int
    
    let parseCubes (str: string) =
        let parts = str.Trim().Split(' ')
        {
            count = int parts[0]
            color = parseColor parts[1]
        }
    
    let parseHandful (str: string) =
        str.Split(',')
        |> Seq.map parseCubes
        |> Seq.toList
    
    let idPart = line.Split(':')[0]
    let cubesPart = line.Split(':')[1]
    
    let id = parseGameId idPart
        
    let cubes =
        cubesPart.Split(';')
        |> Seq.map parseHandful
        |> Seq.toList
        
    {
        id = id
        cubes = cubes
    }