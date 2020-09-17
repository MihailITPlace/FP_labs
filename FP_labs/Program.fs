open System
open FP_labs.Labs.Logic

[<EntryPoint>]
let main argv =
    let start = DateTime.Now
    lab2() |> ignore
    let finish = DateTime.Now
    
    printfn "Время %f мс" (finish - start).TotalMilliseconds
    0