using System;

namespace WebApplication1.Attributes.Database
{
    // Attribute for marking composite key PROPERTIES in a database.

    [AttributeUsage(AttributeTargets.Property)]
    class CompositeKeyAttribute : Attribute
    {
    }
}
