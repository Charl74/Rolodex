using System.Collections.Generic;
using PhoneBookData;
using PhoneBookData.EFModels;

namespace PhoneBook.DM
{
    public class Operations : IOperations
    {

        private readonly IRepository _repository;

        public Operations(IRepository repository)
        {
            _repository = repository;
        }

        public List<DmUser> GetUsers()
        {
            var users = _repository.GetUsers();
            var userList = new List<DmUser>();
            if (users.Count <= 0) return new List<DmUser>();
            foreach (var user in users)
            {
                var newUser = new DmUser()
                {
                    Id = user.Id,
                    UserName = user.User
                };
                userList.Add(newUser);
            }
            return userList;
        }

        public string AddUser(DmUser newUser)
        {
            var newPbUser = new PbUser()
            {
                User = newUser.UserName,
                UserInternalId = newUser.InternalId
            };
            return _repository.AddUser(newPbUser);

        }

        public List<DmEntry> GetEntries(string userInternalId)
        {
            var entries = _repository.GetEntries(GetUserId(userInternalId));
            var entryList = new List<DmEntry>();
            if (entries.Count <= 0) return new List<DmEntry>();
            foreach (var entry in entries)
            {
                var newEntry = new DmEntry()
                {
                    Id = entry.Id,
                    Number = entry.Number,
                    Person = entry.Person,
                    UserId = entry.UserId
                };
                entryList.Add(newEntry);
            }
            return entryList;
        }

        public string AddEntry(DmEntryEx newEntry)
        {
            var user = new DmUser()
            {
                InternalId = newEntry.UserInternalId,
                UserName = newEntry.UserName
            };
            var userResult = AddUser(user);
            if (userResult == "Success")
            {
                var newUserId = GetUserId(newEntry.UserInternalId);
                var newPbEntry = new Entry()
                {
                    Number = newEntry.Number,
                    Person = newEntry.Person,
                    UserId = newUserId
                };
                
                var result = _repository.AddEntry(newPbEntry);
                return result;
            }
            return userResult;
        }

        //public string DeleteUser(string id)
        //{
        //    var result = _repository.DeleteUser(id);
        //    return result;
        //}

        public string DeleteEntry(int id)
        {
            var result = _repository.DeleteEntry(id);
            return result;
        }

        public int GetUserId(string userId)
        {
            return _repository.GetUserId(userId);
        }
    }
}
