﻿namespace Aquantica.Contracts.Responses.Base;

public class BaseResponse<T>
{
    public bool IsSuccess { get; set; }
    public string Error { get; set; }
    public T? Data { get; set; }
}
