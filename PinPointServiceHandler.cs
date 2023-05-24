using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.Runtime;
using Amazon.PinpointSMSVoiceV2;
using Amazon.PinpointSMSVoiceV2.Model;

namespace PinPointCallerVersionOne
{
   

    public class PinPointServiceHandler : IPinPointServiceHandler
    {

        private readonly AmazonPinpointSMSVoiceV2Client _amazonPinpointSMSVoiceV2Client;
        private readonly string Voice;
        private readonly string LongCode;
        private static readonly string message = "Hi {0},There is an issue  related to your application, please check!"; //
        public PinPointServiceHandler()
        {
            _amazonPinpointSMSVoiceV2Client = new AmazonPinpointSMSVoiceV2Client();
            Voice = "Joanna";// Environment.GetEnvironmentVariable("Voice");
            LongCode = ""; //Environment.GetEnvironmentVariable("LongCode");

        }

        /// <summary>
        /// Call responsible employee with pinpoint service
        /// </summary>
        /// <param name="employeeName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="eventData">If you  want to put some information about the issue(eventdata request), you can use this parameter</param>
        /// <returns></returns>
        public SendVoiceMessageResponse SendVoiceMessage(string employeeName, string phoneNumber, EventData eventData)
        {



            SendVoiceMessageRequest sendVoiceMessageRequest = new SendVoiceMessageRequest
            {
                DestinationPhoneNumber = phoneNumber,
                OriginationIdentity = LongCode,
                VoiceId = Voice,
                MessageBodyTextType = VoiceMessageBodyTextType.TEXT,
                MessageBody = String.Format(message, employeeName)
            };
            SendVoiceMessageResponse response = _amazonPinpointSMSVoiceV2Client.SendVoiceMessageAsync(sendVoiceMessageRequest).Result;
            return response;




        }


    }

    public interface IPinPointServiceHandler
    {
        SendVoiceMessageResponse SendVoiceMessage(string employeeName, string phoneNumber, EventData eventData);
    }
}
