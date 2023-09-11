using Apps.CaptionHub.Models.Entities;

namespace Apps.CaptionHub.Models.Response.User;

public record ListUsersResponse(UserEntity[] Users);