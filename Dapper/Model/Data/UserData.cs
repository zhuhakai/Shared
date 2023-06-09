using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DbAccess;
using DataAccess.Model;

namespace DataAccess.Data;
public class UserData : IUserData
{
    private readonly ISqlDataAccess _db;

    public UserData(ISqlDataAccess db)
    {
        _db = db;
    }

    public async Task<IEnumerable<UserModel>> GetUsers() =>
        await _db.LoadData<UserModel, dynamic>("dbo.spUser_GetAll", new { }).ConfigureAwait(false);


    public async Task<UserModel?> GetUser(int id)
    {
        var r = await _db.LoadData<UserModel, dynamic>("dbo.spUser_Get", new { Id = id }).ConfigureAwait(false);
        return r.FirstOrDefault();
    }

    public async Task InsertUser(UserModel user) =>
        await _db.SaveData("dbo.spUser_Insert", new { FirstName = user.FirstName, LastName = user.LastName }).ConfigureAwait(false);

    public async Task UpdateUser(UserModel user) =>
        await _db.SaveData("dbo.spUser_Update", user).ConfigureAwait(false);

    public async Task DeleteUser(int id) =>
        await _db.SaveData("dbo.spUser_Delete", new { Id = id }).ConfigureAwait(false);
}
