using System;
using System.Collections.Generic;

namespace PhoneBook.DM
{
    public interface IOperations
    {
        //List<DmUser> GetUsers();
        //string AddUser(DmUser newUser);
        List<DmEntry> GetEntries(string userInternalId);
        string AddEntry(DmEntryEx newEntry);
        //string DeleteUser(string id);
        string DeleteEntry(int id);
    }
}