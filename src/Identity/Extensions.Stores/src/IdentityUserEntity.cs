#pragma warning disable
using System;
using Microsoft.AspNetCore.Identity;

namespace Microsoft.AspNetCore.Identity;

/// <summary>A base class for entities associated with users</summary>
/// <typeparam name="TKey">The type used for the primary keys.</typeparam>
/// <typeparam name="TUser">The type used for the user.</typeparam>
/// <typeparam name="TUserClaim">The type used for user claims.</typeparam>
/// <typeparam name="TUserRole">The type used for user roles.</typeparam>
public abstract class IdentityUserEntity<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TEntity> : IdentityEntityEntity<TKey, TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TEntity>
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
    /// Gets or sets the primary key for this user entity.
    /// </summary>
    public virtual TKey Id { get; set; } = default!;

    /// <summary>Gets or sets the user ID for this user entity.</summary>
    public virtual TKey UserId { get; set; } = default!;

    /// <summary>Gets or sets the user for this user entity.</summary>
    public virtual TUser User { get; set; } = default!;
}
