using FriendApp.DAL.Interfaces;
using FriendApp.Entities.Models;

namespace FriendApp.DAL.Repositories;

public class FriendRepository : IFriendRepository
{
    private static readonly List<Friend> Friends =
    [
        new() { FriendID = 1, FriendName = "John Doe", Place = "New York" },
        new() { FriendID = 2, FriendName = "Jane Smith", Place = "Los Angeles" },
        new() { FriendID = 3, FriendName = "Alice Johnson", Place = "Chicago" },
        new() { FriendID = 4, FriendName = "Bob Brown", Place = "San Francisco" }
    ];

    public List<Friend> GetAll() => Friends.OrderBy(f => f.FriendID).ToList();

    public Friend? GetById(int friendId) => Friends.FirstOrDefault(f => f.FriendID == friendId);

    public void Add(Friend friend)
    {
        friend.FriendID = Friends.Count != 0 ? Friends.Max(f => f.FriendID) + 1 : 1;
        Friends.Add(friend);
    }

    public void Update(Friend? friend)
    {
        var existingFriend = GetById(friend.FriendID);
        if (existingFriend is not null)
        {
            existingFriend.FriendName = friend.FriendName;
            existingFriend.Place = friend.Place;
        }
    }

    public void Delete(int friendId)
    {
        var friend = GetById(friendId);
        if (friend is not null)
        {
            Friends.Remove(friend);
            RenumberFriendIDs();
        }
    }

    private void RenumberFriendIDs()
    {
        var newId = 1;
        foreach (var friend in Friends.OrderBy(f => f.FriendID))
        {
            friend.FriendID = newId++;
        }
    }
}