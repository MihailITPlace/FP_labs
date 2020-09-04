//start -> -F++F++F--
//F -> F-F+F+F-


module LSystems.Logic
    open System
    open System.Drawing
    
    let replaceProduction (str: string) (prod: string) : string =
        str.Replace("F", prod)        
                
    let stack = [(400.0, 200.0, 0.0)]
    
    let rec draw str (g: Graphics) (start: int) (len: double) (angle: double): int =        
        let blackPen = new Pen(Color.Black, 1.5f)
        
        let mutable currentAngle = 0.0
        let mutable x = 400.0
        let mutable y = 200.0
        
        let size = (str |> String.length) - 1
        let mutable i = start
        
        while i < size do       
            match str.[i] with
            | 'F' ->                
                let newX = len * (cos (currentAngle * Math.PI / 180.0)) + x
                let newY = len * (-sin (currentAngle * Math.PI / 180.0)) + y                
                g.DrawLine(blackPen, float32 x,  float32 y, float32 newX, float32 newY)
                x <- newX
                y <- newY
            | '+' -> currentAngle <- (currentAngle + angle)
            | '-' -> currentAngle <- (currentAngle - angle)                
            
            i <- i + 1        
        i