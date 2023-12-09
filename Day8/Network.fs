module Day8.Network

type Instruction = Left | Right

// like this? or tree?
type Node = {
    label: string
    left: string
    right: string
}

type CircularList<'a> =
    {
        items: 'a array
        index: int
    }

module CircularList =
    let create items = {
        items = items
        index = 0
    }
    
    let head list =
        list.items[list.index]
        
    let tail list =
        let newIndex =
            if list.index + 1 < list.items.Length then
                list.index + 1
            else
                0
        { list with index = newIndex }
    
let parseNode (str: string) =
    {
        label = str.Substring(0, 3)
        left = str.Substring(7, 3)
        right = str.Substring(12, 3)
    }
    
let parseInstruction c =
    match c with
    | 'L' -> Left
    | 'R' -> Right
    | _ -> failwith "wtf"
    
let endNode node = node.label[node.label.Length-1] = 'Z'
    
let step lookup instruction node =
    match instruction with
    | Left -> Map.find node.left lookup
    | Right -> Map.find node.right lookup
    
let steps lookup instructions startLabel =
    let step i node = step lookup i node
    let rec loop count instr node =
        if endNode node
            then count
        else
            let nextNode = step (CircularList.head instr) node
            loop (count+1) (CircularList.tail instr) nextNode
            
    let start = Map.find startLabel lookup
    loop 0 instructions start
    
let ghostSteps lookup instructions startNodes =
    let step i node = step lookup i node
    
    let rec loop count instr nodes =
        if Seq.forall endNode nodes
            then count
        else
            let nextInstruction = CircularList.head instr
            let nextNodes = nodes |> Seq.map (step nextInstruction)
            loop (count+1) (CircularList.tail instr) nextNodes
            
    loop 0 instructions startNodes
    
    
let ghostStepsImp lookup instructions startNodes =
    let step i node = step lookup i node
    let mutable nodes = startNodes
    let mutable instr = instructions
    let mutable count = 0
    
    while List.forall endNode nodes |> not do
        let labels = nodes |> List.map (fun n -> n.label)
        let anyEnd = List.exists endNode nodes
        printfn $"{count} - {labels} - {anyEnd}"
        let nextInstruction = CircularList.head instr
        let nextNodes = nodes |> List.map (step nextInstruction)
        count <- count+1
        instr <- CircularList.tail instr
        nodes <- nextNodes
        
    count
    
// different strat? find loop cadence, common divisor?
let ghostStepsLoops lookup instructions startNodes =
    let step i node = step lookup i node
    
    let rec stepsUntilLoop count instr seen node =
        if Set.contains node seen then
            count
        else
            let nextNode = step (CircularList.head instr) node
            stepsUntilLoop (count+1L) (CircularList.tail instr) (Set.add node seen) nextNode
    
    startNodes
    |> Seq.map (fun n -> stepsUntilLoop 0 instructions Set.empty n)
    |> Seq.map (fun count -> count) // minus 1 since we don't want to count the starting node
    |> Seq.fold (fun state n -> state * n) 1L