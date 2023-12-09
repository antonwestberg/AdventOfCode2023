module Tests.Day9_Tests

open Xunit
open Day9.Oasis

let parseList (data: string) = data.Split(' ') |> Seq.map int |> Seq.toList

[<Theory>]
[<InlineData("0 3 6 9 12 15", 18)>]
[<InlineData("1 3 6 10 15 21", 28)>]
[<InlineData("10 13 16 21 30 45", 68)>]
let ``find next value in example``(data: string, expected) =
    let numbers = parseList data
    Assert.Equal(expected, nextValue numbers)
    
[<Fact>]
let ``diffSequence correct when steady increase``() =
    let numbers = parseList "0 3 6 9 12 15"
    Assert.Equal<int list>([3;3;3;3;3], diffSequence numbers)

[<Fact>]
let ``prevValue is correct for first example``() =
    let numbers = parseList "10 13 16 21 30 45"
    Assert.Equal(5, prevValue numbers)