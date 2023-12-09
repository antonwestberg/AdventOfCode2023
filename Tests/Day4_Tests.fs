module Tests.Day4_Tests

open Day4
open Xunit
open Cards

[<Fact>]
let ``parseline works properly``() =
    let line = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53"
    let expected = {
        id = 1
        winning = [41; 48; 83; 86; 17]
        players = [83; 86; 6; 31; 17; 9; 48; 53;]
    }
    Assert.Equal(expected, parseLine line)
    
[<Theory>]
[<InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 8)>]
[<InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2)>]
[<InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 0)>]
let ``calculates points correctly``(line, expected) =
    let card = parseLine line
    Assert.Equal(expected, calculatePoints card)
    