module AoC2024._01.solution

open System.IO

let run = 
    let lines = File.ReadAllLines("01/example.txt") |> Array.toList
    
    let parsedIntArray = lines
                         |> List.map(fun x -> x.Split("   ") |> Array.toList)
                         |> List.concat
                         |> List.filter(fun x -> x.Length > 0)
                         |> List.map(int)
                
    let filterIndexAndSort x condition = x
                                         |> List.mapi(fun i x -> if condition i then -1 else x)
                                         |> List.filter((<>) -1)
                                         |> List.sort
                               
    let list1 = filterIndexAndSort parsedIntArray (fun x -> x % 2 = 0)
    let list2 = filterIndexAndSort parsedIntArray (fun x -> x % 2 = 1)
    
    let sum = (list1, list2)
              ||> List.map2(fun x y -> abs(x - y))
              |> List.sum
    
    printfn $"Part 1: %d{sum}"
    
    let occurances = list1
                     |> List.map(fun x ->
                         (list2 |> List.filter ((=) x) |> List.length ) * x)
                     |> List.sum
    
    printfn $"Part 2: %d{occurances}"
