using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(ScreenshotSaver.BuildInfo.Name)]
[assembly: AssemblyDescription(ScreenshotSaver.BuildInfo.Description)]
[assembly: AssemblyCompany(ScreenshotSaver.BuildInfo.Company)]
[assembly: AssemblyProduct(ScreenshotSaver.BuildInfo.Name)]
[assembly: AssemblyCopyright("Copyright © " + ScreenshotSaver.BuildInfo.Author + " 2022")]
[assembly: AssemblyTrademark(ScreenshotSaver.BuildInfo.Company)]
[assembly: AssemblyVersion(ScreenshotSaver.BuildInfo.Version)]
[assembly: AssemblyFileVersion(ScreenshotSaver.BuildInfo.Version)]
[assembly: MelonInfo(typeof(ScreenshotSaver.Main), ScreenshotSaver.BuildInfo.Name, ScreenshotSaver.BuildInfo.Version, ScreenshotSaver.BuildInfo.Author, ScreenshotSaver.BuildInfo.DownloadLink)]
[assembly: MelonColor(System.ConsoleColor.DarkCyan)]
[assembly: MelonGame("Kinetic Games", "Phasmophobia")]
