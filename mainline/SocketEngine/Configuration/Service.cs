using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Text;
using SuperSocket.Common;
using SuperSocket.SocketBase.Config;

namespace SuperSocket.SocketEngine.Configuration
{
    public class Service : ConfigurationElementBase, IServiceConfig
    {
        #region IServiceConfig Members
        [ConfigurationProperty("type", IsRequired = true)]
        public string Type
        {
            get { return this["type"] as string; }
        }

        [ConfigurationProperty("disabled", DefaultValue = "false")]
        public bool Disabled
        {
            get { return (bool)this["disabled"]; }
        }
        
        public NameValueCollection Options { get; private set; }
        #endregion
        
        protected override bool OnDeserializeUnrecognizedAttribute (string name, string value)
        {
            if(Options == null)
            {
                Options = new NameValueCollection();
            }
            
            Options.Add(name, value);
            return true;
        }
    }
}
