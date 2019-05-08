namespace Cookbook.Api.Data.Entities
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PermissionGroupId { get; set; }
    }
}
