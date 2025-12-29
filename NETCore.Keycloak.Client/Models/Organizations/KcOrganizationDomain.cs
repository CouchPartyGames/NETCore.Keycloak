using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents a domain that belongs to an organization in Keycloak.
/// <see href="https://www.keycloak.org/docs-api/latest/rest-api/index.html#_organizations"/>
/// </summary>
public class KcOrganizationDomain
{
    /// <summary>
    /// Gets or sets the domain name.
    /// </summary>
    /// <value>
    /// A string representing the domain name (e.g., "example.org").
    /// </value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the domain has been verified.
    /// </summary>
    /// <value>
    /// <c>true</c> if the domain is verified; otherwise, <c>false</c>.
    /// </value>
    [JsonProperty("verified")]
    public bool Verified { get; set; }
}
