namespace LibraryManagementSystem.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            CreateAt = DateTime.Now; ;
            IsDeleted = false;
        }

        public int Id { get; set; }
        public DateTime CreateAt { get; private set; }
        public bool IsDeleted { get; private set; }
    }
}
