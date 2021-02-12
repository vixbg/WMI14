using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.Contracts
{
    public interface IBoard
    {
        public string Name { get; set; }
        public Type Type { get; }
        public string ShowInfo();
        public string ShowActivityHistory();
    }
}
