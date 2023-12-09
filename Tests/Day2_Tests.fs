module Day2_Tests

open Xunit
open Day2
open Day2.Cubes

[<Fact>]
let ``Is game possible`` () =
    let game = {
        id = 1
        cubes = [
            [
                { color = Blue; count = 3 }
                { color = Red; count = 4 }
            ]
            [
                { color = Red; count = 1 }
                { color = Green; count = 2 }
                { color = Blue; count = 6 }
            ]
            [
                { color = Green; count = 2 }
            ]
        ]
    }
    
    let constr = createConstraint [
        { color = Red; count = 12 }
        { color = Green; count = 13 }
        { color = Blue; count = 14 }
    ]
    
    Assert.True(isPossible constr game)

[<Fact>]
let ``parseLine can parse example game``() =
    let line = "Game 1: 3 blue, 4 red; 1 red"
    let expected = {
        id = 1
        cubes = [
            [
                createCubes 3 Blue
                createCubes 4 Red
            ]
            [
                createCubes 1 Red
            ]
        ]
    }
    
    Assert.Equal(expected, Parser.parseLine line)

[<Theory>]
[<InlineData("Game 1: 3 blue; 4 red, 14 green", false)>]
[<InlineData("Game 1: 1 red, 10 blue, 5 green; 11 blue, 6 green; 6 green; 1 green, 1 red, 12 blue; 3 blue; 3 blue, 4 green, 1 red", true)>]
[<InlineData("Game 21: 16 red, 3 blue, 8 green; 10 red, 15 blue, 3 green; 6 green, 13 red, 15 blue; 11 green, 13 blue, 10 red", false)>]

let ``Test whole``(data, expected) =
    let constr = createConstraint [
        createCubes 12 Red
        createCubes 13 Green
        createCubes 14 Blue
    ]
    let game = Parser.parseLine data
    Assert.Equal(expected, isPossible constr game)
    
    
[<Fact>]
let ``findMinimumSet works``() =
    let line = "Game 1: 3 blue; 4 red, 14 green; 1 blue 8 green"
    let expected = [
        createCubes 3 Blue
        createCubes 4 Red
        createCubes 14 Green
    ]
    let result = line |> Parser.parseLine |> findMinimumSet
    Assert.Equal<Handful>(expected, result)
    
[<Theory>]
[<InlineData("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green", 48)>]
[<InlineData("Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue", 12)>]
[<InlineData("Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red", 1560)>]
[<InlineData("Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red", 630)>]
[<InlineData("Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green", 36)>]
[<InlineData("Game 21: 16 red, 3 blue, 8 green; 10 red, 15 blue, 3 green; 6 green, 13 red, 15 blue; 11 green, 13 blue, 10 red", 2640)>] 
let ``power``(line, expected) =
    let result =
        line
        |> Parser.parseLine
        |> findMinimumSet
        |> power
    Assert.Equal(expected, result)
