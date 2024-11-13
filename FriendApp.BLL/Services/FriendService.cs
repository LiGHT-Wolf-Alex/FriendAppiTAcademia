using FriendApp.BLL.Interfaces;
using FriendApp.Entities.Models;

namespace FriendApp.BLL.Services;

public class FriendService(IFriendService friendService) : IFriendService
{
    private readonly IFriendService _friendService = friendService;

    public List<Friend> GetAllFriends()
    {
        throw new NotImplementedException();
    }

    public void AddFriend(Friend friend)
    {
        throw new NotImplementedException();
    }

    public void UpdateFriend(Friend friend)
    {
        throw new NotImplementedException();
    }

    public void DeleteFriend(int friendId)
    {
        throw new NotImplementedException();
    }

    public Friend GetFriendById(int friendId)
    {
        throw new NotImplementedException();
    }
}