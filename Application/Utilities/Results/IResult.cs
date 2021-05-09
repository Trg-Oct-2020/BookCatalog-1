namespace BookCatalog.MicroService.Application.Utilities.Results
{
    public interface IResult
    {
        bool Success { get; }
        string Messages { get; }
    }
}
