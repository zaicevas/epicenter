using System.Collections;
using System.Collections.Generic;

public class PlateDatabase : IEnumerable<string>
{
    private readonly string[] _plates =
    {
        "ABC123",
        "DEF456",
    };

    public PlateDatabase()
    {
    }

    public string this[int index]
    {
        get { return _plates[index]; }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    IEnumerator<string> GetEnumerator()
    {
        foreach (string str in _plates)
            yield return str;
    }

    IEnumerator<string> IEnumerable<string>.GetEnumerator()
    {
        return GetEnumerator();
    }
}
