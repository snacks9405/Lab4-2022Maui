using System.Collections.ObjectModel;

namespace Lab2Solution
{
    public interface IDatabase
    {
        void AddEntry(Entry entry);
        bool DeleteEntry(Entry entry);
        Entry FindEntry(int id);
        ObservableCollection<Entry> GetEntries(String sortBy);
        bool EditEntry(Entry replacementEntry);
    }
}