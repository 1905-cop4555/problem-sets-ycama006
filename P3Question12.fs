(*

OBJECTIVE: (Problem Set 3, Question 12) Using imperative F#, create a record type for a student. 
The record will have a function that returns the student's GPA, a function that adds credit hours 
and a function that adds grade points. Initialize an instance of the record with appropriate 
functions and values. Use the instance to add grade points and credits several times, and display 
the GPA.

*)

module P3Question12 = 


    type Student = 

        {
            creditHours : float -> unit
            gradePoints : float -> float -> unit
            studentGPA : unit -> float
        }



    let student = 
        let totalCredits = ref 0.0
        let totalGradePoints = ref 0.0
        let gpa = ref 0.0
        {
            creditHours = fun credits -> totalCredits := !totalCredits + credits;
            gradePoints = fun points credits -> totalGradePoints := !totalGradePoints + (points * credits);
            studentGPA = fun () -> !totalGradePoints / !totalCredits;
        }


    student.creditHours 2.0
    student.gradePoints 4.0 2.0

    student.creditHours 2.0
    student.gradePoints 3.3 2.0


    student.creditHours 4.0
    student.gradePoints 4.0 4.0


    student.creditHours 1.0
    student.gradePoints 1.7 1.0

    student.creditHours 2.0
    student.gradePoints 3.0 2.0
   

    student.creditHours 1.0
    student.gradePoints 2.7 1.0

    student.creditHours 1.0
    student.gradePoints 4.0 1.0
   

    printfn "\n\n\nP3Question12: %f" ( student.studentGPA ())
