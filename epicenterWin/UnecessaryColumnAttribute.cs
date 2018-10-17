using System;

namespace epicenterWin
{
    // Attribute for marking PROPERTIES which are not part of database OR are database's metadata (e.g. ID)

    [AttributeUsage(AttributeTargets.Property)]
    class UnecessaryColumnAttribute : Attribute
    {
    }
}
