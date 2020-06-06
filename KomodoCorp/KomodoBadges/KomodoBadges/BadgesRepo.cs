using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadges
{
    public class BadgesRepo
    {
        public Dictionary<int, List<string>> _allBadges = new Dictionary<int, List<string>>();

        public void CreateBadge(Badges badgeToCreate)
        {
            _allBadges.Add(badgeToCreate.badgeID, badgeToCreate.badgeAccess);
        }

    
        public Dictionary<int, List<string>> ViewAllBadges(Dictionary<int, List<string>> repoToView)
        {
            Console.WriteLine("{0, -10} {1, -15}", "Badge #", "Access");
            foreach (KeyValuePair<int, List<string>> item in _allBadges)
            {
                Console.WriteLine("{0, -10} {1, -15}", item.Key, string.Join(", ", item.Value));
            }
            return _allBadges;
        }

        public void EditBadge(Badges badgeToUpdate)
        {
            _allBadges[badgeToUpdate.badgeID] = badgeToUpdate.badgeAccess;
        }
    }
}
