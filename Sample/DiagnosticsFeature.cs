using NServiceBus;
using NServiceBus.Features;
using NServiceBus.UniformSession;
using System.Threading.Tasks;

#region DiagnosticsFeature

public class DiagnosticsFeature :
    Feature
{
    internal DiagnosticsFeature()
    {
        EnableByDefault();

        DependsOn("UniformSessionFeature");
    }

    protected override void Setup(FeatureConfigurationContext context)
    {
        context.Container.ConfigureComponent<CustomLogger>(DependencyLifecycle.InstancePerUnitOfWork);
        context.Container.ConfigureComponent<DiagnosticsFeatureStartup>(DependencyLifecycle.InstancePerUnitOfWork);
        context.RegisterStartupTask(b => b.Build<DiagnosticsFeatureStartup>());
    }
}

public class DiagnosticsFeatureStartup : FeatureStartupTask
{
    public DiagnosticsFeatureStartup(IUniformSession session)
    {

    }

    protected override Task OnStart(IMessageSession session)
    {
        return Task.CompletedTask;
    }

    protected override Task OnStop(IMessageSession session)
    {
        return Task.CompletedTask;
    }
}

#endregion