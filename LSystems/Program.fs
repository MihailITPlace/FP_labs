open LSystems
open System.Drawing
open System.Windows.Forms
open Logic


[<EntryPoint>]
let main argv =

    //start -> -F++F++F--
    //F -> F-F+F+F-
        
    let mutable str = "-F++F++F--"        
    for i = 1 to 4 do
        str <- replaceProduction str "F-F+F+F-"
    
    let img = new Bitmap(800, 800)    
    let g  = Graphics.FromImage(img)     
    
    draw str g 0 10.0 90.0 |> ignore
    
    let temp = new Form() in
    temp.Paint.Add(fun e -> e.Graphics.DrawImage(img, 0, 0))
    do Application.Run(temp)
    0
