using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoClaimsDepartment
{
    public class ClaimsRepo
    {
        public List<Claim> _claims = new List<Claim>();
        public List<Claim> _claimsHandled = new List<Claim>();

        public List<Claim> ViewAllClaims(List<Claim> claimsToView)
        {
            Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}", "ClaimID", "ClaimType", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid"));
            foreach (Claim claim in claimsToView)
            {
                Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}", claim.ClaimID, claim.ClaimType, claim.Description, claim.Amount, claim.DateOfAccident.ToString("MM/dd/yyyy"), claim.DateOfClaim.ToString("MM/dd/yyyy"), claim.IsValid));
            }

            return claimsToView;
        }

        public void HandleNextClaim(Claim claimToHandle)
        {
            _claimsHandled.Add(claimToHandle);
            _claims.Remove(claimToHandle);
        }

        public void CreateNewClaim(Claim claimToAdd)
        {
            _claims.Add(claimToAdd);
        }

        public List<Claim> ViewHandledClaims(List<Claim> handledClaims)
        {
            Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}", "ClaimID", "ClaimType", "Description", "Amount", "DateOfAccident", "DateOfClaim", "IsValid"));
            foreach (Claim claim in handledClaims)
            {
                Console.WriteLine(String.Format("{0, -15} {1, -15} {2, -15} {3, -15} {4, -15} {5, -15} {6, -15}", claim.ClaimID, claim.ClaimType, claim.Description, claim.Amount, claim.DateOfAccident.ToString("MM/dd/yyyy"), claim.DateOfClaim.ToString("MM/dd/yyyy"), claim.IsValid));
            }

            return handledClaims;
        }
    }
}
