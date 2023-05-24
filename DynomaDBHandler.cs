using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

namespace PinPointCallerVersionOne
{
   

    public class DynomaDBHandler: IDynomaDBHandler
    {

        private readonly AmazonDynamoDBClient _amazonDynamoDbClient;
        public DynomaDBHandler()
        {
            _amazonDynamoDbClient = new AmazonDynamoDBClient();

        }
        /// <summary>
        /// Get Responsible employees based on policy key
        /// </summary>
        /// <param name="policyKey"> Comes from request</param>
        /// <returns></returns>
        public  IEnumerable<NewRelicIntegration> Get(string policyKey)
        {

            using (var _context = new DynamoDBContext(_amazonDynamoDbClient))
            {
                var scanConditions = new List<ScanCondition>() { new ScanCondition("policy_key", ScanOperator.Contains, policyKey) };
                return _context.ScanAsync<NewRelicIntegration>(scanConditions).GetRemainingAsync().Result;
            }
        }
       
    
    }

    public interface IDynomaDBHandler
    {
        IEnumerable<NewRelicIntegration> Get(string policyKey);
    }
}
