using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using WasteWiseFunctions.business;

namespace WasteWiseFunctions
{
    public class InvoiceFunction
    {
        private readonly ILogger<InvoiceFunction> _logger;

        public InvoiceFunction(ILogger<InvoiceFunction> log)
        {
            _logger = log;
        }

        [FunctionName("InvoiceFunction")]
        public void Run([ServiceBusTrigger("topic", "invoice", Connection = "ServiceBusConnection")] ServiceBusMessage message)
        {
            //here goes invoice logic
            UserAccount user = new UserAccount();
            //TODO!!
            

            var sensorReading = JsonConvert.DeserializeObject<SensorData>(Encoding.UTF8.GetString(message.Body));
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");
        }
    }
}
