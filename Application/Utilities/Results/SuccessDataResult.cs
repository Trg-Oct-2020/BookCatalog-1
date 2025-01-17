﻿namespace BookCatalog.MicroService.Application.Utilities.Results
{
    public class SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data) : base(data, true)
        {
        }

        public SuccessDataResult(T data, string messages) : base(data, true, messages)
        {
        }
        public SuccessDataResult() : base(default, true)
        {

        }
        public SuccessDataResult(string messages) : base(default, true, messages)
        {

        }
    }
}
