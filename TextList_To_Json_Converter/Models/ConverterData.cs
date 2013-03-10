using System;
using System.Linq;

namespace TextList_To_Json_Converter.Models
{
    public class ConverterData
    {
        public int GroupCount { get; set; }
        public string GroupItemDelimiter { get; set; }
        public string[] GroupNames { get; set; }
        public string[] GroupItemBlobs { get; set; } 
        public LineItemsCollection Collection { get; set; }
        public string Output { get; set; }

        public ConverterData()
        {
            GroupCount = 0;
            Collection = new LineItemsCollection();
            Output = String.Empty;

            Collection.Version = String.Empty;
        }
    }
}