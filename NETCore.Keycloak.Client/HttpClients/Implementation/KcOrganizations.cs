using Microsoft.Extensions.Logging;
using NETCore.Keycloak.Client.HttpClients.Abstraction;
using NETCore.Keycloak.Client.Models;
using NETCore.Keycloak.Client.Models.Common;
using NETCore.Keycloak.Client.Models.Organizations;
using NETCore.Keycloak.Client.Utils;

namespace NETCore.Keycloak.Client.HttpClients.Implementation;

/// <inheritdoc cref="IKcOrganizations"/>
internal sealed class KcOrganizations(string baseUrl,
    ILogger logger) : KcHttpClientBase(logger, baseUrl), IKcOrganizations
{
    /// <inheritdoc cref="IKcOrganizations.CreateAsync"/>
    public Task<KcResponse<KcOrganization>> CreateAsync(
        string realm,
        string accessToken,
        KcOrganization organization,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization object is not null.
        ValidateNotNull(nameof(organization), organization);

        // Construct the URL for creating a new organization in the specified realm.
        var url = $"{BaseUrl}/{realm}/organizations";

        // Process the request to create the organization.
        return ProcessRequestAsync<KcOrganization>(
            url,
            HttpMethod.Post,
            accessToken,
            "Unable to create organization",
            organization,
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.ListAsync"/>
    public Task<KcResponse<IEnumerable<KcOrganization>>> ListAsync(
        string realm,
        string accessToken,
        KcOrganizationFilter filter = null,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Initialize the filter if not provided.
        filter ??= new KcOrganizationFilter();

        // Construct the URL for retrieving organizations, including query parameters if specified.
        var url = $"{BaseUrl}/{realm}/organizations{filter.BuildQuery()}";

        // Process the request to retrieve the list of organizations.
        return ProcessRequestAsync<IEnumerable<KcOrganization>>(
            url,
            HttpMethod.Get,
            accessToken,
            "Unable to list organizations",
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.CountAsync"/>
    public Task<KcResponse<KcCount>> CountAsync(
        string realm,
        string accessToken,
        KcOrganizationFilter filter = null,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Initialize the filter if not provided.
        filter ??= new KcOrganizationFilter();

        // Construct the URL for counting organizations, including query parameters if specified.
        var url = $"{BaseUrl}/{realm}/organizations/count{filter.BuildQuery()}";

        // Process the request to retrieve the count of organizations.
        return ProcessRequestAsync<KcCount>(
            url,
            HttpMethod.Get,
            accessToken,
            "Unable to count organizations",
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.GetAsync"/>
    public Task<KcResponse<KcOrganization>> GetAsync(
        string realm,
        string accessToken,
        string id,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(id), id);

        // Construct the URL for retrieving the organization details.
        var url = $"{BaseUrl}/{realm}/organizations/{id}";

        // Process the request to retrieve the organization details.
        return ProcessRequestAsync<KcOrganization>(
            url,
            HttpMethod.Get,
            accessToken,
            "Unable to get organization",
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.UpdateAsync"/>
    public Task<KcResponse<KcOrganization>> UpdateAsync(
        string realm,
        string accessToken,
        string id,
        KcOrganization organization,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(id), id);

        // Validate that the updated organization data is not null.
        ValidateNotNull(nameof(organization), organization);

        // Construct the URL for updating the organization details.
        var url = $"{BaseUrl}/{realm}/organizations/{id}";

        // Process the request to update the organization details.
        return ProcessRequestAsync<KcOrganization>(
            url,
            HttpMethod.Put,
            accessToken,
            "Unable to update organization",
            organization,
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.DeleteAsync"/>
    public Task<KcResponse<object>> DeleteAsync(
        string realm,
        string accessToken,
        string id,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(id), id);

        // Construct the URL for deleting the organization.
        var url = $"{BaseUrl}/{realm}/organizations/{id}";

        // Process the request to delete the organization.
        return ProcessRequestAsync<object>(
            url,
            HttpMethod.Delete,
            accessToken,
            "Unable to delete organization",
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.GetMembersAsync"/>
    public Task<KcResponse<IEnumerable<KcOrganizationMember>>> GetMembersAsync(
        string realm,
        string accessToken,
        string organizationId,
        KcOrganizationMemberFilter filter = null,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(organizationId), organizationId);

        // Initialize the filter if not provided.
        filter ??= new KcOrganizationMemberFilter();

        // Construct the URL for retrieving organization members.
        var url = $"{BaseUrl}/{realm}/organizations/{organizationId}/members{filter.BuildQuery()}";

        // Process the request to retrieve the list of members.
        return ProcessRequestAsync<IEnumerable<KcOrganizationMember>>(
            url,
            HttpMethod.Get,
            accessToken,
            "Unable to list organization members",
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.GetMembersCountAsync"/>
    public Task<KcResponse<KcCount>> GetMembersCountAsync(
        string realm,
        string accessToken,
        string organizationId,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(organizationId), organizationId);

        // Construct the URL for counting organization members.
        var url = $"{BaseUrl}/{realm}/organizations/{organizationId}/members/count";

        // Process the request to retrieve the count of members.
        return ProcessRequestAsync<KcCount>(
            url,
            HttpMethod.Get,
            accessToken,
            "Unable to count organization members",
            cancellationToken: cancellationToken
        );
    }

    /// <inheritdoc cref="IKcOrganizations.InviteExistingUserAsync"/>
    public async Task<KcResponse<object>> InviteExistingUserAsync(
        string realm,
        string accessToken,
        string organizationId,
        string userId,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(organizationId), organizationId);

        // Validate that the user ID is not null or empty.
        ValidateRequiredString(nameof(userId), userId);

        // Construct the URL for inviting an existing user.
        var url = $"{BaseUrl}/{realm}/organizations/{organizationId}/members/invite-existing-user";

        try
        {
            // Execute the HTTP POST request to invite the user.
            using var inviteRequest = await ExecuteRequest(async () =>
            {
                // Initialize the HTTP client for the request.
                using var client = new HttpClient();

                // Add the authorization header.
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {accessToken}");

                // Create the form content with the user ID.
                using var form = new FormUrlEncodedContent(
                    new Dictionary<string, string>
                    {
                        { "id", userId }
                    });

                // Send the POST request to the endpoint with the form content.
                return await client.PostAsync(new Uri(url), form, cancellationToken)
                    .ConfigureAwait(false);
            }, new KcHttpMonitoringFallbackModel
            {
                Url = url,
                HttpMethod = HttpMethod.Post
            }).ConfigureAwait(false);

            // Handle the response.
            return await HandleAsync<object>(inviteRequest, cancellationToken).ConfigureAwait(false);
        }
        catch ( Exception e )
        {
            // Log the error if a logger is available.
            if ( Logger != null )
            {
                KcLoggerMessages.Error(Logger, "Unable to invite existing user to organization", e);
            }

            // Return a response indicating an error occurred.
            return new KcResponse<object>
            {
                IsError = true,
                ErrorMessage = "Unable to invite existing user to organization",
                Exception = e
            };
        }
    }

    /// <inheritdoc cref="IKcOrganizations.RemoveMemberAsync"/>
    public Task<KcResponse<object>> RemoveMemberAsync(
        string realm,
        string accessToken,
        string organizationId,
        string memberId,
        CancellationToken cancellationToken = default)
    {
        // Validate the realm and access token inputs.
        ValidateAccess(realm, accessToken);

        // Validate that the organization ID is not null or empty.
        ValidateRequiredString(nameof(organizationId), organizationId);

        // Validate that the member ID is not null or empty.
        ValidateRequiredString(nameof(memberId), memberId);

        // Construct the URL for removing a member.
        var url = $"{BaseUrl}/{realm}/organizations/{organizationId}/members/{memberId}";

        // Process the request to remove the member.
        return ProcessRequestAsync<object>(
            url,
            HttpMethod.Delete,
            accessToken,
            "Unable to remove member from organization",
            cancellationToken: cancellationToken
        );
    }
}
