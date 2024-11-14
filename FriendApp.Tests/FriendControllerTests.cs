using FriendApp.BLL.Interfaces;
using FriendApp.Entities.Models;
using FriendApp.UI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FriendApp.Tests
{
    public class FriendControllerTests
    {
        private readonly Mock<IFriendService> _mockService;
        private readonly FriendController _controller;

        public FriendControllerTests()
        {
            _mockService = new Mock<IFriendService>();
            _controller = new FriendController(_mockService.Object);
        }

        [Fact]
        public void Delete_ExistingId_ReturnsViewResult_WithFriend()
        {
            var friend = new Friend { FriendID = 1, FriendName = "Иван", Place = "Москва" };
            _mockService.Setup(service => service.GetFriendById(1)).Returns(friend);

            var result = _controller.Delete(1);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Friend>(viewResult.ViewData.Model);
            Assert.Equal("Иван", model.FriendName);
        }

        [Fact]
        public void Delete_NonExistingId_ReturnsNotFound()
        {
            _mockService.Setup(service => service.GetFriendById(999)).Returns((Friend)null);

            var result = _controller.Delete(999);

            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public void Create_PostInvalidModel_ReturnsViewWithModel()
        {
            var newFriend = new Friend { FriendName = "", Place = "Новосибирск" };
            _controller.ModelState.AddModelError("FriendName", "Required");

            var result = _controller.Create(newFriend);

            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<Friend>(viewResult.ViewData.Model);
            Assert.Equal(newFriend, model);
            _mockService.Verify(service => service.AddFriend(It.IsAny<Friend>()), Times.Never);
        }
    }
}