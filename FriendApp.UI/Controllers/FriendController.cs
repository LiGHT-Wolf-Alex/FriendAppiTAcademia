using FriendApp.BLL.Interfaces;
using FriendApp.Entities.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendApp.UI.Controllers;

public class FriendController(IFriendService friendService) : Controller
{
    public IActionResult Index(string searchString) => View(friendService.GetAllFriends());
    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Friend friend)
    {
        if (ModelState.IsValid)
        {
            friendService.AddFriend(friend);
            return RedirectToAction(nameof(Index));
        }

        return View(friend);
    }

    public IActionResult Edit(int id)
    {
        var friendById = friendService.GetFriendById(id);
        if (friendById is not null)
        {
            return View(friendById);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Friend? friend)
    {
        if (friend is null || friend.FriendID <= 0)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            friendService.UpdateFriend(friend);
            return RedirectToAction(nameof(Index));
        }

        return View(friend);
    }

    public IActionResult Delete(int id)
    {
        var friendById = friendService.GetFriendById(id);
        if (friendById is not null)
        {
            return View(friendById);
        }

        return NotFound();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmDelete(int id)
    {
        friendService.DeleteFriend(id);
        return RedirectToAction(nameof(System.Index));
    }
}