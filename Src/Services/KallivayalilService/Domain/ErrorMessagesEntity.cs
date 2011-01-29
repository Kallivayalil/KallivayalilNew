using System;
using System.Collections;
using System.Collections.Generic;

namespace Kallivayalil.Domain
{
    [Serializable]
    public class ErrorMessagesEntity : IEnumerable<ErrorMessageEntity>
    {
        public List<ErrorMessageEntity> Errors { get; set; }

        public ErrorMessagesEntity()
        {
            Errors = new List<ErrorMessageEntity>();
        }

        public bool IsValid
        {
            get { return Errors.Count == 0; }
        }

        public int Count
        {
            get { return Errors.Count; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(ErrorMessageEntity errorMessage)
        {
            if (!Errors.Contains(errorMessage)) Errors.Add(errorMessage);
        }

        public void AddError(string errorCode, string description, string propertyPath)
        {
            var message = new ErrorMessageEntity { Code = errorCode, Description = description, ErrorPath = propertyPath };
            Add(message);
        }

        public void AddError(string errorCode, string propertyPath)
        {
            AddError(errorCode, null, propertyPath);
        }

        public IEnumerator<ErrorMessageEntity> GetEnumerator()
        {
            return Errors.GetEnumerator();
        }

        public ErrorMessageEntity this[int i]
        {
            get { return Errors[i]; }
        }

        public void AddRange(ErrorMessagesEntity errorMessages)
        {
            errorMessages.Errors.ForEach(Add);
        }
    }
}