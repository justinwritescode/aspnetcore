// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#pragma warning disable
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Microsoft.AspNetCore.Identity;
using static Utils;

/// <summary>The base entity type for an entity's claims</summary>
public abstract class IdentityEntityClaim<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf, TEntity> : IdentityEntityEntity<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TEntity>
    where TUser : IdentityUser<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TRole : IdentityRole<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TKey : IEquatable<TKey>
    where TUserClaim : IdentityUserClaim<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUserRole : IdentityUserRole<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUserLogin : IdentityUserLogin<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TRoleClaim : IdentityRoleClaim<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUserToken : IdentityUserToken<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TSelf : IdentityEntityClaim<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf, TEntity>
{
    /// <summary>
    /// Gets or sets the identifier for this role claim.
    /// </summary>
    public virtual TKey Id
    {
        get => Id = Properties.TryGetValue(nameof(Id), out var id) ? id.Parse<TKey>() : default!;
        set => Properties[nameof(Id)] = value.ToString()!;
    }

    /// <summary>
    /// Gets or sets the of the primary key of the entity associated with this claim.
    /// </summary>
    public override TKey EntityId
    {
        get => EntityId = Properties.TryGetValue(nameof(EntityId), out var entityId) ? entityId.Parse<TKey>() : default!;
        set => Properties[nameof(EntityId)] = value.ToString()!;
    }

    /// <summary>The associated entity</summary>
    public virtual TEntity Entity { get; set; } = default!;

    /// <summary>
    /// Gets or sets the claim type for this claim.
    /// </summary>
    public virtual Uri Type { get; set; } = default!;

    /// <summary>
    /// Gets or sets the claim value for this claim.
    /// </summary>
    public virtual string? Value { get; set; }

    /// <summary>The URI of the claim's value type</summary>
    public virtual Uri ValueType { get; set; } = default!;

    /// <summary>The URI of the issuer of the claim</summary>
    public virtual Uri Issuer { get; set; } = default!;

    /// <summary>The URI of the original issuer of the claim</summary>
    public virtual Uri OriginalIssuer { get; set; } = default!;

    /// <summary>
    /// Gets a dictionary that contains additional properties associated with this claim.
    /// </summary>
    /// <remarks>
    /// The claim properties are serialized as a JSON object.
    /// </remarks>
    /// <value>A dictionary that contains additional properties associated with the claim. The properties are represented as name-value pairs.</value>
    /// <example>
    /// <code>
    /// {
    ///    "prop1": "value1",
    ///   "prop2": "value2"
    /// }
    /// </code>
    /// </example>
    /// <seealso cref="Claim.Properties"/>
    public virtual IDictionary<string, string> Properties { get; set; } = new Dictionary<string, string>();

    /// <summary>Returns a string representation of this Claim object.</summary>
    /// <returns>A string representation of this Claim object.</returns>
    /// <remarks>The string that is returned contains the values of the <see cref="System.Type" /> and <see cref="Value" /> properties in the following format:."Type: Value".</remarks>
    public override string ToString() => $"{Type}:{Value}";

    /// <summary>
    /// Initializes by copying Type and Value from the other claim.
    /// </summary>
    /// <param name="other">The claim to initialize from.</param>
    public virtual TSelf InitializeFromClaim(Claim? other)
    {
        if (other is null)
        {
            return default!;
        }
        Properties = other.Properties ?? new Dictionary<string, string>();
        Type = other.Type.ToUri(ClaimTypeUrnFormatString)!;
        Value = other.Value;
        ValueType = other.ValueType.ToUri(ClaimValueTypeUrnFormatString)!;
        Issuer = other.Issuer.ToUri(IssuerUrnFormatString)!;
        OriginalIssuer = other.OriginalIssuer.ToUri(IssuerUrnFormatString)!;
        Id = other.Properties?.TryGetValue(nameof(Id), out var id) ?? false ? id.Parse<TKey>() : default!;
        EntityId = other.Properties?.TryGetValue(nameof(EntityId), out var entityId) ?? false ? entityId.Parse<TKey>() : default!;
        return (this as TSelf)!;
    }

    /// <summary>
    /// Constructs a new claim with the type and value.
    /// </summary>
    /// <returns>The <see cref="Claim"/> that was produced.</returns>
    public virtual Claim ToClaim()
    {
        var claim = new Claim(Type.ToString(), Value!, ValueType.ToString(), Issuer?.ToString(), OriginalIssuer?.ToString());
        foreach (var p in Properties)
        {
            claim.Properties[p.Key] = p.Value;
        }
        return claim;
    }
}
