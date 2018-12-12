using System;

namespace Epicenter.Domain.Models.Attributes.Database
{
    // Use this to mark properties/fields that are not part of database

    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class NonDatabaseAttribute : Attribute
    {
    }
}
