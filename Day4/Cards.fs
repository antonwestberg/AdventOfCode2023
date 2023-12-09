module Day4.Cards

type Card = {
    id: int
    winning: int list
    players: int list
}

let numberOfMatches card =
    let findMatches list1 list2 =
        list1
        |> Seq.filter (fun item1 -> Seq.contains item1 list2)
        
    findMatches card.winning card.players
        |> Seq.length

let takeStartingAt index items =
    items |> Seq.skip index |> Seq.tail

let calculatePoints card =
    let rec calc current i =
        match i with
        | 0 -> 0
        | 1 -> current
        | n -> calc (current*2) (n-1)
        
    let matches = numberOfMatches card
    calc 1 matches

let parseLine (line: string) : Card =
    let parseId (str: string) =
        let intPart =
            str.Split(' ')
            |> Seq.filter (fun s -> s <> "")
            |> Seq.last
        
        intPart.Trim() |> int
    
    let parseNumbers (str: string) =
        str.Split(' ')
        |> Seq.map (fun s -> s.Trim())
        |> Seq.filter (fun s -> s <> "")
        |> Seq.map int
        |> Seq.toList
        
    let parts = line.Split(':')
    {
        id = parts[0] |> parseId
        winning = parts[1].Split('|')[0] |> parseNumbers
        players = parts[1].Split('|')[1] |> parseNumbers
    }