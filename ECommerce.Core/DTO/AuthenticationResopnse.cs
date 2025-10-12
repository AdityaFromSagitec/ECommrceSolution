namespace ECommerce.Core.DTO;
public record AuthenticationResopnse (
    Guid UserID, 
    string? Email, 
    string? PersonName,
    string? Gender, 
    string? Token, 
    bool Success)
{
    public AuthenticationResopnse() : this(default, default, default, default, default, default) 
    { }
}

