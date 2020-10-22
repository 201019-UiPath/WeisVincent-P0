using System;

class Start {


    public static boolean start() {
        if (!doesAccountExist()) {
            queryAccountCreation();
        } 
            
        
        
    } 

    public static Boolean doesAccountExist() {
        string ans;
        Console.WriteLine("Do you have an account?");
        Console.WriteLine("Y or N");
        ans = Console.ReadLine().ToLower();
        if (ans.StartsWith("n")) {
            Console.WriteLine("You responded that you have an account!");
            return true;
        }
        Console.WriteLine("No account? Let's fix that.");
        return false;
    }

    public static Boolean queryAccountCreation() {
        string ans;
        Console.WriteLine("Do you wish to make an account?");
        Console.WriteLine("Y or N");
        ans = Console.ReadLine().ToLower();
        
        switch (ans[0]) {
            case n: 
                //TODO: Add program termination message and terminate the app.
                break;
            case y:
                //TODO: Continue execution by allowing the user to make an account.
                break;
            default:
                
                break;
        }

        if (ans.StartsWith("n")) {
            
        } else if (ans.StartsWith("y")) {

        } else {
            
        }
        Console.WriteLine("No account? Let's fix that.");
        return false;

    }
}