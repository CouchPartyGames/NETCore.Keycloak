using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents the membership type of an organization member in Keycloak.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum KcMembershipType
{
    /// <summary>
    /// Indicates that the member is managed by the organization and cannot exist without it.
    /// </summary>
    [EnumMember(Value = "MANAGED")]
    Managed,

    /// <summary>
    /// Indicates that the member is unmanaged and can exist independently of the organization.
    /// </summary>
    [EnumMember(Value = "UNMANAGED")]
    Unmanaged
}
