﻿using ModernStore.Shared.Commands;
using System;

namespace ModernStore.Domain.Commands.Outputs
{
    public class GetProductListCommandResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
    }
}
