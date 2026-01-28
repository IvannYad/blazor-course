namespace ServerManagement.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        private bool _isCompleted;
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            
            set
            {
                _isCompleted = value;
                DateCompleted = _isCompleted ? DateTime.UtcNow : null;
            }
        }
        public DateTime? DateCompleted { get; set; }
    }
}
