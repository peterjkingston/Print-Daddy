using Autofac;
using PrintDaddyObjectLibrary;

namespace PrintDaddyService
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            ContainerBuilder builder = new ContainerBuilder();

            //Register types here, in order of program flow;
            builder.RegisterType<Application>().As<IApplication>();
            builder.RegisterType<PrintDaddy>().As<IPrintDaddy>();
            builder.RegisterType<ResourceManager>().As<IResourceManager>();

            //CredentialProvider
            builder.RegisterType<CryptoCredentialProvider>().As<ICredentialsProvider>();
            
            //DataKeys and DataProviders
            builder.RegisterType<DataKey>().As<IDataKey>();
            builder.RegisterType<LocalXmlProvider>().As<ILocalDataProvider>();
            builder.RegisterType<RemoteAPIProvider>().As<IRemoteDataProvider>();

            //Validator
            builder.RegisterType<DataKeyValidator>().As<IValidator>();

            //Selector
            builder.RegisterType<DataKeySelector>().As<ISelector>();

            //RecordReader
            builder.RegisterType<RemoteAPIRecordReader>().As<IRecordReader>();

            //RecordAction -> PrintManager
            builder.RegisterType<PrintAction>().As<IRecordAction>();
            builder.RegisterType<DefaultPrintManager>().As<IPrintManager>();

            return builder.Build();
        }
    }
}
