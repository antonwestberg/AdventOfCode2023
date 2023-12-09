// For more information see https://aka.ms/fsharp-console-apps


open System.IO

let parseSeedLine (line: string) =
    let parts = line.Split(' ')
    parts
    |> Seq.skip 1
    |> Seq.map int
    
let splitSeq delimiter items =
    let folder (total, buffer) item =
        if item = delimiter then
            (buffer::total, [])
        else
            (total, item::buffer)
    let result = Seq.fold folder ([], []) items
    (snd result)::(fst result)
    // need reverse?

let lines = File.ReadLines("example.txt")
let seeds = lines |> Seq.head |> parseSeedLine
// let maps =
//     lines
//     |> Seq.skip 2
//     |> Seq.