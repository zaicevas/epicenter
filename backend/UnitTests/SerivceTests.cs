using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebApplication1.Models.Responses;
using WebApplication1.Services;
using WebApplication1.Repositories;
using WebApplication1.Models.Abstract;
using WebApplication1.Mappers;
using Xunit;
using WebApplication1.Models;

namespace UnitTests
{
    public class SerivceTests
    {
        [Fact]
        public void FaceServiceTest()
        {
            string base64 = null;
            using (StreamReader reader = new StreamReader("trump_base64.txt"))
            {
                base64 = reader.ReadToEnd();
            }
            Mapper<Person> personMapper = new Mapper<Person>();
            Mapper<Timestamp> timestampMapper = new Mapper<Timestamp>();
            TimestampRepository timestamprepo =  new TimestampRepository(timestampMapper);
            PersonRepository personRepo = new PersonRepository(personMapper);
            
            FaceService faceService = new FaceService(new FaceAPIService(), personRepo, timestamprepo);
            Task<List<RecognizedObject>> resultTask = faceService.RecognizeAsync(base64);
            resultTask.Wait();
            List<RecognizedObject> result = resultTask.Result;
            bool foundDonald = result.TrueForAll(ro => ro.FirstName == "Donald" && 
                                                       ro.LastName == "Trump");
            Assert.True(foundDonald);
        }
    }
}
