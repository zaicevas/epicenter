namespace epicenterWin
{
    class Plate : MissingEntity
    {
        [PrimaryKey]
        public string NumberPlate { get; set; }

        public Plate(string numberPlate)
        {
            NumberPlate = numberPlate;
        }

        public Plate()
        {
        }
    }
}
