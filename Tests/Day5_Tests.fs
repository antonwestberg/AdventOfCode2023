module Tests.Day5_Tests

open Day5
open Xunit
open Garden

[<Fact>]
let ``parseMap works``() =
    let data = "seed-to-soil map:
50 98 2
52 50 48"
    let expected =
        {
            name = "seed-to-soil"
            maps = [
                {
                    destination = 50; source = 98 ;range = 2
                }
                {
                    destination = 52; source = 50; range = 48
                }
            ]
        }
        
    Assert.Equal(expected, parseMap data)
    
    
[<Fact>]
let ``mapValue works``() =
    let map =
        {
            name = "seed-to-soil"
            maps = [
                {
                    destination = 50; source = 98 ;range = 2
                }
                {
                    destination = 52; source = 50; range = 48
                }
            ]
        }
    Assert.Equal(50, mapValue map 98)
    Assert.Equal(81, mapValue map 79)