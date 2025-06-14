﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        void MessageAdd(Message message);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        int SendMessageCountx(string p);
        int ReceivedMessageCountx(string p);
        int DraftsCountx(string p);
        int DeletedCountx(string p);
        List<Message> GetListDrafts(string p);
        List<Message> GetListDeleted(string p);
    }
}
