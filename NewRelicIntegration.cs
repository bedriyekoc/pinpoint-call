using Amazon.DynamoDBv2.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinPointCallerVersionOne
{
    /// <summary>
    /// Dynamo db table declaration
    /// </summary>

    [DynamoDBTable("new_relic_integration")]
    public class NewRelicIntegration
    {
        [DynamoDBHashKey("id")]
        public int Id { get; set; }

        public string policy_key { get; set; }

        public string employee { get; set; }

        public string phone_number { get; set; }

        public bool is_deleted { get; set; }

        public int order { get; set; }
    }
}
