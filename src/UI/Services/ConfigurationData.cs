namespace Client.Services
{
    public class ConfigurationData : IConfigurationData
    {
        public string AuthorityEndpoint {get;}
        public string BlogAPIEndpoint {get;}

        public ConfigurationData(string authorityEndpoint, string blogAPIEndpoint)
        {
            this.AuthorityEndpoint = authorityEndpoint;
            this.BlogAPIEndpoint = blogAPIEndpoint;
        }
    }
}