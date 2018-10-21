using System;

namespace epicenterWin
{
    // Attribute for marking composite key PROPERTIES in a database.

    [AttributeUsage(AttributeTargets.Property)]
    class CompositeKeyAttribute : Attribute
    {
    }
}
