using System;

namespace HMI.Views.MainRegion
{
    public class MachineRecipe 
    {
        public string Name { get; set; }
        public string Note { get; set; }
        public string Parts { get; set; }
        public string Article { get; set; }
        public DateTime LastChanged { get; set; }
        public string User { get; set; }

    }
}
