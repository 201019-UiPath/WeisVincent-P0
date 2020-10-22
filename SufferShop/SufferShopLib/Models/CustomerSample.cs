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
        public String Name {
            get {
                return name;
            }
            set {
                // TODO: Create and handle the exception of someone trying to set a name of a Customer to be blank

                // When set, the value input into the Name is split by the spaces to separate words.
                string[] strings = value.Split(' ');
                int numberOfWords = strings.Length; //TODO: This variable never mutates.
                try {
                    if (strings[0].Length == 0) {
                        Console.WriteLine($"The length in words of the name of Customer #{ID} is 0.");
                        throw new NoNameException();
                        
                        name = null;
                        return;
                    }
                    Console.WriteLine($"The length in words of the name of Customer #{ID} is {numberOfWords}."); //numberOfWords won't return 0.
                    switch (numberOfWords) {
                        case 0: 
                            name = null;
                            break;
                        case 1: 
                            if (strings[0].Length == 0) {
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
                            for (int i = 1; i < strings.Length - 1; i++ ) {
                                middleName += strings[i];
                            }
                            lastName = strings[strings.Length - 1];
                            name = $"{firstName} {middleName} {lastName}";
                            break;
                    }
                } 
                catch (NoNameException e) {
                    Console.WriteLine("The customer's name must have at least one word.");
                }
                
                
            }
        }

        string email, password;//TODO: get user input for the email and password.

        public string Email {
            get {
                return "123@gmail.com";// TODO: Replace placeholder Email for Customer
            }
            set {

            }
        }


        int id;
        protected static int idIndex = 0;
        public int ID {
            get {
                return id;
            }
            /*set {
                int idIterator = value;
                if (value < 0) {
                    while (idIterator < idIndex) {
                        idIterator++;
                    }
                }
                id = idIterator;
            }*/
        }

        //TODO: Add Orders variable associated with the customer to the model

        string address,city,state,zipCode;//TODO: Add getters and setters for these
        string fullAddress;//TODO: Add getters and setters for this

        public Stack<string> PhoneNumbers = new Stack<string>();//TODO: Add getters and setters for this

        public void AddPhoneNumber(string phoneNumber)
        {
            if (phoneNumber != null && phoneNumber != "")
            {
                PhoneNumbers.Push(phoneNumber);
            }
            else throw new ArgumentException("phoneNumber cannot be null or empty.");
            
        }

        

        

        
        //TODO: Add constructors for Customer data
        public CustomerSample() {
            id = idIndex;
            idIndex++;
        }
        public CustomerSample(string newName) {
            id = idIndex;
            idIndex++;
            Name = newName;
        }
    }
}
