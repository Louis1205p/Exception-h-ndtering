using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHandlerApp.Exceptions;


namespace FileHandlerApp
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

        public void Validate()
        {
            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
                throw new InvalidNameException("Navn må ikke være tomt.");

            if (Age < 18 || Age > 50)
                throw new InvalidAgeException("Alder skal være mellem 18 og 50, medmindre du hedder 'Niels Olesen'.");

            if (!Email.Contains("@") || !Email.Contains("."))
                throw new InvalidEmailException("E-mail er ugyldig.", "En gyldig e-mail skal indeholde '@' og '.'.");
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}, {Age}, {Email}";
        }
    }

}
