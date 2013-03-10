using System;
using System.Collections.Generic;
using System.Linq;

namespace TextList_To_Json_Converter.Models
{
    public class LineItemsCollection
    {
        public String Version { get; set; }
        public List<Group> Groups { get; set; } 
        public List<Item> Items { get; set; }

        public class Group
        {
            public int GroupId { get; set; }
            public String Name { get; set; }
        }

        public class Item
        {
            public String Content { get; set; }
            public int ParentGroupId { get; set; }
        }
    }
}