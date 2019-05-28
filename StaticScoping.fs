(*

OBJECTIVE: Testing how static scoping works with F#

*)


module StaticScoping = 



        /// Here's an example that shows that F# uses static scoping.


        let x = 3 in let fFunction y = x+y
                     let x = 6

        printfn "\n\nfFunction outputs: %d" ( fFunction x )
        // Above F# program is equivalent to C below
        (*


            int x = 3;

            int f(int y) {return x+y;}

            main() 
            {

              int x = 6;
              f(x);

            }


        *)
