using FriendApp.DAL.Interfaces;
using FriendApp.DAL.Repositories;
using FriendApp.Entities.Models;

namespace FriendApp.Tests;

public class FriendRepositoryTests
{
    private readonly IFriendRepository _repository = new FriendRepository();

    [Fact]
    public void GetById_NonExistingId_ShouldReturnNull()
    {
        var nonExistingId = 999;

        var result = _repository.GetById(nonExistingId);

        Assert.Null(result);
    }

    [Fact]
    public void Update_ExistingFriend_ShouldModifyFriend()
    {
        var friend = _repository.GetAll().First();
        var updatedName = "Иван Иванович";
        var updatedPlace = "Казань";
        friend.FriendName = updatedName;
        friend.Place = updatedPlace;

        _repository.Update(friend);
        var updatedFriend = _repository.GetById(friend.FriendID);

        Assert.Equal(updatedName, updatedFriend.FriendName);
        Assert.Equal(updatedPlace, updatedFriend.Place);
    }

    [Fact]
    public void Delete_ExistingId_ShouldDecreaseCount()
    {
        var initialCount = _repository.GetAll().Count;
        var friendToDelete = _repository.GetAll().First();

        _repository.Delete(friendToDelete.FriendID);
        var finalCount = _repository.GetAll().Count;

        Assert.Equal(initialCount - 1, finalCount);
        Assert.Null(_repository.GetById(friendToDelete.FriendID));
    }

    [Fact]
    public void Delete_NonExistingId_ShouldNotChangeCount()
    {
        var initialCount = _repository.GetAll().Count;
        var nonExistingId = 999;

        _repository.Delete(nonExistingId);
        var finalCount = _repository.GetAll().Count;

        Assert.Equal(initialCount, finalCount);
    }

    [Fact]
    public void RenumberFriendIDs_AfterDeletion_ShouldHaveSequentialIDs()
    {
        if (_repository.GetAll().Count < 2)
        {
            _repository.Add(new Friend { FriendName = "Тест", Place = "Тест" });
        }

        var initialFriends = _repository.GetAll().OrderBy(f => f.FriendID).ToList();
        var friendToDelete = initialFriends[0];
        _repository.Delete(friendToDelete.FriendID);

        var remainingFriends = _repository.GetAll().OrderBy(f => f.FriendID).ToList();

        for (int i = 0; i < remainingFriends.Count; i++)
        {
            Assert.Equal(i + 1, remainingFriends[i].FriendID);
        }
    }
}