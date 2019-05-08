namespace Cookbook.Api.Features.Security.Dto
{
    public class PermissionDto
    {
        public int PermissionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PermissionGroupId { get; set; }
    }
}
