open System.IO

let readFile path = System.IO.File.ReadAllLines(path)


let calories path =
    let initial = (0, [])
    let lines = readFile path
    Seq.fold (fun (curr, acc) s ->
        if s = "" then
            0, curr :: acc
        else
            let x = int s
            curr + x, acc) initial lines
    |> snd

let path = Path.Combine(__SOURCE_DIRECTORY__, "input01.txt")
let part1 = path |> calories |> List.sortDescending |> List.head
let part2 = path |> calories |> List.sortDescending |> List.take 3 |> List.sum

printfn $"{part1}"
printfn $"{part2}"
