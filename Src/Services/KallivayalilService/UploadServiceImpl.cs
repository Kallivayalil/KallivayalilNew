using System;
using System.Collections.Generic;
using Kallivayalil.DataAccess.Repositories;
using Kallivayalil.Domain;

namespace Kallivayalil
{
    public class UploadServiceImpl 
    {
        private readonly UploadFileRepository repository;

        public UploadServiceImpl(UploadFileRepository repository) 
        {
            this.repository = repository;
        }

        public Upload CreateUploadFile(Upload uploadFile)
        {
            return repository.Save(uploadFile);
        }


        public Upload UpdateUploadFile(Upload upload)
        {
            return repository.Update(upload);
        }

        public void DeleteUpload(string id)
        {
            repository.Delete(Convert.ToInt32(id));
        }

        public IList<Upload> FindUploadFiles()
        {
            return repository.LoadAll<Upload>();
        }

        public Upload FindUploadFile(string id)
        {
            return repository.Load(Convert.ToInt32(id));
        }


    }
}