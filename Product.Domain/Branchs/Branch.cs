using Product.Domain.Barcodes;
using Product.Domain.Common;

namespace Product.Domain.Branchs
{
    public class Branch:IAuditable
    {


        public int Id { get; private set; }
        public string BranchName { get; private set; }
        public string? BranchAddress { get; private set; }
        public string? BranchPhone { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? LastUpdate { get; private set; }
        /*
         👉👈 مش عارف ايه الداتا اللي ممكن اخزنهاله فهسيبه بصراحة 
         */


        public Branch(string branchName, string? branchPhone = null, string? branchAddress = null)
        {
            BranchName = branchName;
            BranchPhone = branchPhone;
            BranchAddress = branchAddress;
        }



        public ICollection<PriceAccordingToBranch> PriceByBranches { get; private set; } = new List<PriceAccordingToBranch>();

    }
}
