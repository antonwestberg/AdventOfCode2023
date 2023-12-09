module Tests.Day8_Tests

open Day8
open Xunit
open Network



[<Fact>]
let ``parsenode works``() =
    let str = "AAA = (BBB, CCC)"
    let expected = {
        label = "AAA"
        left = "BBB"
        right = "CCC"
    }
    Assert.Equal(expected, parseNode str)