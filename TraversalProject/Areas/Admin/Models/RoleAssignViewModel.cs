namespace TraversalProject.Areas.Admin.Models
{
    public class RoleAssignViewModel
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool RoleExist { get; set; } // bu rol kullanıcıda var mı 
    }
}
