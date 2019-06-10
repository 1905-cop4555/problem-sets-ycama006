(*

OBJECTIVE: Attempting to test, analyze, and understant how to implement a Stack data structure with F#

*)

module ImperativeStack = 
     

    let mkstack init =
          let stk = ref init
          (
            (fun x -> stk := x :: (!stk)),        // push
            (fun () -> stk := List.tail (!stk)),  // pop
            (fun () -> List.head (!stk))          // top
          )         

    mkstack[1]
    mkstack ["cat";"dog"] 
    mkstack []
