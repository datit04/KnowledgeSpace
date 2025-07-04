﻿using System.Security.Claims;

namespace KnowledgeSpace.BackendServer.Extensions
{
	public static class IdentityExtensions
	{
		public static string GetUserId(this ClaimsPrincipal claimsPrincipal)
		{
			var claim = ((ClaimsIdentity)claimsPrincipal.Identity)
				.Claims
				.SingleOrDefault(x => x.Type == ClaimTypes.NameIdentifier);
			return claim.Value;
		}
	}
}