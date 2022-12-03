// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;

/// <summary>Utility methods and constants.</summary>
public static class Utils
{
    /// <summary>The default URN format for a claim type</summary>
    /// <value>urn:microsoft:aspnetcore:identity:claims:claimType:{0}</value>
    public const string ClaimTypeUrnFormatString = "urn:microsoft:aspnetcore:identity:claims:claimType:{0}";
    /// <summary>The default URN format for a claim value type</summary>
    /// <value></value>
    public const string ClaimValueTypeUrnFormatString = "urn:microsoft:aspnetcore:identity:claims:claimValueType:{0}";
    /// <summary>The default URN format for a role</summary>
    /// <value>urn:microsoft:aspnetcore:identity:claims:claimValueType:{0}</value>
    public const string RoleUriTemplate = "urn:microsoft:aspnetcore:identity:roles:{0}";
    /// <summary>The default URN format for a claim issuer</summary>
    /// <value>urn:microsoft:aspnetcore:identity:issuer:{0}</value>
    public const string IssuerUrnFormatString = "urn:microsoft:aspnetcore:identity:issuer:{0}";

    /// <summary>URI for a null URI</summary>
    /// <value>urn:null</value>
    public const string NullUri = "urn:null";

    /// <summary>Parses a value to the type <typeparamref name="T" />.</summary>
    public static T Parse<T>(this string value)
        => Convert.ChangeType(value, typeof(T),System.Globalization.CultureInfo.CurrentCulture.GetFormat(typeof(T)) as IFormatProvider) is T result ? result : default!;

    /// <summary>Changes <paramref name="value" /> to the type into a URI.  Falls back to using the based on the pattern defined in <paramref name="defaultFormatString"/>.  If the value is null, it returns a URI equal to <see cref="NullUri" /></summary>
    public static Uri ToUri(this string? value, string defaultFormatString = "about:blank")
        => Uri.TryCreate(value, UriKind.Absolute, out var result) ? result :
            value is null ? new Uri(NullUri) : new Uri(string.Format(System.Globalization.CultureInfo.InvariantCulture.GetFormat(typeof(string)) as IFormatProvider, defaultFormatString, value));

    /// <summary>Attempts to change <paramref name="value" /> to the type into a URI. Doesn't fall back</summary>
    public static bool TryToUri(this string? value, string? defaultFormatString, out Uri? result)
    {
        if (value is null)
        {
            result = null;
            return false;
        }
        if (Uri.TryCreate(value, UriKind.Absolute, out result))
        {
            return true;
        }
        else
        {
            result = null;
            return false;
        }
    }
}
