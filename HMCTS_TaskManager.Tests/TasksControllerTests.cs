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