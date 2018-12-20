using Epicenter.Domain.Abstract;
using Epicenter.Domain.Models;
using Epicenter.Domain.Models.DTO;
using Epicenter.Infrastructure;
using Epicenter.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Epicenter.Domain.Models.Abstract.MissingModel;

namespace Epicenter.Domain.Services
{
    public class PersonService
    {
        private readonly string _groupId = AppSettings.Configuration.GroupId;
        private readonly IPersonRepository _personRepository;
        private readonly FaceAPIService _faceAPIService;

        public PersonService(IPersonRepository personRepository, FaceAPIService faceAPIService)
        {
            _personRepository = personRepository;
            _faceAPIService = faceAPIService;
        }

        public List<Person> GetAllMissingPersons()
        {
            return new List<Person>(_personRepository.GetAll());
        }

        public async Task CreateAsync(PersonRequest request)
        {
            byte[] baseImage = Array.Empty<byte>();
            string faceAPIId = await _faceAPIService.CreatePersonAsync(_groupId, request.FirstName, request.LastName);
            if (await TrainFaces(faceAPIId, request.TrainingImages))
            {
                await _faceAPIService.TrainPersonGroupAsync(_groupId);
                baseImage = request.BaseImage.HasValue ? request.TrainingImages[request.BaseImage.Value].ConvertToBytesOrDefault(baseImage) : baseImage;
            }                
            _personRepository.Add(new Person()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Reason = request.Reason ?? SearchReason.Missing,
                BaseImage = baseImage,
                FaceAPIId = faceAPIId
            });
        }

        public async Task UpdateAsync(int id, PersonRequest request)
        {
            Person person = _personRepository.GetById(id);
            person.FirstName = request.FirstName ?? person.FirstName;
            person.LastName = request.LastName ?? person.LastName;
            person.Reason = request.Reason ?? person.Reason;
            byte[] baseImage = person.BaseImage;
            if (await TrainFaces(person.FaceAPIId, request.TrainingImages))
            {
                await _faceAPIService.TrainPersonGroupAsync(_groupId);
                baseImage = request.BaseImage.HasValue ? request.TrainingImages[request.BaseImage.Value].ConvertToBytesOrDefault(baseImage) : baseImage;
            }
            person.BaseImage = baseImage;
            _personRepository.Edit(person);
        }

        public async Task DeleteAsync(int id)
        {
            Person person = _personRepository.GetById(id);
            await _faceAPIService.DeletePersonAsync(_groupId, person.FaceAPIId);
            _personRepository.Delete(person);
            await _faceAPIService.TrainPersonGroupAsync(_groupId);
        }

        public async Task<bool> TrainFaces(string faceAPIId, string[] trainingImages)
        {
            bool atLeastOneFaceFound = false;
            if (trainingImages != null && trainingImages.Length > 0)
            {
                foreach (string image in trainingImages)
                {
                    try
                    {
                        byte[] imageBytes = Convert.FromBase64String(image);
                        await _faceAPIService.AddFaceToPersonAsync(_groupId, faceAPIId, imageBytes);
                        atLeastOneFaceFound = true;
                    }
                    catch
                    {
                        continue;
                    }
                };
            }
            return atLeastOneFaceFound;
        }
    }
}
