using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public int DeletedCountx(string p)
        {
            return _messageDal.DeletedCount(p);
        }

        public int DraftsCountx(string p)
        {
            return _messageDal.DraftsCount(p);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListDeleted(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p && x.IsDeleted == true);
        }

        public List<Message> GetListDrafts(string p)
        {
            return _messageDal.List(x => x.SenderMail == p && x.IsDraft == true);
        }

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public int ReceivedMessageCountx(string p)
        {
            return _messageDal.ReceivedMessageCount(p);
        }

        public int SendMessageCountx(string p)
        {
            return _messageDal.SendMessageCount(p);
        }
    }
}
