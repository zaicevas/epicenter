using System;

namespace Epicenter.Domain.Models.Attributes.Database
{
    // Attribute for marking composite key PROPERTIES in a database.

    [AttributeUsage(AttributeTargets.Property)]
    public class CompositeKeyAttribute : Attribute
    {
    }
}
