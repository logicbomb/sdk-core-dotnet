using System.Configuration;

namespace PayPal.Manager
{
    /// <summary>
    /// Custom handler for SDK configuration section as defined in App.Config or Web.Config files
    /// </summary>    
    public class SDKConfigHandler : ConfigurationSection
    {
        public SDKConfigHandler() { }

        private static readonly ConfigurationProperty accountsElement =
             new ConfigurationProperty("accounts", typeof(AccountCollection), null, ConfigurationPropertyOptions.IsRequired);

        /// <summary>
        /// Accounts Collection
        /// </summary>
        [ConfigurationProperty("accounts", IsRequired = true)]
        public AccountCollection Accounts
        {
            get { return (AccountCollection)this[accountsElement]; }
        }

        [ConfigurationProperty("settings", IsRequired = true)]
        internal NameValueConfigurationCollection Settings
        {
            get { return (NameValueConfigurationCollection)this["settings"]; }
        }

        public string Setting(string name)
        {
            NameValueConfigurationElement config = Settings[name];
            return ((config == null) ? null : config.Value);
        }
    }    

    [ConfigurationCollection(typeof(Account), AddItemName = "account",
         CollectionType = ConfigurationElementCollectionType.BasicMap)]
    public class AccountCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new Account();
        }
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((Account)element).APIUsername;
        }

        public Account Account(int index)
        {
            return (Account)BaseGet(index);
        }

        public Account Account(string value)
        {
            return (Account)BaseGet(value);
        }

        public new  Account this[string name]
        {
            get { return (Account)BaseGet(name); }
        }

        public Account this[int index]
        {
            get { return (Account)BaseGet(index); }
        }
    }

    /// <summary>
    /// Class holds the <Account> element
    /// </summary>
    public class Account : ConfigurationElement
    {
        private static readonly ConfigurationProperty apiUsername =
            new ConfigurationProperty("apiUsername", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty apiPassword =
            new ConfigurationProperty("apiPassword", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty applicationId =
            new ConfigurationProperty("applicationId", typeof(string), string.Empty, ConfigurationPropertyOptions.IsRequired);

        private static readonly ConfigurationProperty apiSignature =
            new ConfigurationProperty("apiSignature", typeof(string), string.Empty);

        private static readonly ConfigurationProperty apiCertificate =
            new ConfigurationProperty("apiCertificate", typeof(string), string.Empty);

        private static readonly ConfigurationProperty privateKeyPassword =
            new ConfigurationProperty("privateKeyPassword", typeof(string), string.Empty);

        private static readonly ConfigurationProperty signSubject =
           new ConfigurationProperty("signatureSubject", typeof(string), string.Empty);

        private static readonly ConfigurationProperty certifySubject =
           new ConfigurationProperty("certificateSubject", typeof(string), string.Empty);

        public Account()
        {
            base.Properties.Add(apiUsername);
            base.Properties.Add(apiPassword);
            base.Properties.Add(applicationId);
            base.Properties.Add(apiSignature);
            base.Properties.Add(apiCertificate);
            base.Properties.Add(privateKeyPassword);
            base.Properties.Add(signSubject);
            base.Properties.Add(certifySubject);
        }

        /// <summary>
        /// API Username
        /// </summary>
        [ConfigurationProperty("apiUsername", IsRequired = true)]
        public string APIUsername
        {
            get { return (string)this[apiUsername]; }
            set { this[apiUsername] = value; }
        }

        /// <summary>
        /// API password
        /// </summary>
        [ConfigurationProperty("apiPassword", IsRequired = true)]
        public string APIPassword
        {
            get { return (string)this[apiPassword]; }
            set { this[apiPassword] = value; }
        }

        /// <summary>
        /// Application ID
        /// </summary>
        [ConfigurationProperty("applicationId")]
        public string ApplicationId
        {
            get { return (string)this[applicationId]; }
            set { this[applicationId] = value; }
        }

        /// <summary>
        /// API signature
        /// </summary>
        [ConfigurationProperty("apiSignature")]
        public string APISignature
        {
            get { return (string)this[apiSignature]; }
            set { this[apiSignature] = value; }
        }

        /// <summary>
        /// Client certificate for SSL authentication
        /// </summary>
        [ConfigurationProperty("apiCertificate")]
        public string APICertificate
        {
            get { return (string)this[apiCertificate]; }
            set { this[apiCertificate] = value; }
        }

        /// <summary>
        /// Private key password for SSL authentication
        /// </summary>
        [ConfigurationProperty("privateKeyPassword")]
        public string PrivateKeyPassword
        {
            get { return (string)this[privateKeyPassword]; }
            set { this[privateKeyPassword] = value; }
        }
      
        /// <summary>
        /// Signature Subject
        /// </summary>
        [ConfigurationProperty("signatureSubject")]
        public string SignatureSubject
        {
            get { return (string)this[signSubject]; }
            set { this[signSubject] = value; }
        }

        /// <summary>
        /// Certificate Subject
        /// </summary>
        [ConfigurationProperty("certificateSubject")]
        public string CertificateSubject
        {
            get { return (string)this[certifySubject]; }
            set { this[certifySubject] = value; }
        } 
    }   
}
