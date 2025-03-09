
using Entities;
using Infratructure;
using UseCases;


namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public void CreateTodoItems_And_Set_Completed_Test()
        {
            var mockRepository = new InMemoryToDoItemRepository();
            var todoListManager = new ToDoListManager(mockRepository);

            var todoList = new ToDoItem() { Id = 1, Text = "Test Item", IsCompleted = false };

            todoListManager.AddTodoItem(todoList);
            todoListManager.MarkComplete(1);

            Assert.True(todoListManager.getTodoItems().First().IsCompleted);
            Assert.Equal("Test Item" ,todoListManager.getTodoItems().First().Text);

        }
    }
}
