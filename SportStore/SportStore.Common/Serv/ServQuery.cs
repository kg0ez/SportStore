using System;
namespace SportStore.Common
{
    [Serializable]
    public class ServQuery
    {
        public QueryType Type { get; set; }

        public string TypeAction { get; set; }

        public string Object { get; set; }
    }
}

