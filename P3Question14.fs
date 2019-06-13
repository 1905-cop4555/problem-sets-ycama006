(*

OBJECTIVE = (Problem Set 3, Question 14) Refer to the lecture on types and the subset of the C language 
that was used. Perform a type derivation to verify that the following code is well-typed.

*)  

module P3Question14 = 

  
    // The following C code is well-typed, although there exists a semantic error


    int *x;

    (*
            E(x) = int* var
            ------------------------- (ID)
            E |- x : int* var   
    *)


    int a[15];

    (*
        E |- 15: int   E[a: int*] |- e2: void
        --------------------------------- (LETARR)
        E |- {int a[15]; e2} : void
    *)
   

    *x = 7;

    (*
        E(x) = int* var
        ------------------------- (ID)
        E |- x : int* var
        -------------------------(R-VAL)
        E |- x: int*
        -------------------------(L-VAL) 
        E |- *x: int var                      E |- 7: int (LIT)
        -------------------------------------------------------- (ASSIGN)
        E |- *x = 7 : int 
    *)

    a[*x] = *x + 4;

    (*



        E(x) = int* var                                 E(x) = int* var
        ------------------------- (ID)                  ------------------------- (ID)
        E |- x : int* var                               E |- x : int* var
        -------------------------(R-VAL)                -------------------------(R-VAL)
        E |- x: int*                                    E |- x: int*
        -------------------------(L-VAL)                -------------------------(L-VAL) 
        E |- *x: int var                                E |- *x: int var  
        -------------------------(R-VAL)                -------------------------(R-VAL)

        E |- *x: int                                    E |- *x: int              E |- 4 : int (LIT)  
        -------------------------                       ------------------------------------------------ (ADD)

        E |- a: int*    E |- *x: int 
        ------------------------------ (SUBSCRIPT)      
        E |- a[*x] : int var                                E |- *x + 4 : int
        --------------------------------------------------------------------------------------- (ASSIGN)
                                        E |- a[*x] =  *x + 4: int 


    *)
