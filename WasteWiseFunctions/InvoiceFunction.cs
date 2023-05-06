using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

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
        public void Run([ServiceBusTrigger("topic", "invoice", Connection = "ServiceBusConnection")] ServiceBusMessage mySbMsg)
        {
            //here goes invoice logic
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {mySbMsg}");
        }
    }
}
