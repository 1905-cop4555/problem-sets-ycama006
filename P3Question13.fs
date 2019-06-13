(*

OBJECTIVE: (Problem Set 3, Question 13) Using imperative F#, create a tuple for an integer stack, 
including push, pop, top and isEmpty functions. Use the stack to implement factorial. Use a loop 
to push all the values from 1 through the parameter, then use another loop to pop the values and 
calculate factorial. 

*)


module P3Question13 = 


   
    let mkstack init =
            let stk = ref init
            (    (fun x -> stk := x ::(!stk)), (fun () -> stk := List.tail(!stk)),  (fun () -> List.head (!stk))    )


    let (push, pop, top) = mkstack [] 


    let factorial n = 
        let factBase = ref 1
        let factNum = ref n
        let factResult = ref 1

        if n = 0 then push 1                
        else
            while !factBase <= !factNum do
                push !factNum
                factNum := !factNum - 1

            factNum := n
            while !factBase <= !factNum do
                factResult := ( top () ) * !factResult
                pop ()
                factNum := !factNum - 1


        !factResult
        


    printfn "\n\n\nP3Question13: %d" (factorial 3)
