module Day1_Tests

open Day1
open Xunit
open Parser

[<Fact>]
let ``Find numbers in line`` () =
    let data = "ab3kl5jd6"
    Assert.Equal<int seq>([3;5;6], findNumbers data)
    
[<Fact>]
let ``Find spelled out numbers`` () =
    let data = "tttoneaaa4"
    Assert.Equal<int seq>([1; 4], findSpelledOutNumbers data)
    
[<Theory>]
[<InlineData("1abc2", 12)>]
[<InlineData("pqr3stu8vwx", 38)>]
[<InlineData("a1b2c3d4e5f", 15)>]
[<InlineData("treb7uchet", 77)>]
let ``Parse line works for first exercise`` (line, result) =
    let parseLine = parseLine findNumbers
    Assert.Equal(result, parseLine line)
    
[<Theory>]
[<InlineData("two1nine", 29)>]
[<InlineData("eightwothree", 83)>]
[<InlineData("abcone2threexyz", 13)>]
[<InlineData("xtwone3four", 24)>]
[<InlineData("4nineeightseven2", 42)>]
[<InlineData("zoneight234", 14)>]
[<InlineData("7pqrstsixteen", 76)>]
[<InlineData("42", 42)>]
[<InlineData("eighthree", 83)>]
[<InlineData("sevenine", 79)>]
let ``Parse line works for second exercise`` (line, result) =
    let parseLine = parseLine findSpelledOutNumbers
    Assert.Equal(result, parseLine line) 

[<Fact>]
let ``Parse2 works`` () =
    let data = [
        "two1nine"
        "eightwothree"
        "abcone2threexyz"
        "xtwone3four"
        "4nineeightseven2"
        "zoneight234"
        "7pqrstsixteen"
    ]
    Assert.Equal(281, parse2 data)