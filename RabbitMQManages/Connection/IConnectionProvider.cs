using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace RabbitMQManages.Connection
{
    public interface IConnectionProvider : IDisposable
    {
        IConnection GetConnection();
    }
}
