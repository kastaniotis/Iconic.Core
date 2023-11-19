using System.Data.SqlTypes;

namespace Iconic.Result;

public record Result<T>(bool Success, string? Message, T Data);