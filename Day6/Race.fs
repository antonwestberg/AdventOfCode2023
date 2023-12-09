module Day6.Race

open System

type Race = {
    time: int64
    distance: int64
}

let canWin race holdTime =
    let distance = (race.time - holdTime)*holdTime
    distance > race.distance

let wins race = 
    seq { for n in 0L..race.time do n }
    |> Seq.filter (canWin race)
    
let numberOfWins race =
    race |> wins |> Seq.length
    
let numberOfWinsFast race =
    let startingLosses =
        seq { for n in 0L..race.time do n }
        |> Seq.takeWhile (fun n -> not (canWin race n))
        |> Seq.length
        |> int64
    
    race.time - 2L*startingLosses + 1L
    
let numberOfWinsVeryFast race =
    let mutable losses = 0L
    let mutable won = true
    while won do
        if canWin race losses then
            won <- false
        else
            losses <- losses + 1L
    race.time - 2L*losses + 1L
    