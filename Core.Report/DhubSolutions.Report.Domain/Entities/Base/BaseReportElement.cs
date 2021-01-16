using System;
using DhubSolutions.Common.Domain.Entities.Admin;
using DhubSolutions.Core.Domain.Entity;
using Newtonsoft.Json.Linq;

namespace DhubSolutions.Reports.Domain.Entities.Base
{
    public abstract class BaseReportElement : BaseEntity, IBaseReportElement
    {
        protected BaseReportElement() : base()
        { }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CreatedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User CreatedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastModifiedById { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public User LastModifiedBy { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Config { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public JObject ConfigJObject
        {
            get
            {
                if (string.IsNullOrEmpty(Config) || string.IsNullOrWhiteSpace(Config))
                {
                    return null;
                }

                try
                {
                    return JObject.Parse(Config);
                }
                catch (Exception)
                {
                    Console.WriteLine(@"Json Parse Fail on Prop Config, From component with Id =" + Id);
                    return null;
                }
            }
        }

    }
}
