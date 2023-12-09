module Day2.Cubes

type Color = Red | Blue | Green
type Cubes= {
    color: Color
    count: int
}
type Handful = Cubes list
type Game =  {
    id: int
    cubes: Handful list
}
type Constraint = Map<Color, Cubes>

let createCubes count color = { color = color; count = count }

let createConstraint cubes =
    cubes
    |> Seq.map (fun c -> (c.color, c))
    |> Map

let findMinimumSet (game:Game) : Handful =
    game.cubes
    |> Seq.concat
    |> Seq.groupBy (fun cube -> cube.color)
    |> Seq.map (fun (key, cubes) ->
        {
            color = key
            count = cubes |> Seq.map(fun c -> c.count) |> Seq.max
        })
    |> Seq.toList

let isPossible (constr: Constraint) (game: Game): bool =
    let checkConstraint (cube: Cubes) =
        Map.tryFind cube.color constr
        |> Option.map (fun con -> con.count >= cube.count)
        
    let isValid = function
        | Some b -> b
        | None -> false
    
    game
    |> findMinimumSet
    |> Seq.map checkConstraint
    |> Seq.forall isValid
    
let power cubes =
    cubes
    |> Seq.map (fun c -> c.count)
    |> Seq.fold (fun acc curr -> acc * curr) 1