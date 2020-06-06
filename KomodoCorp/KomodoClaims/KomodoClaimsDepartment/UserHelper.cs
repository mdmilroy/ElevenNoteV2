using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    class UserHelper
    {
        public int cid;
        public List<Claim> claims = new List<Claim>();
        public List<Claim> claimsHandled = new List<Claim>(); 
        
        public List<Claim> GetAllClaims(ClaimsRepo claimsToGet)
        {
            if (claimsToGet._claims.Count < 1)
            {
                Console.WriteLine("There are no claims to view at this time.\n" +
                    "Press enter to return to the main menu.");
            }
            
            return claimsToGet._claims;
        }

        public Claim GetClaimToHandle(ClaimsRepo claimRepoToHandle)
        {
            Claim claimToHandle = null;
            Claim nextClaim = claimRepoToHandle._claims[0];
            Console.WriteLine("Here are the details of the next claim to be handled:\n" +
                $"ClaimID: {nextClaim.ClaimID}\n" +
                $"ClaimType: {nextClaim.ClaimType}\n" +
                $"Description: {nextClaim.Description}\n" +
                $"Ammount: ${nextClaim.Amount}\n" +
                $"DateOfAccident: {nextClaim.DateOfAccident.ToString("MM/dd/yyyy")}\n" +
                $"DateOfClaim: {nextClaim.DateOfClaim.ToString("MM/dd/yyyy")}\n" +
                $"IsValid: {nextClaim.IsValid}\n\n");
            Console.WriteLine("Would you like to deal with this claim now [y / n]?");
            string response = Console.ReadLine();
            switch (response)
            {
                case "y":
                case "yes":
                    claimToHandle = nextClaim;
                    break;
                case "n":
                case "no":
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
            return claimToHandle;
        }

        public Claim GetClaimToCreate()
        {
            cid++;
            string type = "undetermined";
            string descr;
            double amt = 0;
            DateTime accident = new DateTime();
            DateTime claimed = new DateTime();
            bool validity = false;



            Console.WriteLine("What is the type of claim you are creating?\n" +
                "1. Car\n" +
                "2. House\n" +
                "3. Theft\n");
            string response = Console.ReadLine();
            switch (response)
            {
                case "1":
                    type = "Car";
                    break;
                case "2":
                    type = "House";
                    break;
                case "3":
                    type = "Theft";
                    break;
                default:
                    Console.WriteLine("Please choose one of the given options.");
                    break;
            }

            Console.WriteLine("\nPlease describe the claim.");
            descr = Console.ReadLine();

            Console.WriteLine("\nWhat is the amount of the claim?");

            //amt = Convert.ToDouble(Console.ReadLine());
            bool valid = false;
            while (!valid)
            {
                if (Double.TryParse(Console.ReadLine(), out amt))
                {
                    valid = true;
                }
                else
                {
                    Console.WriteLine("Please enter a numerical amount.");
                }
            }

            bool validAccident = false;
            while (!validAccident)
            {
                Console.WriteLine("\nWhen did the accident occur? (Please use MM, DD, YYYY format.)");
                if (DateTime.TryParse(Console.ReadLine(), out accident))
                {
                    validAccident = true;
                }
                else
                {
                    Console.WriteLine("You have entered an invalid date format.");
                }
            }

            bool validClaim = false;
            while (!validClaim)
            {
                Console.WriteLine("\nWhen was the claim submitted? (Please use MM, DD, YYYY format.)");
                if (DateTime.TryParse(Console.ReadLine(), out claimed))
                {
                    validClaim = true;
                }
                else
                {
                    Console.WriteLine("You have entered an invalid date format.");
                }
            }

            bool validValid = false;
            while (!validValid)
            {
                Console.WriteLine("\nIs this claim valid [y/n]?");
                string answer = Console.ReadLine();
                switch (answer)
                {
                    case "y":
                        validity = true;
                        validValid = true;
                        break;
                    case "n":
                        validity = false;
                        validValid = true;
                        break;
                    default:
                        Console.WriteLine("Please enter y or n.");
                    break;
                }
            }
            Claim claim = new Claim(cid, type, descr, amt, accident, claimed, validity);
            return claim;
        }

        public List<Claim> GetHandledClaims(ClaimsRepo claimsToGet)
        {
            if (claimsToGet._claimsHandled.Count < 1)
            {
                Console.WriteLine("There are no claims to view at this time.\n" +
                    "Press enter to return to the main menu.");
            }

            return claimsToGet._claimsHandled;
        }
    }
}
