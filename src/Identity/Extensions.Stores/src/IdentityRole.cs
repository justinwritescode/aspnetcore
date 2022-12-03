// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#pragma warning disable
using System;
using System.Collections.Generic;
using System.Globalization;
// using Microsoft.Extensions.Identity.Stores;

namespace Microsoft.AspNetCore.Identity;
using static Utils;

// /// <summary>
// /// The default implementation of <see cref="IdentityRole{TKey,TUser,TRoleClaim}"/> which uses a string as the primary key.
// /// </summary>
// public class IdentityRole<TSelf, TEntity, TEntityClaim, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityRole<TSelf, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TSelf : IdentityRole<TSelf, TEntity, TEntityClaim, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TUser : IdentityUser<TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TRole : IdentityRole<TRole, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TUserClaim : IdentityUserClaim<TUserClaim, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TUserRole : IdentityUserRole<TUserRole, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TUserLogin : IdentityUserLogin<TUserLogin, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TRoleClaim : IdentityRoleClaim<TRoleClaim, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
//     where TUserToken : IdentityUserToken<TUserToken, TUser, TRole, string, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
// {
//     /// <summary>
//     /// Initializes a new instance of <see cref="IdentityRole{TSelf,TUser,TRoleClaim}"/>.
//     /// </summary>
//     /// <remarks>
//     /// The Id property is initialized to form a new GUID string value.
//     /// </remarks>
//     public IdentityRole()
//     {
//         Id = Guid.NewGuid().ToString();
//     }

//     /// <summary>
//     /// Initializes a new instance of <see cref="IdentityRole{TSelf,TUser,TRoleClaim}"/>.
//     /// </summary>
//     /// <param name="roleName">The role name.</param>
//     /// <param name="roleUri">The role's URI.</param>
//     /// <remarks>
//     /// The Id property is initialized to form a new GUID string value.
//     /// </remarks>
//     public IdentityRole(string roleName, Uri? roleUri = null) : base(roleName, roleUri)
//     {
//     }
// }

/// <summary>
/// Represents a role in the identity system
/// </summary>
/// <typeparam name="TKey">The type used for the primary key for the role.</typeparam>
public class IdentityRole<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken> : IdentityEntity<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
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
    /// Initializes a new instance of <see cref="IdentityRole{TSelf, TKey, TUser, TRoleClaim}"/>.
    /// </summary>
    public IdentityRole() : this(default!, default(string)!) { }

    /// <summary>
    /// Initializes a new instance of <see cref="IdentityRole{TSelf, TKey, TUser, TRoleClaim}"/>.
    /// </summary>
    /// <param name="roleName">The role name.</param>
    /// <param name="roleUri">The role's URI.</param>
    public IdentityRole(string roleName, string? roleUri = null)
    {
        Name = roleName;
        Uri = roleUri?.TryToUri(RoleUriTemplate, out var uri) ?? false ? uri! : roleName.ToUri(RoleUriTemplate)!;
    }
    /// <summary>
    /// Initializes a new instance of <see cref="IdentityRole{TSelf, TKey, TUser, TRoleClaim}"/>.
    /// </summary>
    /// <param name="roleName">The role name.</param>
    /// <param name="roleUri">The role's URI.</param>
    public IdentityRole(string roleName, Uri? roleUri = null) : this()
    {
        Name = roleName;
        Uri = roleUri ?? roleName.ToUri(RoleUriTemplate)!;
    }

    /// <summary>
    /// Gets or sets the primary key for this role.
    /// </summary>
    public virtual TKey Id { get; set; } = default!;

    /// <summary>
    /// Gets or sets the name for this role.
    /// </summary>
    public virtual string Name { get; set; }

    ///<summary>Gets or sets the role's URI</summary>
    public virtual Uri Uri { get; set; }

    /// <summary>
    /// Gets or sets the normalized name for this role.
    /// </summary>
    public virtual string NormalizedName { get => Name.ToUpper(CultureInfo.CurrentCulture); set { } }

    /// <summary>
    /// A random value that should change whenever a role is persisted to the store
    /// </summary>
    public virtual string? ConcurrencyStamp { get; set; }

    /// <summary>
    /// Returns the name of the role.
    /// </summary>
    /// <returns>The name of the role.</returns>
    public override string ToString()
    {
        return Name ?? string.Empty;
    }

    /// <summary>The users who are members of this role</summary>
    public virtual ICollection<TUser> Users { get; } = new List<TUser>();

    /// <summary>The claims which this role has</summary>
    public virtual ICollection<TRoleClaim> Claims { get; } = new List<TRoleClaim>();
}
