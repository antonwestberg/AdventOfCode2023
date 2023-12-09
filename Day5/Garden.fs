module Day5.Garden

type Mapping = {
    destination: int
    source: int
    range: int
}

type MappingSet = {
    maps: Mapping list
    name: string // more structured?
}

let parseMap str =
    failwith ""
    
let map mapping value =
    let offset = value - mapping.source
    mapping.destination + offset

let mapValue mappingSet value =
    let inRange low high num = low <= num && num < high 
    let findMapping (found: Option<Mapping>) mapping =
        if inRange mapping.source (mapping.source + mapping.range) value then
            Some mapping
        else
            if found.IsSome then found else None
            
    let mapping = Seq.fold findMapping None mappingSet.maps
    match mapping with
    | Some m -> map m value
    | None -> value
    