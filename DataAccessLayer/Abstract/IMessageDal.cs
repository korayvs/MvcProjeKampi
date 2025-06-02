using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IMessageDal : IRepository<Message>
    {
        int ReceivedMessageCount(string p);
        int SendMessageCount(string p);
        int DraftsCount(string p);
        int DeletedCount(string p);
    }
}
