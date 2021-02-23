namespace WIM14.Models.Contracts
{
    public interface IComment
    {
        IMember Author { get; set; }
        string Message { get; set; }
    }
}
