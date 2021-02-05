using GooglesRival.Models;
using System.Collections.Generic;

namespace GooglesRival.Services
{
    public interface IMessageService
    {
        Message GetMessageById(string id);
        List<Message> GetMessagesForUser(string username);
    }
}