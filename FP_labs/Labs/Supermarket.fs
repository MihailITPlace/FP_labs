module FP_labs.Labs.Supermarket

type IEmployer =
   abstract member PaySalary : int -> unit
   abstract member Hire : unit -> unit
   abstract member Dismiss : unit -> unit
   
type IProduct =   
   abstract member Sell : unit -> unit

   
type Cashier(name: string) =
   let name = name
   do printfn "%s родился!\n" name
   
   interface IEmployer with
      member this.PaySalary salary = printfn "Кассиру %s заплатили %d\n" name salary
      member this.Hire() = printf "Ура! Кассира %s взяли на работу\n" name
      member this.Dismiss() = printf "Ох, нет! Кассира %s уволили с работы\n" name
   
   abstract member SitDownAtCheckout : unit -> unit
   
   override this.SitDownAtCheckout() = printf "Кассир %s сел за кассу...\n" name
   
   member this.SellProduct product = (product :> IProduct).Sell()

   
type SeniorCashier(name: string) =
   inherit Cashier(name)
   
   interface IEmployer with
      member this.PaySalary salary = printfn "Старшему кассиру %s заплатили %d\n" name salary
      member this.Hire() = printf "Ура! Старшего кассира %s взяли на работу\n" name
      member this.Dismiss() = printf "Ох, нет! Старшего кассира %s нельзя уволить с работы\n" name
   
   override this.SitDownAtCheckout() =
      printf "Старшего кассира нельзя посадить за кассу. Сеньор(ита) %s курит\n" name


type Milk(price: int) =
   let price = price
   interface IProduct with
      member this.Sell() = printf "Товар продан за %d\n" price

 