using FileHandlerApp;
using System;
using FileHandlerApp.Exceptions;

class Program
{
    static void Main(string[] args)
    {
        const string filePath = "Files/Users.txt";
        var fileHandler = new FileHandler(filePath);

        while (true)
        {
            try
            {
                Console.Write("Indtast fornavn: ");
                string firstName = Console.ReadLine();
                Console.Write("Indtast efternavn: ");
                string lastName = Console.ReadLine();
                Console.Write("Indtast alder: ");
                int age = int.Parse(Console.ReadLine());
                Console.Write("Indtast e-mail: ");
                string email = Console.ReadLine();

                var user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Email = email
                };

                user.Validate();

                fileHandler.SaveUser(user);

                Console.WriteLine("Registrerede brugere:");
                Console.WriteLine(fileHandler.LoadUsers());
            }
            catch (InvalidNameException ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
            }
            catch (InvalidAgeException ex) when (ex.Message != "Exception for Niels Olesen")
            {
                Console.WriteLine($"Fejl: {ex.Message}");
            }
            catch (InvalidEmailException ex)
            {
                Console.WriteLine($"Fejl: {ex.Message} (Detaljer: {ex.InnerException?.Message})");
            }
            catch (FileLoadException ex)
            {
                Console.WriteLine($"Fejl: {ex.Message}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Alder skal være et tal.");
            }
            finally
            {
                Console.WriteLine("Programmet afsluttes korrekt.");
            }
        }
    }
}
