// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "modelBuilder is not to be validated as null", Scope = "member", Target = "~M:User.Web.Api.Data.EntityConfigurations.UserEntityConfiguration.Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder{User.Web.Api.Users.User})")]
[assembly: SuppressMessage("Design", "CA1062:Validate arguments of public methods", Justification = "modelBuilder is not to be validated as null", Scope = "member", Target = "~M:User.Web.Api.Data.ApplicationDbContext.OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder)")]
