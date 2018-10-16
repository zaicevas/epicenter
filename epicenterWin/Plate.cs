namespace epicenterWin
{
    class Plate : MissingEntity
    {
        public string NumberPlate { get; set; }
        public Plate(string numberPlate)
        {
            NumberPlate = numberPlate;
        }
    }
}
