using FriendApp.Entities.Models;

namespace FriendApp.DAL.Interfaces;

public interface IFriendRepository
{
    List<Friend> GetAll();
    void Add(Friend friend);
    void Update(Friend? friend);
    void Delete(int friendId);
    Friend? GetById(int friendId);    
}