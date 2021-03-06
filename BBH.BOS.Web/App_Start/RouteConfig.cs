﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BBH.BOS.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("MemberIndex", "member", new { controller = "Member", action = "Index" });
            routes.MapRoute("RegisterMember", "registermember", new { controller = "Register", action = "Index" });
            routes.MapRoute("LoginMember", "login", new { controller = "Login", action = "Index" });
            routes.MapRoute("Package", "package", new { controller = "Package", action = "Index" });
            routes.MapRoute("PackageCoin", "packagecoin", new { controller = "Package_Coin", action = "Index" });
            routes.MapRoute("Coin", "coin", new { controller = "Coin", action = "Index" });

            routes.MapRoute("EditAccount", "editaccount", new { controller = "Member", action = "UpdatePrototypeMember" });

            routes.MapRoute("ChangePassword", "changepassword", new { controller = "Login", action = "ChangePassword" });
            routes.MapRoute("Admin", "admin", new { controller = "Admin", action = "Index" });
            routes.MapRoute("Home", "Home", new { controller = "Home", action = "Index" });
            routes.MapRoute("BTC Wallet", "btcwallet", new { controller = "Wallet", action = "WalletBTC" });
            routes.MapRoute("EU Wallet", "euwallet", new { controller = "Wallet", action = "WalletEU" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
