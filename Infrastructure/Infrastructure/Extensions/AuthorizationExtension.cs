﻿using Infrastructure.Identity;

namespace Infrastructure.Extensions
{
    public static class AuthorizationExtension
    {
        public static void AddAuthorization(this IServiceCollection services, IConfiguration configuration)
        {
            var authority = configuration["Authorization:Authority"];
            var siteAudience = configuration["Authorization:SiteAudience"];

            services.AddSingleton<IAuthorizationHandler, ScopeHandler>();
            services.AddAuthentication()
                .AddJwtBearer(AuthScheme.Internal, options =>
                {
                    options.Authority = authority;
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateAudience = false
                    };
                })
                .AddJwtBearer(AuthScheme.Site, options =>
                {
                    options.Authority = authority;
                    options.Audience = siteAudience;
                    options.RequireHttpsMetadata = false;
                });
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicy.AllowEndUserPolicy, policy =>
                {
                    policy.AuthenticationSchemes.Add(AuthScheme.Site);
                    policy.RequireClaim(JwtRegisteredClaimNames.Sub);
                });
                options.AddPolicy(AuthPolicy.AllowClientPolicy, policy =>
                {
                    policy.AuthenticationSchemes.Add(AuthScheme.Internal);
                    policy.Requirements.Add(new DenyAnonymousAuthorizationRequirement());
                    policy.Requirements.Add(new ScopeRequirement());
                });
            });

            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        }
    }
}
