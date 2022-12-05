using Xunit;
using Data.Entities;

namespace ECommerce.Tests.Data;
public class LogTest
{
    [Fact]
    public void Create()
    {
        DateTime now = new DateTime();
        Log log = new Log {
            Id = 11,
            Message = "Log message",
            MessageTemplate = "Message template",
            Level = "Level",
            TimeStamp = now,
            Exception = "Exception",
            Properties = "Properties"
        };

        Assert.Equal(log.Id, 11);
        Assert.Equal(log.Message, "Log message");
        Assert.Equal(log.MessageTemplate, "Message template");
        Assert.Equal(log.Level, "Level");
        Assert.Equal(log.TimeStamp, now);
        Assert.Equal(log.Exception, "Exception");
        Assert.Equal(log.Properties, "Properties");
    }
}