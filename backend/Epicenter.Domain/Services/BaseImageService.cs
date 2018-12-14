using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.Abstract;
using Epicenter.Domain.Models.DTO;
using System.Collections.Generic;
using System.Linq;

namespace Epicenter.Domain.Services
{
    public class BaseImageService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IPlateRepository _plateRepository;
        private readonly ITimestampRepository _timestampRepository;

        public BaseImageService(IPersonRepository personRepository, IPlateRepository plateRepository, ITimestampRepository timestampRepository)
        {
            _personRepository = personRepository;
            _plateRepository = plateRepository;
            _timestampRepository = timestampRepository;
        }

        public List<MissingModelBaseImage> GetAllSeenBaseImages()
        {
            return GetSeenBaseImages<Person>().Concat(GetSeenBaseImages<Plate>()).ToList();
        }

        public List<MissingModelBaseImage> GetSeenBaseImages<T>() where T : MissingModel
        {
            IEnumerable<MissingModel> missingModels;
            if (typeof(T) == typeof(Person))
                missingModels = _personRepository.GetAll();
            else
                missingModels = _plateRepository.GetAll();
            List<int> seenMissingModelIds = _timestampRepository.GetAll().Select(x => x.MissingModelId).Distinct().ToList();
            List<MissingModelBaseImage> seenBaseImages = new List<MissingModelBaseImage>();
            missingModels.ToList().ForEach(missingModel =>
            {
                if (seenMissingModelIds.Contains(missingModel.Id))
                {
                    seenBaseImages.Add(new MissingModelBaseImage()
                    {
                        Id = missingModel.Id,
                        BaseImage = missingModel.BaseImage
                    });
                }
            });
            return seenBaseImages;
        }
    }
}
