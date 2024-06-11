﻿
using Domain.Primitives;

namespace Application.DTO.User;

public class OrderUpdateRequest
{
    public Guid Id { get; set; }
    public DateTime OrderDate { get; set; }
    public Status Status { get; set; }
}