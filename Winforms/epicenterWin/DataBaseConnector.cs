﻿using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.Linq;

namespace epicenterWin
{
    static class DataBaseConnector
    {
        public static Person FindPerson(string firstName, string lastName)
        {
            Person temporaryPerson = new Person(firstName, lastName);
            return SqliteDataAccess<Person>.ReadByKey<CompositeKeyAttribute>(temporaryPerson);
        }

        public static void UpdateYML(Person person, string fullPath)
        {
            person.YML = fullPath;
            SqliteDataAccess<Person>.UpdatePerson(person);
        }

        public static List<Person> LoadAllPeople()
        {
            return SqliteDataAccess<Person>.ReadRows().ToList();
        }

        public static void SaveNewFaces(List<Image<Gray, byte>> faces, int ID)
        {
            foreach (Image<Gray, byte> image in faces)
            {
                Face face = new Face
                {
                    Blob = image.Bytes,
                    PersonID = ID
                };
                SqliteDataAccess<Face>.CreateRow(face);
            }
        }

        public static void LoadAllFaces(List<Image<Gray, byte>> faces, List<int> ids, int currentID, int imgWidth, int imgHeight)
        {
            List<Face> trainedFaces = SqliteDataAccess<Face>.ReadRows().ToList();
            foreach (Face face in trainedFaces.Where(f => f.PersonID == currentID))
            {
                Image<Gray, byte> image = new Image<Gray, byte>(imgWidth, imgHeight)
                {
                    Bytes = face.Blob
                };
                faces.Add(image);
                ids.Add(currentID);
            }
        }
    }
}
