using Epicenter.Domain.Abstract;
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

        public List<MissingModelBaseImage> GetSeenBaseImages()
        {
            List<MissingModel> seenMissingModels = _timestampRepository.GetAll().Select(x => x.MissingModel).Distinct().ToList();
            List<MissingModelBaseImage> seenBaseImages = new List<MissingModelBaseImage>();
            seenMissingModels.ForEach(missingModel =>
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
