using System.ComponentModel.DataAnnotations;

namespace Sample.Models
{
    public class RegisteModel
    {
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password")]
        [DataType(DataType.Password)]
        public string RetypePassword { get; set; }   
    }
}
