using System.Collections.ObjectModel;
using System.Data.Entity;

namespace CitizensWeb.Tests
{
    public class TestDbSet<T> : DbSet<T>
        where T : class
    {
        ObservableCollection<T> _data;

        public TestDbSet()
        {
            _data = new ObservableCollection<T>();
        }

        public override T Add(T item)
        {
            _data.Add(item);
            return item;
        }

        public override T Remove(T item)
        {
            _data.Remove(item);
            return item;
        }

        public override T Attach(T item)
        {
            _data.Add(item);
            return item;
        }

        public int getCount()
        {
            return _data.Count;
        }
    }
}
