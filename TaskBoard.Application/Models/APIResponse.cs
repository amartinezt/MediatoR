using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskBoard.Application.Models
{
    public class APIResponse
    {
            public object? Result { get; init; }
            public bool IsSuccess { get; init; } = true;
            public string Message { get; init; } = string.Empty;
       
    }
}
