using System.Text;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            var sensorReading = JsonConvert.DeserializeObject<SensorData>(Encoding.UTF8.GetString(message.Body));
            UserAccount user = new UserAccount();
            var userId = user.GetUserForSensor(sensorReading.Id);
            //TODO: process invoice
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");
        }
    }
}
