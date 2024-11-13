using FriendApp.Entities.Models;

namespace FriendApp.BLL.Interfaces;

public interface IFriendService
{
    List<Friend> GetAllFriends();
    void AddFriend(Friend friend);
    void UpdateFriend(Friend friend);
    void DeleteFriend(int friendId);
    Friend GetFriendById(int friendId);
}