using LMS.Common;
using LMS.Core;
using LMS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace LMS
{
    class MenuShow
    {
        public void RunApp()
        {
            var newStudent = new AuthenticationService();
            Console.WriteLine("WELCOME TO DOTNET LIBRARY");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Press enter to start or any other key to exit");
            Console.Write(">>>");
            string begin = Console.ReadLine();
            Console.Clear();

            while (string.IsNullOrWhiteSpace(begin))
            {
                Console.WriteLine("Press 1 to Register");
                Console.WriteLine("Press 2 to Log In");
                Console.WriteLine("Press 3 to Quit");
                Console.Write(">>>");
                try
                {
                    int choice = int.Parse(Console.ReadLine());
                    if (choice == 1)
                    {
                        // Users' Registration
                        // Required Fields
                        var firstName = string.Empty;
                        var lastName = string.Empty;
                        var email = string.Empty;
                        var phoneNumber = string.Empty;
                        var password = string.Empty;

                        Console.Clear();


                        Console.WriteLine("Please fill in all fields");
                        while (true)
                        {
                            Console.Write("First Name: ");
                            var input = Console.ReadLine();
                            //var response = Validations.ValidateName(input);
                            var response = Validations.ValidateName(input);

                            Console.Clear();

                            if (!Regex.IsMatch(input, @"[A-Za-z]")) //Names must only contain strings
                            {
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("Name can only contain alphabeths");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                firstName += response;
                                break;
                            }
                        }

                        var isLastName = true;
                        while (isLastName)
                        {
                            Console.Write("Last Name: ");
                            var response = Console.ReadLine();

                            Console.Clear();

                            if (!Regex.IsMatch(response, @"[A-Za-z]")) //Names must only contain strings
                            {
                                Console.WriteLine("Invalid input!");
                                Console.WriteLine("Name can only contain alphabeths");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                lastName += response;
                                isLastName = false;
                            }
                        }

                        var isEmail = true;
                        while (isEmail)
                        {
                            Console.Write("Email: ");
                            var response = Console.ReadLine();

                            Console.Clear();

                            if (!Regex.IsMatch(response, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                            {
                                Console.WriteLine("Invalid email address!");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                email += response;
                                isEmail = false;
                            }

                        }

                        var isPhone = true;
                        while (isPhone)
                        {
                            Console.Write("Phone Number: ");
                            var response = Console.ReadLine();

                            Console.Clear();

                            if (!Regex.IsMatch(response, @"([0-9]{11})"))
                            {
                                Console.WriteLine("Invalid phone number");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                phoneNumber += response;
                                isPhone = false;
                            }
                        }

                        var isPassword = true;
                        while (isPassword)
                        {
                            Console.WriteLine($"Hint: Password should be minimum of 6 characters\n" +
                                $"      Should include alphanumeric and at least one special characters (@, #, $, %, ^, &, !)");
                            Console.WriteLine();
                            Console.Write("Password: ");
                            var response = Console.ReadLine().Trim();

                            Console.Clear();

                            if (!Regex.IsMatch(response, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,15}$"))
                            {
                                Console.WriteLine("Invalid password");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                Console.Write("Confirm Password: ");
                                var response2 = Console.ReadLine().Trim();
                                if (response2 == response)
                                {
                                    password += response;
                                    isPassword = false;
                                }
                                else
                                {
                                    Console.WriteLine("Password did not match. Please try again");
                                    continue;
                                }
                            }
                        }

                        var Students = new Students()
                        {
                            FirstName = firstName,
                            LastName = lastName,
                            Email = email,
                            PhoneNumber = phoneNumber
                        };


                        //var message = newStudent.RegisterCustomer
                        //Console.WriteLine(message);

                    }
                    else if (choice == 2)
                    {
                        Console.Clear();

                        //User log in details
                        var email = string.Empty;
                        var password = string.Empty;

                        var isValid = true;
                        while (isValid)
                        {
                            Console.Write("Enter Email: ");
                            var response = Console.ReadLine();

                            Console.Clear();

                            if (!Regex.IsMatch(response, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                            {
                                Console.WriteLine("Invalid input");
                                Console.WriteLine("");
                                continue;
                            }
                            else
                            {
                                if (Regex.IsMatch(response, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
                                {
                                    email += response;
                                    isValid = false;
                                }

                            }

                            Console.Write("Enter Password: ");
                            password = Console.ReadLine();

                        }

                        var login = AuthenticationService.Login(email, password);

                        if (login)
                        {
                            Console.Clear();
                            Console.WriteLine("Login Succesful");
                            Students students = new Students();

                            Console.WriteLine($"Welcome {students.FullName}");
                            Console.WriteLine();
                            Console.WriteLine("To activate your account, please make deposit");
                            Console.WriteLine();
                            Console.WriteLine("* Savings Account holder --> minimum N1000");
                            Console.WriteLine("* Current Account holder --> minimum N5000");
                            Console.WriteLine();
                        }
                    }
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Please choose a valid option");
                }
            }
        }
    }
}
