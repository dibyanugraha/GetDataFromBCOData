using System.ComponentModel.DataAnnotations; 

namespace Models  
{  
    public class ItemWMS  
    {  
        [Required]
        public int KodeItem { get; set; }  
        [Required]  
        public string NamaItem { get; set; }  
        [Required]  
        public string Satuan { get; set; }
    }  
}