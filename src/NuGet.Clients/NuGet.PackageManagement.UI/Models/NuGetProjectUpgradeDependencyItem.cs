// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using NuGet.Packaging.Core;
using System.Globalization;
using System.Linq;
using NuGet.Common;

namespace NuGet.PackageManagement.UI
{
    public class NuGetProjectUpgradeDependencyItem
    {
        public PackageIdentity Package { get; }
        public IList<PackageIdentity> DependingPackages { get; }

        public IList<PackLogMessage> Issues { get; }

        public string Id { get; }

        public string Version { get; }

        public bool PromoteToTopLevel { get; set; }

        public NuGetProjectUpgradeDependencyItem(PackageIdentity package, IList<PackageIdentity> dependingPackages = null)
        {
            Package = package;
            Id = package.Id;
            Version = package.Version.ToNormalizedString();
            DependingPackages = dependingPackages ?? new List<PackageIdentity>();
            Issues = new List<PackLogMessage>();
            PromoteToTopLevel = false;
        }

        public override string ToString()
        {
            return !DependingPackages.Any()
                ? Package.ToString()
                : $"{Package} {string.Format(CultureInfo.CurrentCulture, Resources.NuGetUpgrade_PackageDependencyOf, string.Join(", ", DependingPackages))}";
        }
    }
}