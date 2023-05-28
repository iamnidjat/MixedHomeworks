using NotePad.Models;
using System.Collections.ObjectModel;
using System.IO;

namespace NotePad.Services
{
    public class NotePad : INotePad
    {
        private ObservableCollection<NotePadItem> _items = new();

        public NotePad()
        {
            _items.Add(new NotePadItem()
            {
                Title = "Example",
                Description = "Do smth",
                Created = DateTime.Now,
                Tags = "#example"
            });
        }

        public void AddItem(NotePadItem item)
        {
            _items.Add(item);

            WriteToFileAsync();
        }

        public void EditItem(int index, NotePadItem item)
        {
            if (index < 0 || index >= _items.Count)
            {
                return;
            }

            _items[index]= item;

            WriteToFileAsync();
        }

        public void RemoveItem(int index)
        {
            if (index < 0 || index >= _items.Count)
            {
                return;
            }

            _items.RemoveAt(index);

            WriteToFileAsync();
        }

        public IEnumerable<NotePadItem> GetItems()
        {
            for (int i = 0; i < _items.Count; i++)
            {
                yield return _items[i];
            }
        }

        public async void WriteToFileAsync()
        {
            using (StreamWriter writer = new("MyNotePad.txt", true))
            {
                foreach (var items in _items)
                {
                    await writer.WriteLineAsync($"Title: ${items.Title}\nDescription: ${items.Description}\nCreated: ${items.Created}\nTags: ${items.Tags}\n");
                }

                writer.Close();
            }
        }
    }
}