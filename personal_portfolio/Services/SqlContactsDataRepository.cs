
using Microsoft.EntityFrameworkCore;
using Personal_Portfolio.Data;
using Personal_Portfolio.Models;

namespace Personal_Portfolio.Services;


public class SqlContactsDataRepository : IContactsDataRepository<ContactMeModel>
{
    private readonly ContactContext db;
    private readonly ILogger<SqlContactsDataRepository> logger;

    public SqlContactsDataRepository(ContactContext db, ILogger<SqlContactsDataRepository> logger)
    {
        this.db = db;
        this.logger = logger;
    }

    public int Commit()
    {
        return db.SaveChanges();
    }

    public ContactMeModel? Delete(int id)
    {
        var model = GetById(id);
        if (model is null)
        {
            logger.LogInformation("Deletion failed :(. Couldn't find model.");
            return model;
        }

        db.ContactDb.Remove(model);

        Commit();

        return model;
    }

    public ContactMeModel? GetById(int id)
    {
        return db.ContactDb.Find(id);
    }

    public IEnumerable<ContactMeModel> GetData(string name)
    {
        var query = from m in db.ContactDb
                    where m.name!.StartsWith(name) || string.IsNullOrEmpty(name)
                    orderby m.name
                    select m;
        return query;
    }

    public IEnumerable<ContactMeModel> GetData()
    {
        var query = from m in db.ContactDb
                    select m;
        return query;
    }

    public ContactMeModel PostData(ContactMeModel model)
    {
        db.Add(model);
        Commit();
        return model;
    }

    public ContactMeModel Update(ContactMeModel model)
    {
        var entity = db.ContactDb.Attach(model);
        entity.State = EntityState.Modified;
        Commit();
        return model;
    }

}

