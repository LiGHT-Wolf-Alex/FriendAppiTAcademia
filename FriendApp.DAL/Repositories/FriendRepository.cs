using FriendApp.DAL.interfaces;
using FriendApp.Entities.Models;

namespace FriendApp.DAL.Repositories;

public class FriendRepository : IFriendRepository
{
    private static List<Friend> _friends =
    [
        new() { FriendID = 1, FriendName = "John Doe", Place = "New York" },
        new() { FriendID = 2, FriendName = "Jane Smith", Place = "Los Angeles" },
        new() { FriendID = 3, FriendName = "Alice Johnson", Place = "Chicago" },
        new() { FriendID = 4, FriendName = "Bob Brown", Place = "San Francisco" }
    ];

    public List<Friend> GetAll()
    {
        return _friends;
    }

    public void Add(Friend friend)
    {
        throw new NotImplementedException();
    }

    public void Update(Friend friend)
    {
        throw new NotImplementedException();
    }

    public void Delete(int friendId)
    {
        throw new NotImplementedException();
    }

    public Friend GetById(int friendId)
    {
        throw new NotImplementedException();
    }
}