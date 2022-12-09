## .NET Nuget Package Install

PM> Install-Package InputMask

In App_Start, BundleConfig.cs


  bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
          "~/Scripts/jquery.inputmask/inputmask.js",
          "~/Scripts/jquery.inputmask/jquery.inputmask.js",
                      "~/Scripts/jquery.inputmask/inputmask.extensions.js",
                      "~/Scripts/jquery.inputmask/inputmask.date.extensions.js",
                      "~/Scripts/jquery.inputmask/inputmask.numeric.extensions.js"));


In Layout

@Scripts.Render("~/bundles/inputmask")
