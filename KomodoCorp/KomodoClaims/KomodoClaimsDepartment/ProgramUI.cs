using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public class ProgramUI
    {
        public void Run()
        {
            UserHelper _helper = new UserHelper();
            ClaimsRepo repo = new ClaimsRepo();
            bool claimsMenu = true;

            while (claimsMenu)
            {
                Console.WriteLine("Welecome to the main Claims Menu. Please select an option below:\n" +
                "1. See all claims\n" +
                "2. Take care of next claim\n" +
                "3. Enter a new claim\n" +
                "4. See all handled claims\n" +
                "5. Exit\n");

                string response = Console.ReadLine();
                Console.Clear();

                switch (response)
                {
                    case "1":
                        List<Claim> claimsToView = _helper.GetAllClaims(repo);
                        repo.ViewAllClaims(claimsToView);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "2":
                        Claim claimToHandle = new Claim();
                        if (repo._claims.Count == 0)
                        {
                            Console.WriteLine("There are no claims to handle at this time.\n" +
                                "Press enter to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            claimToHandle = _helper.GetClaimToHandle(repo);
                        }

                        if (claimToHandle != null)
                        {
                            repo.HandleNextClaim(claimToHandle);
                            Console.WriteLine("Your claim has been handled");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("No claim was handled.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case "3":
                        Claim claimToCreate = _helper.GetClaimToCreate();
                        repo.CreateNewClaim(claimToCreate);
                        Console.WriteLine("Your claim has been added to the queue.");
                        Console.ReadLine();
                        Console.Clear(); 
                        break;
                    case "4":
                        List<Claim> handledClaimsToView = _helper.GetHandledClaims(repo);
                        repo.ViewAllClaims(handledClaimsToView);
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case "5":
                        claimsMenu = false;
                        break;
                    default:
                        Console.WriteLine("Please select one of the given options.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            Environment.Exit(0);
        }
    }
}
