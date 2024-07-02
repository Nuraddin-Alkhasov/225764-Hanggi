namespace HMI.Views.MainRegion
{
    class Barcode
    {
        public Barcode()
        {
            Id = -1;
            BC = "";
            MR_Name = "";
        }
        public long Id { set; get; }
        public string BC { set; get; }
        public string MR_Name { set; get; }
    }
}
