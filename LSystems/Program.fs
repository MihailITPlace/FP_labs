open LSystems
open System.Drawing
open System.Windows.Forms
open Logic


[<EntryPoint>]
let main argv =

    //start -> -F++F++F--
    //F -> F-F+F+F-
        
    let mutable str = "F"        
    for i = 1 to 3 do
        str <- replaceProduction str "F[+FF][-FF]F[-F][+F]F"
    
    let img = new Bitmap(800, 800)    
    let g  = Graphics.FromImage(img)     
    
    drawStack str g 15.0 36.0
    
    let temp = new Form() in
    temp.Paint.Add(fun e -> e.Graphics.DrawImage(img, 0, 0))
    do Application.Run(temp)
    0
