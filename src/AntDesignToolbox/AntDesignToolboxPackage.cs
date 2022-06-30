﻿global using Community.VisualStudio.Toolkit;
global using Microsoft.VisualStudio.Shell;
global using System;
global using Task = System.Threading.Tasks.Task;
using Microsoft.VisualStudio;
using System.Runtime.InteropServices;
using System.Threading;

namespace AntDesignToolbox
{
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [InstalledProductRegistration(Vsix.Name, Vsix.Description, Vsix.Version)]
    [ProvideUIContextRule(PackageGuids.UIContextGuidString, 
        name: "Test auto load",
        expression: "DotRazor",
        termNames: new[] { "DotRazor" },
        termValues: new[] { "HierSingleSelectionName:.razor$" }
        )]
    [ProvideToolWindowVisibility(typeof(ControlToolboxWindow.Pane), VSConstants.UICONTEXT.CSharpProject_string)]
    [ProvideToolWindow(typeof(ControlToolboxWindow.Pane), Style = VsDockStyle.Tabbed, Window = WindowGuids.Toolbox)]
    [ProvideMenuResource("Menus.ctmenu", 1)]
    [Guid(PackageGuids.AntDesignToolboxString)]
    public sealed class AntDesignToolboxPackage : ToolkitPackage
    {
        
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            await this.RegisterCommandsAsync();

            this.RegisterToolWindows();
        }
    }
}