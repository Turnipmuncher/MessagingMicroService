using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingService.Models;

namespace MessagingService.Respsitory
{
    public interface IMessageRepository
    {
        void Add(Message item);
        IEnumerable<Message> GetAll();
        Message Find(string key);
        void remove(string id);
        void Update(Message item);
    }
}
