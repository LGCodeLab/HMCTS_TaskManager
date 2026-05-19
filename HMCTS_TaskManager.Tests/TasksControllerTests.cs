using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HMCTS_TaskManager.Controllers;
using HMCTS_TaskManager.Data;
using HMCTS_TaskManager.Models;


namespace HMCTS_TaskManager.Tests
{
    public class TasksControllerTests
    {
        private TaskManagerDbContext GetDbContext()
        {
            DbContextOptions<TaskManagerDbContext> options =
                new DbContextOptionsBuilder<TaskManagerDbContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString())
                    .Options;

            return new TaskManagerDbContext(options);
        }

        [Fact]
        public void Create_Get_Returns_View()
        {
            // Arrange.
            TaskManagerDbContext dbContext = GetDbContext();
            TasksController tasksController = new TasksController(dbContext);

            // Act.
            IActionResult result = tasksController.Create();

            // Assert.
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public async Task Create_Post_SavesTaskToDatabase()
        {
            // Arrange.
            TaskManagerDbContext dbContext = GetDbContext();
            TasksController tasksController = new TasksController(dbContext);

            TaskItem newTask = new TaskItem
            {
                Title = "New Task",
                Status = "ToDo",
                DueDate = DateTime.Today,
            };

            // Act.
            await tasksController.Create(newTask);

            List<TaskItem> tasksInDb = dbContext.Tasks.ToList();

            // Assert.
            Assert.Single(tasksInDb);
            Assert.Equal("New Task", tasksInDb.First().Title);
        }

        [Fact]
        public async Task Create_Post_ValidTask_RedirectsToIndex()
        {
            // Arrange.
            TaskManagerDbContext dbContext = GetDbContext();
            TasksController tasksController = new TasksController(dbContext);

            TaskItem newTask = new TaskItem
            {
                Title = "New Task",
                Status = "ToDo",
                DueDate = DateTime.Today,
            };

            // Act.
            IActionResult result = await tasksController.Create(newTask);

            // Assert.
            RedirectToActionResult redirect = Assert.IsType<RedirectToActionResult>(result);
            Assert.Equal("Index", redirect.ActionName);
        }

        [Fact]
        public async Task Index_Returns_View()
        {
            // Arrange.
            TaskManagerDbContext dbContext = GetDbContext();
            TasksController tasksController = new TasksController(dbContext);

            // Act.
            IActionResult result = await tasksController.Index();

            // Assert.
            Assert.IsType<ViewResult>(result);
        }
    }
}