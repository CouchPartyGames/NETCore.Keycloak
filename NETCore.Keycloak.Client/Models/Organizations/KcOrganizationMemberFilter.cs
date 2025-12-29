using System.Globalization;
using System.Text;
using NETCore.Keycloak.Client.Models.Common;
using Newtonsoft.Json;

namespace NETCore.Keycloak.Client.Models.Organizations;

/// <summary>
/// Represents a filter for querying organization members.
/// </summary>
public class KcOrganizationMemberFilter : KcFilter
{
    /// <summary>
    /// Gets or sets a value indicating whether the query parameters must match exactly.
    /// </summary>
    /// <value>
    /// <c>true</c> for exact matching; <c>false</c> for partial matching; otherwise, <c>null</c>.
    /// </value>
    [JsonProperty("exact")]
    public bool? Exact { get; set; }

    /// <summary>
    /// Gets or sets the membership type to filter by.
    /// </summary>
    /// <value>
    /// A <see cref="KcMembershipType"/> to filter members by their membership type.
    /// </value>
    [JsonProperty("membershipType")]
    public KcMembershipType? MembershipType { get; set; }

    /// <summary>
    /// Builds the query string based on the filter properties.
    /// </summary>
    /// <returns>
    /// A string containing the query parameters to be appended to a URL.
    /// </returns>
    public new string BuildQuery()
    {
        var builder = new StringBuilder($"?max={Max}");

        // Include brief representation if specified
        if ( BriefRepresentation != null )
        {
            _ = builder.Append(CultureInfo.CurrentCulture,
                $"&briefRepresentation={BriefRepresentation.ToString().ToLower(CultureInfo.CurrentCulture)}");
        }

        // Include pagination offset if specified
        if ( First != null )
        {
            _ = builder.Append(CultureInfo.CurrentCulture,
                $"&first={string.Create(CultureInfo.CurrentCulture, $"{First}").ToLower(CultureInfo.CurrentCulture)}");
        }

        // Include general search query if specified
        if ( !string.IsNullOrWhiteSpace(Search) )
        {
            _ = builder.Append(CultureInfo.CurrentCulture, $"&search={Search}");
        }

        // Include exact match filter if specified
        if ( Exact != null )
        {
            _ = builder.Append(CultureInfo.CurrentCulture,
                $"&exact={Exact.ToString().ToLower(CultureInfo.CurrentCulture)}");
        }

        // Include membership type filter if specified
        if ( MembershipType != null )
        {
            _ = builder.Append(CultureInfo.CurrentCulture,
                $"&membershipType={MembershipType.ToString().ToUpper(CultureInfo.CurrentCulture)}");
        }

        return builder.ToString();
    }
}
