using Pulumi;
using Pulumi.Kubernetes.Types.Inputs.Core.V1;
using Pulumi.Kubernetes.Types.Inputs.Meta.V1;
using Pulumi.Kubernetes.Core.V1;
using Pulumi.Kubernetes.Helm.V3;
using Pulumi.Kubernetes.Types.Inputs.Helm.V3;

return await Deployment.RunAsync(() =>
{
    var argocdNamespace = new Namespace("argocd-namespace", new NamespaceArgs
    {
        Metadata = new ObjectMetaArgs
        {
            Name = "argocd",
        }
    });

    var ecodashDevNamespace = new Namespace("ecodash-dev-namespace", new NamespaceArgs
    {
        Metadata = new ObjectMetaArgs
        {
            Name = "ecodash-dev",
        }
    });

    var ecodashProdNamespace = new Namespace("ecodash-prod-namespace", new NamespaceArgs
    {
        Metadata = new ObjectMetaArgs
        {
            Name = "ecodash-prod"
        }
    });

    var argoCd = new Release("argocd", new ReleaseArgs
    {
        Chart = "argo-cd",
        Version = "7.7.5",
        RepositoryOpts = new RepositoryOptsArgs
        {
            Repo = "https://argoproj.github.io/argo-heml"
        },
        Namespace = "argocd",
    }, new CustomResourceOptions()
    {
        DependsOn = { argocdNamespace }
    });
});