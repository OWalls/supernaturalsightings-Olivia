using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace supernaturalsightings_olivia.Areas.Identity.Data
{
    public class DataSorter : IComparer<object>
    {
        //if the items are the same, it returns a 0. if a>b it returns 1. if a<b it returns -1
        public int Compare([AllowNull] object a, [AllowNull] object b)
        {
            return a.ToString().ToLower().CompareTo(b.ToString().ToLower());
        }
    }
}
