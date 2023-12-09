module Day9.Oasis

let toPairs (list: 'a list): ('a * 'a) list =
    let rec loop pairs list =
        match list with
        | a::[b] -> (a,b)::pairs
        | a::b::tail -> loop ((a,b)::pairs) (b::tail)
        | _ -> failwith "must have at least 2 elements"
    loop [] list |> List.rev
     
let diffSequence numbers =
    numbers
    |> toPairs
    |> List.map (fun (a,b) -> b-a)

let allZeroes list = Seq.forall (fun n -> n = 0) list

let allDiffs nums =
    let rec loop lists nums =
        if allZeroes nums then
                nums::lists
            else
                let diffs = diffSequence nums    
                loop (nums::lists) diffs
    loop [] nums
        
let nextValue numbers =
    let rec next prev lists =
        match lists with
        | a::tail -> next (prev + List.last a) tail
        | [] -> prev
    numbers
    |> allDiffs
    |> next 0
    
let prevValue numbers =
    let rec next prev lists =
        match lists with
        | a::tail -> next (List.head a - prev) tail
        | [] -> prev
    numbers
    |> allDiffs
    |> next 0