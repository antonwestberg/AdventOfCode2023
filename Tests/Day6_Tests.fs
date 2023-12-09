module Tests.Day6_Tests
open System
open Xunit
open Day6.Race

[<Fact>]
let ``get all wins``() =
    let race = { time = 7; distance = 9}
    Assert.Equal([2L; 3L; 4L; 5L], wins race)
    
[<Theory>]
[<InlineData(0, false)>]
[<InlineData(1, false)>]
[<InlineData(2, true)>]
[<InlineData(6, false)>]
[<InlineData(7, false)>]
[<InlineData(8, false)>]
let ``can win``(holdTime, expected) =
    let win = canWin { time = 7; distance = 9 } holdTime
    Assert.Equal(expected, win)
    
[<Fact>]
let ``numberOfWinsFast is same as naive``() =
    let race = {
        time = 56717999L
        distance = 334113513502430L
    }
    let naive = numberOfWins race |> int64
    let fast = numberOfWinsFast race
    Assert.Equal(naive, fast)
    
[<Fact>]
let ``numberOfWinsVeryFast is same as fast``() =
    let race = {
        time = 56717999L
        distance = 334113513502430L
    }
    let naive = numberOfWinsFast race
    let fast = numberOfWinsVeryFast race
    Assert.Equal(naive, fast)
        