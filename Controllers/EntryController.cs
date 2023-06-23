using System;
using Microsoft.AspNetCore.Mvc;
using ITUMIK_dotnet_api.Services;
using ITUMIK_dotnet_api.Models;

namespace ITUMIK_dotnet_api.Controllers;

[Controller]
//[Route("api/[controller]")]
[Route("api/")]
public class EntryController : Controller
{

    private readonly MongoDBService _mongoDBService;

    public EntryController(MongoDBService mongoDBService)
    {
        _mongoDBService = mongoDBService;
    }

    [HttpGet]
    [Route("topiclist/")]
    public async Task<List<string>> GetTopics()
    {
        return await _mongoDBService.GetTopicsAsync();
    }

    [HttpGet]
    [Route("alldatalist/")]
    public async Task<List<Entry>> GetAll()
    {
        return await _mongoDBService.GetAsync();
    }

    [HttpGet]
    [Route("{floor}/")]
    public async Task<List<EntryWithoutID>> GetByFloor(string floor)
    {
        return await _mongoDBService.GetDesksByFloor(floor);
    }

    [HttpGet]
    [Route("{floor}/{desk}")]
    public async Task<List<EntryWithoutID>> GetByDesk(string floor, string desk)
    {
        return await _mongoDBService.GetChairsByDesk(floor, desk);
    }
}