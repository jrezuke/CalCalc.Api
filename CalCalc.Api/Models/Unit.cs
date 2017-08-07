using System.Collections.Generic;

namespace CalCalc.Api.Models
{
    public class Unit
    {
        public Unit()
        {
            AdditiveList = new HashSet<AdditiveList>();
        } 
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<AdditiveList> AdditiveList {get; set;}
    }
}