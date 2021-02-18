using Type = WIM14.Models.Enums.Type;

namespace WIM14.Models.Contracts
{
    public interface IBoard
    {
        public string Name { get; set; } 
        public string ShowActivityHistory();
        void AddHistoryEntry(string v);
    }
}
