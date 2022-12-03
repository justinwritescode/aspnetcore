// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#pragma warning disable
using System;

namespace Microsoft.AspNetCore.Identity;

/// <summary>
/// Represents an authentication token for a user.
/// </summary>
/// <typeparam name="TKey">The type of the primary key used for users.</typeparam>
public class IdentityUserToken<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityEntity<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUser : IdentityUser<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TRole : IdentityRole<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TKey : IEquatable<TKey>
    where TUserClaim : IdentityUserClaim<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUserRole : IdentityUserRole<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUserLogin : IdentityUserLogin<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TRoleClaim : IdentityRoleClaim<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
    where TUserToken : IdentityUserToken<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
{
    /// <summary>
    /// Gets or sets the primary key of the user that the token belongs to.
    /// </summary>
    public virtual TKey UserId { get; set; } = default!;

    /// <summary>
    /// Gets or sets the LoginProvider this token is from.
    /// </summary>
    public virtual string LoginProvider { get; set; } = default!;

    /// <summary>
    /// Gets or sets the name of the token.
    /// </summary>
    public virtual string Name { get; set; } = default!;

    /// <summary>
    /// Gets or sets the token value.
    /// </summary>
    [ProtectedPersonalData]
    public virtual string? Value { get; set; }
}
