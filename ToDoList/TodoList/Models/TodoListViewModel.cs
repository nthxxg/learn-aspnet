﻿using Entities;

namespace TodoList.Models
{
    public class TodoListViewModel
    {
     public required IEnumerable<Item> Items { get; set; }
    }
}
