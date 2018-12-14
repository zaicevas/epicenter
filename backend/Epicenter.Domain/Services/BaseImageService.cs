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
        private readonly ITimestampRepository _timestampRepository;

        public BaseImageService(ITimestampRepository timestampRepository)
        {
            _timestampRepository = timestampRepository;
        }

        public List<MissingModelBaseImage> GetAllSeenBaseImages()
        {
            List<MissingModel> seenMissingModels = _timestampRepository.GetAll().Select(x => x.MissingModel).Distinct().ToList();
            return TakeBaseImages(seenMissingModels);
        }

        public List<MissingModelBaseImage> GetSeenBaseImages<T>() where T : MissingModel
        {
            List<MissingModel> seenMissingModels;
            if (typeof(T) == typeof(Person))
                seenMissingModels = _timestampRepository.GetAll().Where(x => x.MissingModel.GetType() == typeof(Person)).Select(x => x.MissingModel).Distinct().ToList();
            else
                seenMissingModels = _timestampRepository.GetAll().Where(x => x.MissingModel.GetType() == typeof(Plate)).Select(x => x.MissingModel).Distinct().ToList();
            return TakeBaseImages(seenMissingModels);
        }

        private List<MissingModelBaseImage> TakeBaseImages(List<MissingModel> missingModels)
        {
            List<MissingModelBaseImage> seenBaseImages = new List<MissingModelBaseImage>();
            missingModels.ForEach(missingModel =>
            {
                seenBaseImages.Add(new MissingModelBaseImage()
                {
                    Id = missingModel.Id,
                    BaseImage = missingModel.BaseImage
                });
            });
            return seenBaseImages;
        }
    }
}
