using System;
using System.ComponentModel.DataAnnotations;

namespace Tasklist.Web.ViewModels
{
    public class TaskViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Título é obrigatório.")]
        [Display(Name = "Título")]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [Display(Name = "Descrição")]
        [MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Concluído")]
        public bool Completed { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}