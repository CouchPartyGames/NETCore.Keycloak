using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents a request to invite a user to an organization by email.
/// </summary>
public class KcInviteUserByEmailRequest
{
    /// <summary>
    /// Gets or sets the email address of the user to invite.
    /// </summary>
    /// <value>
    /// A string representing the email address.
    /// If the user with this email exists, an invitation link is sent.
    /// Otherwise, a registration link is sent.
    /// </value>
    [JsonProperty("email")]
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the first name of the user (optional).
    /// </summary>
    /// <value>
    /// A string representing the user's first name, or <c>null</c> if not provided.
    /// </value>
    [JsonProperty("firstName")]
    public string FirstName { get; set; }

    /// <summary>
    /// Gets or sets the last name of the user (optional).
    /// </summary>
    /// <value>
    /// A string representing the user's last name, or <c>null</c> if not provided.
    /// </value>
    [JsonProperty("lastName")]
    public string LastName { get; set; }
}
