using Azure.Messaging.ServiceBus;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading.Tasks;

namespace WasteWiseFunctions
{
    public class NotificationsFunction
    {
        private readonly ILogger<NotificationsFunction> _logger;

        public NotificationsFunction(ILogger<NotificationsFunction> log)
        {
            _logger = log;
        }

        [FunctionName("NotificationsFunction")]
        public async Task Run([ServiceBusTrigger("topic", "notifications", Connection = "ServiceBusConnection")]ServiceBusMessage message)
        {
            _logger.LogInformation($"C# ServiceBus topic trigger function processed message: {message}");
            try
            {
                // Deserialize the message body to a SensorReading object
                var sensorReading = JsonConvert.DeserializeObject<SensorData>(Encoding.UTF8.GetString(message.Body));

                // Get the user ID that the sensor belongs to
                var userId = GetUserForSensor(sensorReading.Id);

                //Send notification
                switch (sensorReading.Type)
                {
                    case "ultrasonic":
                        await SendNotificationToUser(userId, sensorReading.Type);
                        await SendNotificationToNG(userId);
                        break;
                    case "color":
                        await SendNotificationToUser(userId, sensorReading.Type);
                        break;
                }

                _logger.LogInformation($"Sent {sensorReading.Type} notification to user {userId} for sensor {sensorReading.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing message");
                throw;
            }
        }

        private async Task SendNotificationToNG(string userId)
        {
            //Send notification to NG that trash can is full
            throw new NotImplementedException();
        }

        private string GetUserForSensor(string sensorReadingId)
        {
            //Fetch user from DB that the sensor belongs to
            throw new NotImplementedException();
        }

        private async Task SendNotificationToUser(string userId, string notificationType)
        {
            //Send the specific type of notification to user
            throw new NotImplementedException();
        }

    }
}
