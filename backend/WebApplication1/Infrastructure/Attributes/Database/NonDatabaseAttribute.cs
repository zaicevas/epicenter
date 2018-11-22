using System;

namespace WebApplication1.Attributes.Database
{
    // Use this to mark properties/fields that are not part of database

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    class NonDatabaseAttribute : Attribute
    {
    }
}
