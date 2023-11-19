using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using RubiconTask.Base.Controllers;
using RubiconTask.Models;
using RubiconTask.Services.Interfaces;
using RubiconTask.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RubiconTask.Controllers
{
  [Route("api/rectangles")]
  [ApiController]
  public class RectangleController : BaseController
  {
    private readonly IRectangleService _rectangleService;
    public RectangleController(IMapper mapper, ILogger<BaseController> logger, IRectangleService rectangleService) : base(mapper, logger)
    {
      _rectangleService = rectangleService;
    }

    [HttpGet("{id}")]
    public async Task<Rectangle> Get(int id)
    {
      var result = _mapper.Map<Rectangle>(await _rectangleService.Get(id));
      return result;
    }

    [HttpGet("search")]
    public async Task<IEnumerable<Rectangle>> Get(int? x1, int? y1, int? x2, int? y2, bool isStrick = true)
    {
      var result = _mapper.Map<IEnumerable<Rectangle>>(await _rectangleService.Search(x1, y1, x2, y2, isStrick));
      return result;
    }

    [HttpGet()]
    public async Task<IEnumerable<Rectangle>> GetList()
    {
      var result = _mapper.Map<IEnumerable<Rectangle>>(await _rectangleService.GetList());
      return result;
    }

    [HttpGet("{offset}:{limit}")]
    public async Task<IEnumerable<PaginationViewModel<Rectangle>>> GetPagedList(int offset, int limit)
    {
      var paginatedRectangles = await _rectangleService.GetPaginatedList(offset: offset, limit: limit, r => !r.IsDeleted);

      var data = _mapper.Map<IEnumerable<PaginationViewModel<Rectangle>>>(paginatedRectangles);
      return data;
    }
  }
}
