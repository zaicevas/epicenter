using System;
using System.ComponentModel.DataAnnotations.Schema;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Infrastructure.Extensions;
using Newtonsoft.Json;

namespace Epicenter.Domain.Models
{
    public class Timestamp : Model
    {
        public string DateAndTime { get; set; }

        public int MissingModelId { get; set; }
        public MissingModel MissingModel { get; set; }

        [JsonIgnore]
        [NotMapped]
        public DateTime DateTime => DateAndTime.ParseToDateTime();

        public Timestamp(int missingModelId, string dateAndTime)
        {
            MissingModelId = missingModelId;
            DateAndTime = dateAndTime;
        }

        public Timestamp()
        {
        }
    }
}