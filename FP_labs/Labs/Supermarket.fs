module FP_labs.Labs.Supermarket

type IEmployer =
   abstract member PaySalary : int -> unit
   abstract member Hire : unit -> unit
   abstract member Dismiss : unit -> unit
   
type IProduct =   
   abstract member Sell : unit -> unit

   
type Cashier(name: string) =
   let name = name
   do printfn "%s родился!" name
   
   interface IEmployer with
      member this.PaySalary salary = printfn "Кассиру %s заплатили %d" name salary
      member this.Hire() = printfn "Ура! Кассира %s взяли на работу" name
      member this.Dismiss() = printfn "Ох, нет! Кассира %s уволили с работы" name
   
   abstract member SitDownAtCheckout : unit -> unit
   
   override this.SitDownAtCheckout() = printfn "Кассир %s сел за кассу..." name
   
   member this.SellProduct product = (product :> IProduct).Sell()

   
type SeniorCashier(name: string) =
   inherit Cashier(name)
   
   interface IEmployer with
      member this.PaySalary salary = printfn "Старшему кассиру %s заплатили %d" name salary
      member this.Hire() = printfn "Ура! Старшего кассира %s взяли на работу" name
      member this.Dismiss() = printfn "Ох, нет! Старшего кассира %s нельзя уволить с работы" name
   
   override this.SitDownAtCheckout() =
      printfn "Старшего кассира нельзя посадить за кассу. Сеньор(ита) %s курит" name


type Milk(price: int) =
   let price = price
   interface IProduct with
      member this.Sell() = printfn "Товар продан за %d" price

 