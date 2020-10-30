using Serilog;
using System;
using System.Collections.Generic;

namespace SufferShopLib
{
    /// <summary>
    /// This Class represents a sample model of a Customer of the Suffer Shop.
    /// It includes fields for the name and name components, email, password, id for backend use, location, and current orders.
    /// </summary>
    public class CustomerSample
    {
        string firstName, middleName, lastName;
        string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                // TODO: Create and handle the exception of someone trying to set a name of a Customer to be blank

                // When set, the value input into the Name is split by the spaces to separate words.
                string[] strings = value.Split(' ');
                int numberOfWords = strings.Length; //TODO: This variable never mutates.
                try
                {
                    if (strings[0].Length == 0)
                    {
                        
                        throw new NoNameException($"The length in words of the name of the Customer is 0.");
                    }
                    Console.WriteLine($"The length in words of the name of the Customer is {numberOfWords}."); //numberOfWords won't return 0.
                    switch (numberOfWords)
                    {
                        case 0:
                            name = null;
                            break;
                        case 1:
                            if (strings[0].Length == 0)
                            {
                                name = null;
                                break;
                            }
                            firstName = strings[0];
                            middleName = null;
                            lastName = null;
                            name = firstName;
                            break;
                        case 2:
                            firstName = strings[0];
                            middleName = null;
                            lastName = strings[1];
                            name = $"{firstName} {lastName}";
                            break;
                        default:
                            firstName = strings[0];
                            for (int i = 1; i < strings.Length - 1; i++)
                            {
                                middleName += strings[i];
                            }
                            lastName = strings[strings.Length - 1];
                            name = $"{firstName} {middleName} {lastName}";
                            break;
                    }
                }
                catch (NoNameException e)
                {
                    Log.Information(e.Message); //TODO: Properly format this log message, I guess
                }


            }
        }

        
    }
}
