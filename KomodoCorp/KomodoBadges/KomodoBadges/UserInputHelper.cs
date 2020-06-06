using KomodoBadges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class UserInputHelper
    {
        public Badges GetBadgeToCreate()
        {
            Badges badgeToCreate = new Badges();
            Random randID = new Random();
            badgeToCreate.badgeID = randID.Next(1000, 10000);
            List<string> access = new List<string>();
            bool moreDoors = true;

            while(moreDoors)
            {
                Console.WriteLine("What doors are to be accessed?");
                string doors = Console.ReadLine();
                access.Add(doors);
                Console.WriteLine("\nMore doors?");
                string r = Console.ReadLine().ToLower();

                if (r == "n" || r == "no")
                {
                    moreDoors = false;
                    Console.Clear();
                }
                else if (r != "y" && r != "yes")
                {
                    Console.WriteLine("\nPlease enter [y] or [n]");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
            badgeToCreate.badgeAccess = access;
            return badgeToCreate;
        }

        public Badges GetBadgeToUpdate(Badges badgeToUpdate)
        {
            Console.Clear();
            Console.WriteLine($"Badge {badgeToUpdate.badgeID} has access to doors {string.Join(", ", badgeToUpdate.badgeAccess)}.\n");
            Console.WriteLine("1. Add a door \n" +
                "2. Remove a door");
            int r = Convert.ToInt32(Console.ReadLine());
            bool moreDoors = true;

            switch (r)
            {
                case 1:
                    while (moreDoors)
                    {
                        Console.WriteLine($"Badge {badgeToUpdate.badgeID} currently has access to doors {string.Join(", ", badgeToUpdate.badgeAccess)}.\n");
                        Console.WriteLine("What door should be accessible?");
                        string door = Console.ReadLine();
                        if (!badgeToUpdate.badgeAccess.Contains(door))
                        {
                            badgeToUpdate.badgeAccess.Add(door);
                            Console.WriteLine("\nAdd another door?");
                            string response = Console.ReadLine().ToLower();
                            
                            switch (response)
                            {
                                case "y":
                                case "yes":
                                    break;
                                case "n":
                                case "no":
                                    moreDoors = false;
                                    break;
                                default:
                                    Console.WriteLine("\nPlease enter [y] or [n]");
                                    Console.ReadLine();
                                    Console.Clear();
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Badge # {badgeToUpdate.badgeID} now has access to that door.\n" +
                                $"Please try again.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                    }
                    break;

                case 2:
                    while (moreDoors)
                    {
                        Console.WriteLine($"Badge {badgeToUpdate.badgeID} has access to doors {string.Join(", ", badgeToUpdate.badgeAccess)}.\n");
                        Console.WriteLine("What door would you like to remove?");
                        string door = Console.ReadLine();
                        if (badgeToUpdate.badgeAccess.Contains(door))
                        {
                            badgeToUpdate.badgeAccess.Remove(door);
                            Console.WriteLine("\nRemove another door?");
                            string response = Console.ReadLine().ToLower();

                            if (response == "n" || response == "no")
                            {
                                moreDoors = false;
                            }
                            else if (response != "y" && response != "yes")
                            {
                                Console.WriteLine("\nPlease enter [y] or [n]");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Badge # {badgeToUpdate.badgeID} does not currently have access to that door.\n" +
                                $"Please try again.");
                            Console.ReadLine();
                            Console.Clear();
                        }

                    }
                    break;
                default:
                    Console.WriteLine("Please enter a valid option.");
                    Console.ReadLine();
                    Console.Clear();
                    break;
            }
            return badgeToUpdate;
        }

        public Dictionary<int, List<string>> GetRepoToView(BadgesRepo repoToView)
        {
            return repoToView._allBadges;
        }
    }
}
