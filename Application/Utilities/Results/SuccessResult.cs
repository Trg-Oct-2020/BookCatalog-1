namespace BookCatalog.MicroService.Application.Utilities.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string messages) : base(true, messages)
        {
        }
    }
}
