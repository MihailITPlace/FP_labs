// Вариант 27

module Labs

    open System.IO    
    
    //7. Для заданного списка слов найти слова, содержащие не менее одной буквы Т    
    let lab1 () =
        let words = ["qwErt"; "eboll"; "TTT"; "HELLO"; "aatTaa"]        
        words |> List.iter( fun i -> if i.Contains('T') then printf "%s\n" i)        
        0
        
    (*
        12. В данном текстовом файле выделить каждое третье слово
        и найти самую часто встречающуюся в них букву
    *)
    let lab2 () =

//        let readLines (filePath:string) = seq {
//            use sr = new StreamReader (filePath)
//            while not sr.EndOfStream do
//                yield sr.ReadLine ()
//        }
        let readLines filePath = File.ReadLines(filePath)
                                 |> Seq.map(fun l -> l.Split ' ')
                                 |> Seq.concat
                                 
        let text = readLines("/home/michael/RiderProjects/FP_labs/FP_labs/files/lab2.txt")
        text |> Seq.iteri(fun i s ->
            if (i + 1) % 3 = 0 then printf "%s\n" s            
        )
        
        let mostFrequentChar = text |> Seq.map(fun s -> s |> Seq.toList)
                               |> Seq.concat
                               |> Seq.countBy(fun c -> c)
                               |> Seq.maxBy (fun g -> snd g )                           
        
        printf "%c %d\n" (fst mostFrequentChar ) (snd mostFrequentChar)        
        0       

    (*
        7. В массиве все элементы, стоящие перед максимальным, увеличить в 3 раза.
        Пример: из массива A[5]: 3 2 1 5 4 должен получиться массив 9 6 3 5 4.
    *)
    let lab3 () =
        let mutable arr = [| 50; -7; 9; 1; 2; 3 |]

        let size = Array.length arr - 1
        let mutable indexOfMax = 0
        
        for i = 1 to size do
            if arr.[indexOfMax] < arr.[i] then
                indexOfMax <- i
                
        for i = 0 to indexOfMax - 1 do
            arr.[i] <- 3 * arr.[i] 
            
        arr |> Array.iter(fun x -> printf "%d " x) |> ignore
        0
    
        
    let lab4 () =
        
        0