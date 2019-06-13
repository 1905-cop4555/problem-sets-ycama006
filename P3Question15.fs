(*
  OBJECTIVE: (Problem Set 3, Question 15) 
  
  Explain why F# does not allow the following declaration:
  let mrev = makeMonitoredFun List.rev
  
  Using the technique of eta expansion:
  
  let mrev = fun x -> (makeMonitoredFun List.rev) x
  
  Does this solve the problem? Explain why or why not.
*)


module P3Question15 = 



    let makeMonitoredFun f =
          let c = ref 0
          (fun x -> c := !c+1; printf "Called %d times.\n" !c; f x )


    let msqrt = makeMonitoredFun sqrt 



    //let mrev = makeMonitoredFun List.rev
    let mrev = fun x -> (makeMonitoredFun List.rev) x

    //printfn "%f" (msqrt 16.0 + msqrt 25.0)
    printfn "P3Question15: %A" (mrev [])


    (*

        F# does now allow 'let mrev = makeMonitoredFun List.rev' because the expression 'makeMonitoredFun List.rev'
        is not in restricted form or syntactic value. 


        If it's not a syntactic value, then it cannot be given a polymorphic type, since F# can't tell what 
        type List.rev should be.
    *)

    (*

        The new declaration of the function rewritten as eta expansion solves the value restriction issue, 
        because F# knows that it's a polymorphic list by changing its type, giving it a syntactic value.
    *)

    // let msqrt = 
    //    let c = ref 0
    //    (fun 16.0 -> c := !c+1; printf "Called %d times.\n" !c; (sqrt 16.0) )


    // let msqrt = 
    //    let c = ref 0
    //    (fun 25.0 -> c := !c+1; printf "Called %d times.\n" !c; (sqrt 25.0) )
