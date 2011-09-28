using System.Collections.Generic;
using Kallivayalil.Domain;
using NHibernate;

namespace Kallivayalil.DataAccess.Repositories
{
    public class UploadFileRepository : Repository
    {
        public UploadFileRepository(ISession session) : base(session) {}
        public UploadFileRepository() : base(SessionFactory.OpenSession()) {}

        public Upload Save(Upload file)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedUpload = SaveOrUpdate(file, txn);
                txn.Commit();
                return savedUpload;
            }
        }


        public Upload Update(Upload entity)
        {
            using (var txn = session.BeginTransaction())
            {
                var savedUpload = SaveOrUpdate(entity, txn);
                txn.Commit();
                return savedUpload;
            }
        }

        public Upload Load(int id)
        {
            return session.Get<Upload>(id);
        }

        public IList<Upload> LoadAll()
        {
            var criteria = session.CreateCriteria<Upload>();
            return criteria.List<Upload>();
        }

        public void Delete(int id)
        {
            using (var txn = session.BeginTransaction())
            {
                var upload = Load(id);
                if (upload != null)
                {
                    session.Delete(upload);
                }
                txn.Commit();
            }
        }
        
    }
}