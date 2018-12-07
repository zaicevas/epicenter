using System;

namespace Epicenter.Domain.Models.Attributes.Database
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PrimaryKeyAttribute : Attribute
    {
    }
}
