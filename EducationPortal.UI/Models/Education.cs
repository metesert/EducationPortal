using System.ComponentModel.DataAnnotations;

namespace EducationPortal.UI.Models
{
    public class Education
    {
        [Required(ErrorMessage = "Eğitim Kimliği gereklidir.")]
        public int EducationID { get; set; }
        [Required(ErrorMessage = "Eğitim Tanımı gereklidir.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kategori Tanımı gereklidir.")]
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Maliyet gereklidir.")]
        public decimal Cost { get; set; }
        [Required(ErrorMessage = "Eğitmen bilgisi gereklidir.")]
        public int EductorID { get; set; }
        [Required(ErrorMessage = "Eğitim süresi gereklidir.")]
        public TimeSpan Time { get; set; }
        [Required(ErrorMessage = "Eğitmen kapasitesi gereklidir.")]
        public int Quota { get; set; }
        [Required(ErrorMessage = "Dosya seçilmelidir.")]
        public IFormFile? Files { get; set; }
    }
}
