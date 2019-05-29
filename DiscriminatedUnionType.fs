(*

OBJECTIVE:  Practicing discriminated union types with F#.

*)



module DiscriminatedUnionTypes = 



    // The identifiers Red, Green, and Blue are called constructors.

    // F# requires that constructors be capitalized to distinguish 
    // them from identifiers.
    type color = Red | Green | Blue

    // Pattern matching on 'color' is supported
    let opinion1 = function
    |Blue   -> "lovely"
    |Green  -> "ugly"

    printfn "\n\n\nopinion1 output: %s" ( opinion1 Blue )
    printfn "opinion1 output: %s" ( opinion1 Green )


    let opinion2 = function
    |Red   -> "Good"
    |Blue  -> "Bad"
    |Green -> "Ugly"

    printfn "\nopinion2 output: %s" ( opinion2 Red )
    printfn "opinion2 output: %s" ( opinion2 Blue )
    printfn "opinion2 output: %s" ( opinion2 Green )



    //Note that misspelling a constructor is very bad!
    let oops = function
    |Red   -> 1
    |green -> 2
    |Blue  -> 3

    printfn "\noops output: %d" ( oops Blue ) //Will output, 2, which is an error



    // Union constructors have module scope

    type mood = Happy | Blue

    //This can lead to name clashes, 
    //sometimes requiring  PREFIXED NAMES:

    (*
        Using F# Interactive:

          Blue;;
          val it : mood = Blue

          > Red;;
          val it : color = Red

          > color.Blue;;
          val it : color = Blue

    *)

