﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVCTest
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AGISEntities : DbContext
    {
        public AGISEntities()
            : base("name=AGISEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AGENCY> AGENCies { get; set; }
        public virtual DbSet<AGENCYSETTING> AGENCYSETTINGs { get; set; }
        public virtual DbSet<AGENCYWIDGET> AGENCYWIDGETs { get; set; }
        public virtual DbSet<CONFIGURATION> CONFIGURATIONs { get; set; }
        public virtual DbSet<CONFIGURATIONCOMMAND> CONFIGURATIONCOMMANDs { get; set; }
        public virtual DbSet<CONFIGURATIONDYNAMICTHEME> CONFIGURATIONDYNAMICTHEMEs { get; set; }
        public virtual DbSet<CONFIGURATIONLAYER> CONFIGURATIONLAYERs { get; set; }
        public virtual DbSet<CONFIGURATIONLAYERFIELD> CONFIGURATIONLAYERFIELDs { get; set; }
        public virtual DbSet<CONFIGURATIONWIDGET> CONFIGURATIONWIDGETs { get; set; }
        public virtual DbSet<DYNAMICTHEMEPARAMETER> DYNAMICTHEMEPARAMETERs { get; set; }
        public virtual DbSet<EMAILSETTING> EMAILSETTINGs { get; set; }
        public virtual DbSet<GLOBALSETTING> GLOBALSETTINGs { get; set; }
        public virtual DbSet<LOG> LOGS { get; set; }
        public virtual DbSet<MAPPROFILE> MAPPROFILEs { get; set; }
        public virtual DbSet<MAPPROFILESERVICE> MAPPROFILESERVICEs { get; set; }
        public virtual DbSet<UPGRADE_SCRIPTS> UPGRADE_SCRIPTS { get; set; }
        public virtual DbSet<USERGROUP> USERGROUPs { get; set; }
        public virtual DbSet<USERGROUPCOMMAND> USERGROUPCOMMANDs { get; set; }
        public virtual DbSet<USERGROUPDETAIL> USERGROUPDETAILs { get; set; }
        public virtual DbSet<USERGROUPLAYERSETTING> USERGROUPLAYERSETTINGs { get; set; }
        public virtual DbSet<USERGROUPWIDGET> USERGROUPWIDGETs { get; set; }
        public virtual DbSet<USERPROFILE> USERPROFILEs { get; set; }
        public virtual DbSet<WIDGET> WIDGETs { get; set; }
    }
}
