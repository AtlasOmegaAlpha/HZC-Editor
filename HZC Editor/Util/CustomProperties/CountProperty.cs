using System.ComponentModel;

public class CountProperty<T>
{
    private readonly List<T> _list;

    public CountProperty(List<T> list)
    {
        _list = list;
    }

    [ReadOnly(true)]
    public int Count => _list.Count;
}
