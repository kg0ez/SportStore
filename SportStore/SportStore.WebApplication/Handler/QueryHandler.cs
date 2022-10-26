using System;
using System.Text.Json;
using SportStore.Common;

namespace SportStore.WebApplication.Handler
{
    public static class QueryHandler<T>
    {
        public static string Serialize(T obj, QueryType type, string someTypeAction)
        {
            ServQuery query = new ServQuery
            {
                Type = type,
                TypeAction = someTypeAction,
                Object = JsonSerializer.Serialize<T>(obj)
            };
            var json = JsonSerializer.Serialize<ServQuery>(query);
            return json;
        }
        public static string QueryTypeSerialize(T someType)
        {
            return JsonSerializer.Serialize<T>(someType);
        }
    }
}

