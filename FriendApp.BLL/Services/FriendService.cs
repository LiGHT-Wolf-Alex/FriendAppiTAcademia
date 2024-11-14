using FriendApp.BLL.Interfaces;
using FriendApp.DAL.Interfaces;
using FriendApp.DAL.Repositories;
using FriendApp.Entities.Models;

namespace FriendApp.BLL.Services;

public class FriendService(IFriendRepository friendRepository) : IFriendService
{
    public List<Friend> GetAllFriends() => friendRepository.GetAll();

    public void AddFriend(Friend friend) => friendRepository.Add(friend);

    public void UpdateFriend(Friend? friend) => friendRepository.Update(friend);

    public void DeleteFriend(int friendId) => friendRepository.Delete(friendId);

    public Friend? GetFriendById(int friendId) => friendRepository.GetById(friendId);
}