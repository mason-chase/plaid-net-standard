namespace Mc2.Plaid.Career.Endpoints
{
    public interface IResponse<out TData>
    {
        bool Success { get; }
        TData Data { get; }
    }
}
