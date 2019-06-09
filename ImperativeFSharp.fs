(*

 OBJECTIVE: To test, analyze, and understand how to use mutuable reference cells to produce imperative programs with F#
 
*)


module ImperativeFSharp = 


    let factorial n =
        let ans = ref 1
        let cnt = ref 1
        while !cnt <= n do
          ans := !ans * !cnt;
          cnt := !cnt + 1
        !ans

    printfn "ImperativeFSharp: %d" (factorial 3)
