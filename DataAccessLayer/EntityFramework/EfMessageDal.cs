using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<Message>, IMessageDal
    {
        public int ReceivedMessageCount(string p)
        {
            return _object.Count(x => x.ReceiverMail == p && x.IsDeleted == false);
        }

        public int SendMessageCount(string p)
        {
            return _object.Count(x => x.SenderMail == p && x.IsDeleted == false && x.IsDraft == false);
        }

        public int DraftsCount(string p)
        {
            return _object.Count(x => x.SenderMail == p && x.IsDeleted == false && x.IsDraft == true);
        }

        public int DeletedCount(string p)
        {
            return _object.Count(x => x.ReceiverMail == p && x.IsDeleted == true && x.IsDraft == false);
        }
    }
}
