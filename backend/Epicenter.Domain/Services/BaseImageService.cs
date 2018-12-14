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

        public BaseImageService(IPersonRepository personRepository, IPlateRepository plateRepository)
        {
            _personRepository = personRepository;
            _plateRepository = plateRepository;
        }

        public List<MissingModelBaseImage> GetAllBaseImages()
        {
            return GetBaseImages<Person>().Concat(GetBaseImages<Plate>()).ToList();
        }

        public List<MissingModelBaseImage> GetBaseImages<T>() where T : MissingModel
        {
            IEnumerable<MissingModel> missingModels;
            if (typeof(T) == typeof(Person))
                missingModels = _personRepository.GetAll();
            else
                missingModels = _plateRepository.GetAll();
            List<MissingModelBaseImage> baseImages = new List<MissingModelBaseImage>();
            missingModels.ToList().ForEach(missingModel =>
            {
                baseImages.Add(new MissingModelBaseImage()
                {
                    Id = missingModel.Id,
                    BaseImage = missingModel.BaseImage
                });
            });
            return baseImages;
        }
    }
}
