namespace AspNetCoreTodo.Models
{
    public class TodoViewModel
    {
        public TodoItem[] Items { get; set; }

        public TodoViewModel()
        {
        
            TodoItem item = new TodoItem();
            item.Title = "TEST";

            TodoItem item2 = new TodoItem();
            item2.Title = "Hola mundo";


            this.Items = new TodoItem[]{ item, item2 };
        }
    }
}