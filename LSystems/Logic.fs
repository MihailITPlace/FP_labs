//start -> -F++F++F--
//F -> F-F+F+F-

module LSystems.Logic
    open System
    open System.Drawing
    
    let replaceProduction (str: string) (prod: string) : string =
        str.Replace("F", prod)                
    
    let first(c, _, _) = c
    let second(_, c, _) = c
    let thrid(_, _, c) = c
    
    let drawStack str (g: Graphics) (len: double) (angle: double) =
        let mutable stack = [(400.0, 500.0, 90.0)]
        let blackPen = new Pen(Color.Black, 1.5f)
        
        let size = (str |> String.length) - 1
        
        for i = 0 to size do
            let currentAngle = thrid stack.Head
            let x = first stack.Head
            let y = second stack.Head
            
            match str.[i] with
            | 'F' ->                
                let newX = len * (cos (currentAngle * Math.PI / 180.0)) + x
                let newY = len * (-sin (currentAngle * Math.PI / 180.0)) + y                
                g.DrawLine(blackPen, float32 x,  float32 y, float32 newX, float32 newY)                
                stack <- (newX, newY, currentAngle) :: stack.Tail                 
            | '+' -> stack <- (x, y, currentAngle + angle) :: stack.Tail
            | '-' -> stack <- (x, y, currentAngle - angle) :: stack.Tail
            | '[' -> stack <- stack.Head :: stack
            | ']' -> stack <- stack.Tail
        
    
    
//    let draw str (g: Graphics) (len: double) (angle: double) =        
//        let blackPen = new Pen(Color.Black, 1.5f)
//        
//        let mutable currentAngle = 0.0
//        let mutable x = 400.0
//        let mutable y = 200.0
//        
//        let size = (str |> String.length) - 1
//                
//        for i = 0 to size do       
//            match str.[i] with
//            | 'F' ->                
//                let newX = len * (cos (currentAngle * Math.PI / 180.0)) + x
//                let newY = len * (-sin (currentAngle * Math.PI / 180.0)) + y                
//                g.DrawLine(blackPen, float32 x,  float32 y, float32 newX, float32 newY)
//                x <- newX
//                y <- newY
//            | '+' -> currentAngle <- (currentAngle + angle)
//            | '-' -> currentAngle <- (currentAngle - angle)     