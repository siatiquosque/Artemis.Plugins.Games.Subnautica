using System.Collections.Generic;
using Artemis.Core;
using Artemis.Core.Modules;
using Artemis.Core.Services;
using Artemis.Plugins.Games.Subnautica.DataModels;

namespace Artemis.Plugins.Games.Subnautica.Module;

[PluginFeature(AlwaysEnabled = true, Name = "Subnautica")]
public class SubnauticaModule : Module<SubnauticaDataModel>
{
    private readonly IWebServerService _webServerService;

    private DataModelJsonPluginEndPoint<SubnauticaDataModel> _updateEndpoint;
    public override List<IModuleActivationRequirement> ActivationRequirements { get; } = new();

    public SubnauticaModule(IWebServerService webServerService)
    {
        _webServerService = webServerService;
    }

    public override void ModuleActivated(bool isOverride)
    {

    }

    public override void ModuleDeactivated(bool isOverride)
    {

    }

    public override void Enable()
    {
        _updateEndpoint = _webServerService.AddDataModelJsonEndPoint(this, "update");

        AddDefaultProfile(DefaultCategoryName.Games, Plugin.ResolveRelativePath("Subnautica.json"));

    }

    public override void Disable()
    {
        _webServerService.RemovePluginEndPoint(_updateEndpoint);
    }

    public override void Update(double deltaTime)
    {

    }
}