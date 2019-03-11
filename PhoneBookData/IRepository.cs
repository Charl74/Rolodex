using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using PhoneBookData.EFModels;

namespace PhoneBookData
{
    public interface IRepository
    {
        List<PbUser> GetUsers();
        string AddUser(PbUser newPbUser);
        List<Entry> GetEntries(int id);
        string AddEntry(Entry newPbEntry);
        //string DeleteUser(string id);
        string DeleteEntry(int id);
        int GetUserId(string userInternalId);
    }


    public class Repository : IRepository
    {
        public List<PbUser> GetUsers()
        {
            using (var ctxModel = new PhoneBookModel())
            {
                var users = (from u in ctxModel.Users
                    select u).ToList();
                return users.Count > 0 ? users : new List<PbUser>();
            }
        }

        public string AddUser(PbUser newPbUser)
        {
            try
            {
                using (var ctxModel = new PhoneBookModel())
                {
                    var existingUser = ctxModel.Users.FirstOrDefault(x=> x.UserInternalId == newPbUser.UserInternalId);
                    if (existingUser == null)
                    {
                        ctxModel.Users.Add(newPbUser);
                    }
                    else
                    {
                        if (existingUser.User != newPbUser.User)
                        {
                            existingUser.User = newPbUser.User;
                        }
                    }
                    ctxModel.SaveChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Entry> GetEntries(int id)
        {
            using (var ctxModel = new PhoneBookModel())
            {
                var entries = (from u in ctxModel.Entries
                             where u.UserId == id
                             select u).ToList();
                return entries.Count > 0 ? entries : new List<Entry>();
            }
        }

        public string AddEntry(Entry newPbEntry)
        {
            try
            {
                using (var ctxModel = new PhoneBookModel())
                {
                    var existingEntry =
                        ctxModel.Entries.FirstOrDefault(
                            x => x.UserId == newPbEntry.UserId && x.Person == newPbEntry.Person);
                    if (existingEntry == null)
                    {
                        ctxModel.Entries.Add(newPbEntry);
                    }
                    else
                    {
                        existingEntry.Number = newPbEntry.Number;
                    }
                    ctxModel.SaveChanges();
                }
                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //public string DeleteUser(string id)
        //{
        //    try
        //    {
        //        using (var ctxModel = new PhoneBookModel())
        //        {
        //            ctxModel.Entries.RemoveRange(ctxModel.Entries.Where(e => e.Entry.UserId == id).ToList());
        //            ctxModel.Users.Remove(ctxModel.Users.Single(x=> x.PbUser.Id ==id));
        //            ctxModel.SaveChanges();
        //            return "Success";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}

        public string DeleteEntry(int id)
        {
            try
            {
                using (var ctxModel = new PhoneBookModel())
                {
                    ctxModel.Entries.Remove(ctxModel.Entries.Single(e => e.Id == id));
                    ctxModel.SaveChanges();
                    return "Success";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public int GetUserId(string userInternalId)
        {
            using (var ctxModel = new PhoneBookModel())
            {
                var userId = (from u in ctxModel.Users
                              where u.UserInternalId == userInternalId
                             select u.Id).FirstOrDefault();
                return userId;
            }
        }
    }
}
