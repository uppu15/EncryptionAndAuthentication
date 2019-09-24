using System;
using System.Collections.Generic;

namespace EncryptionAndAuthentication
{
    class Program
    {
        static void Main(string[] args)
        {
            bool valid;
            int choice;
            Dictionary<string, string> Users = new Dictionary<string, string>();
            Console.WriteLine("Would you like to create a new account?");
        AddUser:
            Console.WriteLine(" 1. Create User \n 2. Authenticate Account \n 3. Exit");
            do
            {
                valid = int.TryParse(Console.ReadLine(), out choice);
                if (!valid || choice < 1 || choice > 3)
                {
                    Console.WriteLine("Invalid input. Try again");
                    valid = false;
                }
            } while (!valid);
            if (choice == 1)
            {
                Console.WriteLine("Please enter a username: ");
                string username = Console.ReadLine();
                Console.WriteLine("Please enter a password: ");
                string password = Console.ReadLine(),
                    encryptedPassword = Encryption.CreateKey(password);
                Users.Add(username, encryptedPassword);
                Console.WriteLine("Create another account?");
                goto AddUser;
            }
            if (choice == 2)
            {
                AuthUserName:
                Console.WriteLine("Please enter a username: ");
                string username = Console.ReadLine();

                if (Users.ContainsKey(username))
                {
                    AuthPassword:
                    Console.Write("Enter your password: ");
                    string password = Console.ReadLine();
                    if(Encryption.CreateKey(password) == Users[username])
                    {
                        Console.WriteLine("**User authenticated.**\n");
                    }
                    else
                    {
                        Console.WriteLine("**Wrong password entered.**\n");
                        goto AuthPassword;
                    }
                }
                else
                {
                    Console.WriteLine("There is no user with that user name.");
                    goto AuthUserName;
                }
                goto AddUser;
                
                
            }
            else
            {
                foreach (KeyValuePair<string, string> User in Users)
                {
                    Console.WriteLine($"/nUsername = {User.Key}, Password = {User.Value}");
                }
            }
        }
    }
}
