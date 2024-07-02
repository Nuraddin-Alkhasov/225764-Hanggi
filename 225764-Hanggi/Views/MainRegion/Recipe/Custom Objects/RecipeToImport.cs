namespace HMI.Views.MainRegion
{
    public class RecipeToIE
    {
        public string Name { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }
        public string Extension { get; set; }
        public bool isExisting { get; set; }
        public bool isSelected { get; set; }
        public bool isImported { get; set; }
        public int Status { get; set; }
    }
}
