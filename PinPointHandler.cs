using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;

namespace PinPointCallerVersionOne
{
    public class PinPointHandler : IPinPointHandler
    {
        private readonly ILogger<PinPointHandler> Logger;
        private readonly IDynomaDBHandler _dynomaDBHandler;
        private readonly IPinPointServiceHandler _pinPointServiceHandler;
        public PinPointHandler(ILogger<PinPointHandler> logger,
            IDynomaDBHandler dynomaDBHandler,
            IPinPointServiceHandler pinPointServiceHandler)
        {
            Logger = logger;
            _dynomaDBHandler = dynomaDBHandler;
            _pinPointServiceHandler = pinPointServiceHandler;
        }
        public void Handler(EventData eventData)
        {
            try
            {
                if (eventData == null)
                    throw new NullReferenceException(nameof(eventData));
                var employees = _dynomaDBHandler.Get(string.Join(",", eventData.AlertPolicyNames));
                if (employees == null)
                    Logger.LogInformation("Responsible  employess not found");
                SendVoiceCall(eventData, employees);

            }
            catch (Exception ex)
            {
                Logger.LogError(ex.Message, ex);

            }

        }

        private void SendVoiceCall(EventData eventData, IEnumerable<NewRelicIntegration>? employees)
        {
            foreach (var item in employees)
            {
                try
                {
                    _pinPointServiceHandler.SendVoiceMessage(item.employee, item.phone_number, eventData);
                }
                catch(Exception ex)
                {
                    Logger.LogError(ex.Message, ex);
                }
            }
        }
    }
    public interface IPinPointHandler
    {
        void Handler(EventData eventData);
    }


}
