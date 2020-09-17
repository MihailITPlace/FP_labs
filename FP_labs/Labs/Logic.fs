// Вариант 27

module FP_labs.Labs.Logic
    open FP_labs.Labs
    open System.IO
    open FP_labs.Labs.Supermarket

    //let filePath = "files/lab2.txt"
    //let fileOutPath = "files/out_lab.txt"
    let fileInputPath = @"C:\Users\алексей\Desktop\FP_labs\FP_labs\files\lab2.txt"
    let fileOutPath = @"C:\Users\алексей\Desktop\FP_labs\FP_labs\files\out_lab.txt"
    
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
        let readLines filePath = File.ReadLines(filePath)
                                 |> Seq.map(fun l -> l.Split ' ')
                                 |> Seq.concat
                                 
        let text = readLines(fileInputPath)
        
        let mutable lst = []
        text |> Seq.iteri(fun i s ->  if i % 3 = 0 then lst <- s :: lst)
        
        let mostFrequentChar = text
                               |> Seq.map(fun s -> s |> Seq.toList)
                               |> Seq.concat
                               |> Seq.countBy(fun c -> c)
                               |> Seq.maxBy (fun g -> snd g )                           
        
        File.WriteAllLines(fileOutPath, lst)
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
            
        arr |> Array.iter(fun x -> printf "%d " x)
        0
    
        
    let lab4 () =
        let cashier = Cashier("Вася")
        let seniorCashier = SeniorCashier("Иван Петрович")
       
        (cashier :> IEmployer).Hire()
        (seniorCashier :> IEmployer).Hire()
       
        cashier.SitDownAtCheckout()   
        seniorCashier.SitDownAtCheckout()
       
        let milk = Milk(120)
        cashier.SellProduct milk
        seniorCashier.SellProduct milk        
        0

    
    let lab5 () =        
        let readLines filePath = File.ReadAllLines(filePath)                                 
                                 |> Seq.map(fun l -> l.Split ' ')
                                 |> Seq.concat

        let mutable freq = ' ', 0        
        let mostFrequentChar text =
            async {
                freq <- text
                        |> Seq.map(fun s -> s |> Seq.toList)
                        |> Seq.concat
                        |> Seq.countBy(fun c -> c)
                        |> Seq.maxBy (fun g -> snd g )
            }
                
        let mutable lst = []      
        let thridsWords text =
            async {
                text |> Seq.iteri(fun i s ->  if i % 3 = 0 then lst <- s :: lst)                                
            }
            
        let text = readLines fileInputPath
        [thridsWords text; mostFrequentChar text]
            |> Async.Parallel
            |> Async.Ignore
            |> Async.RunSynchronously
            
        printfn "%c %d" (fst freq) (snd freq)
        File.WriteAllLines(fileOutPath, lst)
        0