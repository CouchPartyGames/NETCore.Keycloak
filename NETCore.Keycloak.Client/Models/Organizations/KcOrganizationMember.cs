using NETCore.Keycloak.Client.Models.Users;
using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents an organization member in Keycloak.
/// Extends user representation with organization-specific membership information.
/// <see href="https://www.keycloak.org/docs-api/latest/javadocs/org/keycloak/representations/idm/MemberRepresentation.html"/>
/// </summary>
public class KcOrganizationMember : KcUser
{
    /// <summary>
    /// Gets or sets the membership type of this member in the organization.
    /// </summary>
    /// <value>
    /// A <see cref="KcMembershipType"/> indicating whether the member is managed or unmanaged.
    /// </value>
    [JsonProperty("membershipType")]
    public KcMembershipType? MembershipType { get; set; }
}
