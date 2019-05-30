(*

OBJECTIVE: (Problem set 2 Question 11) Create a record type for Name, Credits and GPA.
Create a record instance with the values "Jones", 109, 3.85.

*)


module P2Question11 = 



    type Student = 
        {
            Name : string
            Credits : int
            GPA : float
        }


    let stu = 
        {
            Name = "Jones"
            Credits = 109
            GPA = 3.85
        }
