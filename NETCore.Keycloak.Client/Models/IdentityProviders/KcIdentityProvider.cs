using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.IdentityProviders;

/// <summary>
/// Represents an identity provider in Keycloak.
/// <see href="https://www.keycloak.org/docs-api/latest/rest-api/index.html#_identityproviderrepresentation"/>
/// </summary>
public class KcIdentityProvider
{
    /// <summary>
    /// Gets or sets the alias of the identity provider.
    /// </summary>
    /// <value>
    /// A string representing the unique alias of the identity provider.
    /// </value>
    [JsonProperty("alias")]
    public string Alias { get; set; }

    /// <summary>
    /// Gets or sets the display name of the identity provider.
    /// </summary>
    /// <value>
    /// A string representing the human-readable name of the identity provider.
    /// </value>
    [JsonProperty("displayName")]
    public string DisplayName { get; set; }

    /// <summary>
    /// Gets or sets the internal identifier of the identity provider.
    /// </summary>
    /// <value>
    /// A string representing the internal ID of the identity provider.
    /// </value>
    [JsonProperty("internalId")]
    public string InternalId { get; set; }

    /// <summary>
    /// Gets or sets the provider ID indicating the type of identity provider.
    /// </summary>
    /// <value>
    /// A string representing the provider type (e.g., "oidc", "saml", "google", "facebook").
    /// </value>
    [JsonProperty("providerId")]
    public string ProviderId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the identity provider is enabled.
    /// </summary>
    /// <value>
    /// <c>true</c> if the identity provider is enabled; otherwise, <c>false</c>.
    /// </value>
    [JsonProperty("enabled")]
    public bool Enabled { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the identity provider's email is trusted.
    /// </summary>
    /// <value>
    /// <c>true</c> if the email from this provider is trusted; otherwise, <c>false</c>.
    /// If true, email provided by this provider is not verified even if verification is enabled for the realm.
    /// </value>
    [JsonProperty("trustEmail")]
    public bool TrustEmail { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether tokens from this provider should be stored.
    /// </summary>
    /// <value>
    /// <c>true</c> if tokens should be stored; otherwise, <c>false</c>.
    /// </value>
    [JsonProperty("storeToken")]
    public bool StoreToken { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to add a read token role on create.
    /// </summary>
    /// <value>
    /// <c>true</c> if the read token role should be added on create; otherwise, <c>false</c>.
    /// </value>
    [JsonProperty("addReadTokenRoleOnCreate")]
    public bool AddReadTokenRoleOnCreate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to authenticate by default.
    /// </summary>
    /// <value>
    /// <c>true</c> if this provider should be tried for authentication by default; otherwise, <c>false</c>.
    /// </value>
    [JsonProperty("authenticateByDefault")]
    public bool AuthenticateByDefault { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this provider is for linking only.
    /// </summary>
    /// <value>
    /// <c>true</c> if the provider is for linking existing accounts only; otherwise, <c>false</c>.
    /// If true, users cannot log in through this provider, only link it to existing accounts.
    /// </value>
    [JsonProperty("linkOnly")]
    public bool LinkOnly { get; set; }

    /// <summary>
    /// Gets or sets the alias of the authentication flow to trigger as the first login flow.
    /// </summary>
    /// <value>
    /// A string representing the first broker login flow alias.
    /// </value>
    [JsonProperty("firstBrokerLoginFlowAlias")]
    public string FirstBrokerLoginFlowAlias { get; set; }

    /// <summary>
    /// Gets or sets the alias of the authentication flow to trigger after the user logs in through the broker.
    /// </summary>
    /// <value>
    /// A string representing the post broker login flow alias.
    /// </value>
    [JsonProperty("postBrokerLoginFlowAlias")]
    public string PostBrokerLoginFlowAlias { get; set; }

    /// <summary>
    /// Gets or sets the configuration properties for the identity provider.
    /// </summary>
    /// <value>
    /// A dictionary containing key-value pairs of identity provider configuration.
    /// The configuration varies depending on the provider type.
    /// </value>
    [JsonProperty("config")]
    public IDictionary<string, string> Config { get; set; }

    /// <summary>
    /// Gets or sets the organization ID if this identity provider is associated with an organization.
    /// </summary>
    /// <value>
    /// A string representing the organization ID, or null if not associated with an organization.
    /// </value>
    [JsonProperty("organizationId")]
    public string OrganizationId { get; set; }
}
