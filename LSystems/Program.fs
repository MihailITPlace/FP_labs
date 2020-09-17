open LSystems
open System.Drawing
open System.Windows.Forms
open Logic


[<EntryPoint>]
let main argv =    
//    let start = "-F++F++F--"
//    let production = "F-F+F+F-"
//    let numberOfRounds = 4    
        
    let start = "F"
    let production = "F[+FF][-FF]F[-F][+F]F"
    let numberOfRounds = 3
        
    let str = getFinalProduction start production numberOfRounds    
        
    let img = new Bitmap(800, 800)    
    let g  = Graphics.FromImage(img)     
    
    draw str (400.0, 500.0, 90.0) (15.0, 36.0) g |> ignore
    
    let temp = new Form() in
    temp.Paint.Add(fun e -> e.Graphics.DrawImage(img, 0, 0))
    do Application.Run(temp)
    0
