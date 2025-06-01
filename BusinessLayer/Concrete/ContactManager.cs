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
    public class ContactManager : IContactService
    {
        IContactDal _contact;

        public ContactManager(IContactDal contact)
        {
            _contact = contact;
        }

        public void ContactAdd(Contact contact)
        {
            _contact.Insert(contact);
        }

        public int ContactCountx()
        {
            return _contact.ContactCount();
        }

        public void ContactDelete(Contact contact)
        {
            _contact.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            _contact.Update(contact);
        }

        public Contact GetById(int id)
        {
            return _contact.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return _contact.List();
        }
    }
}
