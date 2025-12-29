using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents an organization in Keycloak.
/// <see href="https://www.keycloak.org/docs-api/latest/rest-api/index.html#_organizations"/>
/// </summary>
public class KcOrganization
{
    /// <summary>
    /// Gets or sets the unique identifier of the organization.
    /// </summary>
    /// <value>
    /// A string representing the organization ID.
    /// </value>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the organization.
    /// </summary>
    /// <value>
    /// A string representing the organization name. Must be unique within a realm.
    /// </value>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the alias of the organization.
    /// </summary>
    /// <value>
    /// A string representing the organization alias. If not set, defaults to the name value.
    /// Once set, the alias is immutable.
    /// </value>
    [JsonProperty("alias")]
    public string Alias { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the organization is enabled.
    /// </summary>
    /// <value>
    /// <c>true</c> if the organization is enabled; otherwise, <c>false</c>.
    /// </value>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets the description of the organization.
    /// </summary>
    /// <value>
    /// A string containing a free-text description of the organization.
    /// </value>
    [JsonProperty("description")]
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the custom attributes associated with the organization.
    /// </summary>
    /// <value>
    /// A dictionary containing key-value pairs of organization attributes.
    /// Each key maps to a list of string values.
    /// </value>
    [JsonProperty("attributes")]
    public IDictionary<string, IEnumerable<string>> Attributes { get; set; }

    /// <summary>
    /// Gets or sets the domains that belong to this organization.
    /// </summary>
    /// <value>
    /// A collection of <see cref="KcOrganizationDomain"/> representing the organization's domains.
    /// A domain cannot be shared by different organizations within a realm.
    /// </value>
    [JsonProperty("domains")]
    public IEnumerable<KcOrganizationDomain> Domains { get; set; }
}
