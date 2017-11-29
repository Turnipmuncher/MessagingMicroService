using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MessagingService.Models;
using MessagingService.Contexts;

namespace MessagingService.Respsitory
{
    public class MessageRepository : IMessageRepository
    {
        //static List<Message> MessageList = new List<Message>();
        MessageContext _context;

        public MessageRepository(MessageContext context)
        {
            _context = context;
        }
        public void Add(Message item)
        {
            _context.Message.Add(item);
            _context.SaveChanges();

           // MessageList.Add(item);
        }

        public Message Find(string key)
        {
            return _context.Message
                .Where(e => e.id.Equals(key))
                .SingleOrDefault();
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Message.ToList();

            //return MessageList;
        }

        public void remove(string id)
        {
            var ItemToRemove = _context.Message.SingleOrDefault(r => r.id == id);
            if (ItemToRemove != null)
                _context.Message.Remove(ItemToRemove);
                _context.SaveChanges();

                //MessageList.Remove(ItemToRemove);
        }

        public void Update(Message item)
        {
            var ItemToUpdate = _context.Message.SingleOrDefault(r => r.id == item.id);
            if (ItemToUpdate != null)
            {
                ItemToUpdate.isDraft = item.isDraft;
                ItemToUpdate.message = item.message;
                ItemToUpdate.id = item.id;
                ItemToUpdate.recipient = item.recipient;
                ItemToUpdate.sender = item.sender;
                ItemToUpdate.subject = item.subject;
                _context.SaveChanges();
            }

        }
    }
}
