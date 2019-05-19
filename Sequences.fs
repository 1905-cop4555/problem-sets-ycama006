(*

OBJECTIVE: Practicing sequences with F#

*)




module Sequences = 


    /// This is the empty sequence.
    let seq1 = Seq.empty
    printfn "seq1: %A\n" seq1




    /// This a sequence of values.
    let seq2 = seq { yield "hello"; yield "world"; yield "and"; yield "hello"; yield "world"; yield "again" }
    printfn "seq2: %A\n" seq2
    
    let seq3 = seq { yield 1; yield 2; yield 3; yield 4; yield 4; yield 6 }
    printfn "seq3: %A\n" seq3

    let seq4 = seq { yield true; yield false; yield true; yield false; yield true; yield false }
    printfn "seq4: %A\n" seq4




    /// This is an on-demand sequence from 1 to 1000.
    let numbersSeq = seq { 1 .. 1000 }
    printfn "\nnumbersSeq: %A\n" numbersSeq



    /// This is a sequence producing the words "hello" and "world"
    let seq5 = 
        seq { for word in seq2 do
                  if word.Contains("l") then 
                      yield word }

    printfn "seq5: %A\n" seq5

    

    /// This sequence producing the even numbers up to 2000.
    let evenNumbers = Seq.init 1001 (fun n -> n * 2) 
    printfn "evenNumbers: %A\n\n" evenNumbers




    let rnd = System.Random()

    /// This is an infinite sequence which is a random walk.
    /// This example uses yield! to return each element of a subsequence.
    let rec randomWalk x =
        seq { yield x
              yield! randomWalk (x + rnd.NextDouble() - 0.5) }

    printf "randomWalk: %A\n\n" (randomWalk 5.0)
              
    /// This example shows the first 100 elements of the random walk.
    let first100ValuesOfRandomWalk = 
        randomWalk 5.0 
        |> Seq.truncate 100
        |> Seq.toList

    printfn "First 100 elements of a random walk: %A" first100ValuesOfRandomWalk







(*

    Sequences

Sequences are a logical series of elements, all of the same type. These are a 
more general type than Lists and Arrays, capable of being your "view" into 
any logical series of elements. They also stand out because they can be lazy, 
which means that elements can be computed only when they are needed.

*)



//REFERENCE: https://docs.microsoft.com/en-us/dotnet/fsharp/tour