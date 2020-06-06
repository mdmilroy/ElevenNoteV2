using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public class Claim
    {
        public int ClaimID;
        public string ClaimType;
        public string Description;
        public double Amount;
        public DateTime DateOfAccident;
        public DateTime DateOfClaim;
        public bool IsValid;

        public Claim(int cid, string type, string descr, double amt, DateTime accident, DateTime claimed, bool validity)
        {
            ClaimID = cid;
            ClaimType = type;
            Description = descr;
            Amount = amt;
            DateOfAccident = accident;
            DateOfClaim = claimed;
            IsValid = validity;
        }

        public Claim()
        {

        }
    }
}
