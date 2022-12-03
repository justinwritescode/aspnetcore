// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#pragma warning disable
using System;
using System.Threading;

namespace Microsoft.AspNetCore.Identity;

/// <summary>A login provider</summary>
public class IdentityLoginProvider<TKey> where TKey : IEquatable<TKey>
{
    /// <summary>Gets or sets the primary key for this login provider.</summary>
    public TKey Id { get; set; } = default!;

    /// <summary>Gets or sets the name of the login provider.</summary>
    public string? Name { get; set; } = default!;
    /// <summary>Gets or sets the display name of the login provider.</summary>
    public string? DisplayName { get; set; } = default!;
}

/// <summary>A login provider with a long-typed key</summary>
public class IdentityLoginProvider : IdentityLoginProvider<long>
{

}
