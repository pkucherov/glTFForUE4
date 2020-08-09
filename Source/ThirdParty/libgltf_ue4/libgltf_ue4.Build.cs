// Copyright 2016 - 2020 Code 4 Game <develop@c4g.io>

using UnrealBuildTool;

public class libgltf_ue4 : ModuleRules
{
    public libgltf_ue4(ReadOnlyTargetRules Target) : base(Target)
    {
        Type = ModuleType.External;

        string glTFPath = System.IO.Path.Combine(ModuleDirectory, "libgltf-0.1.3");
        string IncludePath = System.IO.Path.Combine(glTFPath, "include");
        string LibPath = "";
        string LibFilePath = "";

        if ((Target.Platform == UnrealTargetPlatform.Win32) || (Target.Platform == UnrealTargetPlatform.Win64))
        {
            string PlatformName = "";
            if (Target.Platform == UnrealTargetPlatform.Win32)
            {
                PlatformName = "win32";
            }
            else if (Target.Platform == UnrealTargetPlatform.Win64)
            {
                PlatformName = "win64";
            }

            string VSName = "vs2015";

            LibPath = System.IO.Path.Combine(glTFPath, "lib", PlatformName, VSName);

            LibFilePath = System.IO.Path.Combine(LibPath, "libgltf.lib");
        }
        else if (Target.Platform == UnrealTargetPlatform.Linux)
        {
            LibPath = System.IO.Path.Combine(glTFPath, "lib", "linux");

            LibFilePath = System.IO.Path.Combine(LibPath, "libgltf.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.Mac)
        {
            LibPath = System.IO.Path.Combine(glTFPath, "lib", "macos");

            LibFilePath = System.IO.Path.Combine(LibPath, "libgltf.a");
        }
        else if (Target.Platform == UnrealTargetPlatform.IOS)
        {
            LibPath = System.IO.Path.Combine(glTFPath, "lib", "ios");

            LibFilePath = System.IO.Path.Combine(LibPath, "libgltf.a");
        }

        PublicIncludePaths.Add(IncludePath);
        PublicAdditionalLibraries.Add(LibFilePath);
        PublicDefinitions.Add("UNICODE");
    }
}
