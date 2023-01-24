using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace supernaturalsightings_olivia.Areas.Identity.Data
{
    public class UsernameSorter : IComparer<object>
    {
        public int Compare([AllowNull] object x, [AllowNull] object y)
        {
            return x.ToString().ToLower().CompareTo(y.ToString().ToLower());
        }
    }
}
