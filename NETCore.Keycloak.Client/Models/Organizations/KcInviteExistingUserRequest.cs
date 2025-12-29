using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents a request to invite an existing user to an organization.
/// </summary>
public class KcInviteExistingUserRequest
{
    /// <summary>
    /// Gets or sets the user ID of the existing user to invite.
    /// </summary>
    /// <value>
    /// A string representing the unique identifier of the user.
    /// </value>
    [JsonProperty("id")]
    public string Id { get; set; }
}
