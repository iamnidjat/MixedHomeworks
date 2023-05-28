using NotePad.Models;

namespace NotePad.Services
{
    public interface INotePad
    {
        void AddItem(NotePadItem item);
        void RemoveItem(int index);
        void EditItem(int index, NotePadItem item);
        IEnumerable<NotePadItem> GetItems();
        void WriteToFileAsync();
    }
}
