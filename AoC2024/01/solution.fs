module AoC2024._01.solution

open System.IO

let run = 
    let lines = File.ReadAllLines("01/example.txt")
    
    let parsedIntArray = lines
                         |> Array.map( _.Split(" ") )
                         |> Array.concat
                         |> Array.filter(fun x -> x.Length > 0)
                         |> Array.map(fun x -> x |> int)
                
    let filterIndex x condition = x
                                  |> Array.mapi(fun i x -> if condition i then -1 else x)
                                  |> Array.filter(fun x -> x <> -1)
                                  |> Array.sort
                               
    let arr1 = filterIndex parsedIntArray (fun x -> x % 2 = 0)
    let arr2 = filterIndex parsedIntArray (fun x -> x % 2 = 1)
    
    let sum = (arr1, arr2)
              ||> Array.map2(fun x y -> abs(x - y))
              |> Array.sum
    
    printfn $"Part 1: %d{sum}"
    
    let occurances = arr1
                     |> Array.map(fun x ->
                         (arr2 |> Seq.filter ((=) x) |> Seq.length ) * x)
                     |> Array.sum
    
    printfn $"Part 2: %A{occurances}"
