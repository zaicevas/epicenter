namespace epicenterWin
{
    public abstract class DbEntity
    {
        [UnecessaryColumn]
        public int ID { get; set; }
    }
}