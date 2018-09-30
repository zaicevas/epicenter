using System;
using System.Collections;

public class PlateDatabase : IEnumerable<string>
{
    public PlateDatabase()
    {

    }

    public string this[int index]
    {
        get { return null; }
        set { }
    }

    System.Collections.IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    IEnumerator<string> GetEnumerator()
    {
        //foreach var in db yield return var
        yield return "NaN";
    }

}
