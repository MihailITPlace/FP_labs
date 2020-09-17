module LSystems.Logic
    open System
    open System.Drawing   

        
    let rec getFinalProduction (str: string) (prod: string) (numberOfRounds) : string =
        if numberOfRounds = 0 then
            str
        else
            getFinalProduction (str.Replace("F", prod)) prod (numberOfRounds - 1)
        
        
    let draw str (startX: double, startY: double, startAngle: double) (lineLength: double, angleShift: double) (g: Graphics) =
        let blackPen = new Pen(Color.Black, 1.5f) 
        
        let drawFold (args: List<(double*double*double)>) (currentSymbol: char) =
            let (x, y, currentAngle) = args.Head
            match currentSymbol with
            | 'F' ->
                let newX = lineLength * (cos (currentAngle * Math.PI / 180.0)) + x
                let newY = lineLength * (-sin (currentAngle * Math.PI / 180.0)) + y                
                g.DrawLine(blackPen, float32 x,  float32 y, float32 newX, float32 newY)
                (newX, newY, currentAngle) :: args.Tail
            | '+' -> (x, y, currentAngle + angleShift) :: args.Tail
            | '-' -> (x, y, currentAngle - angleShift) :: args.Tail
            | '[' -> (x, y, currentAngle) :: args
            | ']' -> args.Tail
            | _ ->
                printfn "Неизвестный  символ. Допускаются только: '[', ']', 'F', '+', '-'"
                exit 1
           
        str |> Seq.toList |> List.fold drawFold [(startX, startY, startAngle)]                   