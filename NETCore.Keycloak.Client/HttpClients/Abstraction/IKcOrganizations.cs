using NETCore.Keycloak.Client.Exceptions;
using NETCore.Keycloak.Client.Models;
using NETCore.Keycloak.Client.Models.Common;
using NETCore.Keycloak.Client.Models.Organizations;

namespace NETCore.Keycloak.Client.HttpClients.Abstraction;

/// <summary>
/// Keycloak organizations REST client
/// <see href="https://www.keycloak.org/docs-api/latest/rest-api/index.html#_organizations"/>
/// </summary>
public interface IKcOrganizations
{
    /// <summary>
    /// Creates a new organization in a specified Keycloak realm.
    ///
    /// POST /{realm}/organizations
    /// </summary>
    /// <param name="realm">The Keycloak realm where the organization will be created.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organization">The <see cref="KcOrganization"/> object containing the details of the organization to create.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing the created <see cref="KcOrganization"/> object,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, or organization object is null or invalid.
    /// </exception>
    Task<KcResponse<KcOrganization>> CreateAsync(string realm, string accessToken, KcOrganization organization,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a list of organizations from a specified Keycloak realm, optionally filtered by query parameters.
    ///
    /// GET /{realm}/organizations
    /// </summary>
    /// <param name="realm">The Keycloak realm from which to retrieve the organizations.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="filter">
    /// An optional <see cref="KcOrganizationFilter"/> object containing query parameters for filtering the results.
    /// If not provided, all organizations will be retrieved.
    /// </param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an enumerable of <see cref="KcOrganization"/> objects
    /// representing the organizations in the realm, or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm or access token is null or invalid.
    /// </exception>
    Task<KcResponse<IEnumerable<KcOrganization>>> ListAsync(string realm, string accessToken,
        KcOrganizationFilter filter = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the count of organizations in a specified Keycloak realm, optionally filtered by query parameters.
    ///
    /// GET /{realm}/organizations/count
    /// </summary>
    /// <param name="realm">The Keycloak realm for which to retrieve the organization count.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="filter">
    /// An optional <see cref="KcOrganizationFilter"/> object containing query parameters to filter the organization count.
    /// If not provided, all organizations will be included in the count.
    /// </param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing the count of organizations as a <see cref="KcCount"/> object,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm or access token is null or invalid.
    /// </exception>
    Task<KcResponse<KcCount>> CountAsync(string realm, string accessToken, KcOrganizationFilter filter = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves details of a specific organization in a specified Keycloak realm.
    ///
    /// GET /{realm}/organizations/{organization-id}
    /// </summary>
    /// <param name="realm">The Keycloak realm to query.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="id">The unique identifier of the organization to retrieve.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing a <see cref="KcOrganization"/> object representing the organization details,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, or organization ID is null or invalid.
    /// </exception>
    Task<KcResponse<KcOrganization>> GetAsync(string realm, string accessToken, string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates the details of a specific organization in a specified Keycloak realm.
    ///
    /// PUT /{realm}/organizations/{organization-id}
    /// </summary>
    /// <param name="realm">The Keycloak realm where the organization resides.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="id">The unique identifier of the organization to update.</param>
    /// <param name="organization">
    /// A <see cref="KcOrganization"/> object containing the updated details of the organization.
    /// </param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing a <see cref="KcOrganization"/> object representing the updated organization details,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, organization ID, or updated organization data is null or invalid.
    /// </exception>
    Task<KcResponse<KcOrganization>> UpdateAsync(string realm, string accessToken, string id,
        KcOrganization organization, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes a specific organization from a specified Keycloak realm.
    ///
    /// DELETE /{realm}/organizations/{organization-id}
    /// </summary>
    /// <param name="realm">The Keycloak realm from which the organization will be deleted.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="id">The unique identifier of the organization to be deleted.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an object indicating the result of the delete operation,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, or organization ID is null or invalid.
    /// </exception>
    Task<KcResponse<object>> DeleteAsync(string realm, string accessToken, string id,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all members of a specific organization in a Keycloak realm.
    ///
    /// GET /{realm}/organizations/{org-id}/members
    /// </summary>
    /// <param name="realm">The Keycloak realm to query.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization.</param>
    /// <param name="filter">
    /// An optional <see cref="KcOrganizationMemberFilter"/> object containing query parameters for filtering the results.
    /// If not provided, all members will be retrieved.
    /// </param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an enumerable of <see cref="KcOrganizationMember"/> objects
    /// representing the members of the organization, or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, or organization ID is null or invalid.
    /// </exception>
    Task<KcResponse<IEnumerable<KcOrganizationMember>>> GetMembersAsync(string realm, string accessToken,
        string organizationId, KcOrganizationMemberFilter filter = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves the count of members in a specific organization.
    ///
    /// GET /{realm}/organizations/{org-id}/members/count
    /// </summary>
    /// <param name="realm">The Keycloak realm to query.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing the count of members as a <see cref="KcCount"/> object,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, or organization ID is null or invalid.
    /// </exception>
    Task<KcResponse<KcCount>> GetMembersCountAsync(string realm, string accessToken, string organizationId,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds an existing user as a member of an organization.
    ///
    /// POST /{realm}/organizations/{org-id}/members
    /// </summary>
    /// <param name="realm">The Keycloak realm where the organization resides.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization.</param>
    /// <param name="userId">The unique identifier of the user to add to the organization.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an object indicating the result of the add member operation,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, organization ID, or user ID is null or invalid.
    /// </exception>
    /// <remarks>
    /// If the user is not found, or if it is already associated with the organization, an error response is returned.
    /// Returns HTTP 201 on success, 400 for bad request, or 409 for conflict.
    /// </remarks>
    Task<KcResponse<object>> AddMemberAsync(string realm, string accessToken, string organizationId,
        string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invites a user by email to join an organization.
    /// If the user with the given email address exists, sends an invitation link.
    /// Otherwise, sends a registration link.
    ///
    /// POST /{realm}/organizations/{org-id}/members/invite-user
    /// </summary>
    /// <param name="realm">The Keycloak realm where the organization resides.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization.</param>
    /// <param name="request">The <see cref="KcInviteUserByEmailRequest"/> containing email and optional user details.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an object indicating the result of the invite operation,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, organization ID, or request is null or invalid.
    /// </exception>
    /// <remarks>
    /// Returns HTTP 204 No Content on success, 400 for bad request, 409 for conflict, or 500 for internal server error.
    /// </remarks>
    Task<KcResponse<object>> InviteUserByEmailAsync(string realm, string accessToken, string organizationId,
        KcInviteUserByEmailRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Invites an existing user to join an organization.
    ///
    /// POST /{realm}/organizations/{org-id}/members/invite-existing-user
    /// </summary>
    /// <param name="realm">The Keycloak realm where the organization resides.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization.</param>
    /// <param name="userId">The unique identifier of the user to invite.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an object indicating the result of the invite operation,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, organization ID, or user ID is null or invalid.
    /// </exception>
    Task<KcResponse<object>> InviteExistingUserAsync(string realm, string accessToken, string organizationId,
        string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes a member from an organization.
    ///
    /// DELETE /{realm}/organizations/{org-id}/members/{member-id}
    /// </summary>
    /// <param name="realm">The Keycloak realm where the organization resides.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization.</param>
    /// <param name="memberId">The unique identifier of the member to remove.</param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an object indicating the result of the remove operation,
    /// or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, organization ID, or member ID is null or invalid.
    /// </exception>
    Task<KcResponse<object>> RemoveMemberAsync(string realm, string accessToken, string organizationId,
        string memberId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the organizations associated with the user that has the specified id.
    ///
    /// GET /{realm}/organizations/{org-id}/members/{member-id}/organizations
    /// </summary>
    /// <param name="realm">The Keycloak realm to query.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="organizationId">The unique identifier of the organization context.</param>
    /// <param name="memberId">The unique identifier of the member whose organizations to retrieve.</param>
    /// <param name="filter">
    /// An optional <see cref="KcOrganizationFilter"/> object containing query parameters for filtering the results.
    /// If not provided, brief representation will be used by default (briefRepresentation=true).
    /// </param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an enumerable of <see cref="KcOrganization"/> objects
    /// representing the organizations associated with the member, or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, organization ID, or member ID is null or invalid.
    /// </exception>
    /// <remarks>
    /// Returns HTTP 200 with organization list on success, or 400 for bad request.
    /// Set filter.BriefRepresentation to false to return full representation instead of basic fields.
    /// </remarks>
    Task<KcResponse<IEnumerable<KcOrganization>>> GetMemberOrganizationsAsync(string realm, string accessToken,
        string organizationId, string memberId, KcOrganizationFilter filter = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns all organizations associated with the user that has the specified id.
    ///
    /// GET /{realm}/organizations/members/{member-id}/organizations
    /// </summary>
    /// <param name="realm">The Keycloak realm to query.</param>
    /// <param name="accessToken">The access token used for authentication.</param>
    /// <param name="memberId">The unique identifier of the user/member whose organizations to retrieve.</param>
    /// <param name="briefRepresentation">
    /// If false, return the full representation. Otherwise, only the basic fields are returned.
    /// Defaults to true.
    /// </param>
    /// <param name="cancellationToken">
    /// Optional cancellation token to cancel the asynchronous operation.
    /// </param>
    /// <returns>
    /// A <see cref="KcResponse{T}"/> containing an enumerable of <see cref="KcOrganization"/> objects
    /// representing all organizations associated with the user, or an error response if the operation fails.
    /// </returns>
    /// <exception cref="KcException">
    /// Thrown if the realm, access token, or member ID is null or invalid.
    /// </exception>
    /// <remarks>
    /// Returns HTTP 200 with organization list on success, or 400 for bad request.
    /// </remarks>
    Task<KcResponse<IEnumerable<KcOrganization>>> GetUserOrganizationsAsync(string realm, string accessToken,
        string memberId, bool briefRepresentation = true, CancellationToken cancellationToken = default);
}
