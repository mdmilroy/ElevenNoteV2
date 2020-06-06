using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    class ProgramUI
    {

        private BadgesRepo _badges = new BadgesRepo();
        private UserInputHelper _helper;

        public void Run()
        {
            
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("Welcome. Please choose option:\n" +
                    "1. Create a new badge\n" +
                    "2. View all badges \n" +
                    "3. Edit a badge \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                Console.Clear();
                switch (Convert.ToInt32(userInput))
                {
                    case 1:
                        _helper = new UserInputHelper();
                        Badges badgeToCreate = _helper.GetBadgeToCreate();
                        _badges.CreateBadge(badgeToCreate);
                        
                        if (_badges._allBadges.ContainsKey(badgeToCreate.badgeID))
                        {
                            Console.WriteLine("Your badge was successfully added.\n" +
                                "Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("Your badge could not be added. Please try again.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        _helper = new UserInputHelper();
                        if (_badges._allBadges.Count > 0)
                        {
                            Dictionary<int, List<string>> repoToView = _helper.GetRepoToView(_badges);
                            _badges.ViewAllBadges(repoToView);
                            Console.WriteLine("Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        else
                        {
                            Console.WriteLine("There are currently no badges in this system.\n" +
                                "Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        if (_badges._allBadges.Count > 0)
                        {
                            Console.WriteLine("{0, -15}", "Badge");
                            foreach (KeyValuePair<int, List<string>> item in _badges._allBadges)
                            {
                                Console.WriteLine(item.Key.ToString());
                            }

                            Console.WriteLine("Which badge would you like to edit?");
                            int badge = Convert.ToInt32(Console.ReadLine());

                            if (_badges._allBadges.ContainsKey(badge))
                            {
                                Badges badgeToUpdate = new Badges();
                                badgeToUpdate.badgeID = badge;
                                badgeToUpdate.badgeAccess = _badges._allBadges[badge];
                                _helper.GetBadgeToUpdate(badgeToUpdate);
                                _badges.EditBadge(badgeToUpdate);

                                Console.WriteLine($"Badge {badgeToUpdate.badgeID} now has access to doors {string.Join(", ", badgeToUpdate.badgeAccess)}.\n");
                                Console.ReadLine();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("That badge could not be found.\n" +
                                    "Press any key to return to the main menu.");
                                Console.ReadLine();
                                Console.Clear();
                            }
                        }
                        else
                        {
                            Console.WriteLine("There are currently no badges in this system.\n" +
                                "Press any key to return to the main menu.");
                            Console.ReadLine();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        running = false;
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please choose a valid option.\n" +
                            "Press any key to return to try again.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
