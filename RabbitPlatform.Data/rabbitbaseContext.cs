using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using RabbitPlatform.Core;
namespace RabbitPlatform.Data
{
    public partial class rabbitbaseContext : DbContext
    {
        private string confingHelper;

        public rabbitbaseContext()
        {
        }

        public rabbitbaseContext(DbContextOptions<rabbitbaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SysArea> SysArea { get; set; }
        public virtual DbSet<SysDbbackup> SysDbbackup { get; set; }
        public virtual DbSet<SysFilterip> SysFilterip { get; set; }
        public virtual DbSet<SysItems> SysItems { get; set; }
        public virtual DbSet<SysItemsdetail> SysItemsdetail { get; set; }
        public virtual DbSet<SysLog> SysLog { get; set; }
        public virtual DbSet<SysModule> SysModule { get; set; }
        public virtual DbSet<SysModuleapp> SysModuleapp { get; set; }
        public virtual DbSet<SysModulebutton> SysModulebutton { get; set; }
        public virtual DbSet<SysModulecolumn> SysModulecolumn { get; set; }
        public virtual DbSet<SysModuleform> SysModuleform { get; set; }
        public virtual DbSet<SysModuleforminstance> SysModuleforminstance { get; set; }
        public virtual DbSet<SysOrganize> SysOrganize { get; set; }
        public virtual DbSet<SysRole> SysRole { get; set; }
        public virtual DbSet<SysRoleauthorize> SysRoleauthorize { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<SysUserlogon> SysUserlogon { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql(ConfigHelper.Configuration["appseting:MysqlConnect"].ToString());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SysArea>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_area");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_AREA")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSimpleSpelling)
                    .HasColumnName("F_SimpleSpelling")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<SysDbbackup>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_dbbackup");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_DBBACKUP")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FBackupTime).HasColumnName("F_BackupTime");

                entity.Property(e => e.FBackupType)
                    .HasColumnName("F_BackupType")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDbName)
                    .HasColumnName("F_DbName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("text");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFileName)
                    .HasColumnName("F_FileName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FFilePath)
                    .HasColumnName("F_FilePath")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FFileSize)
                    .HasColumnName("F_FileSize")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<SysFilterip>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_filterip");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_FILTERIP")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FEndIp)
                    .HasColumnName("F_EndIP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FStartIp)
                    .HasColumnName("F_StartIP")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FType)
                    .HasColumnName("F_Type")
                    .HasColumnType("bit(1)");
            });

            modelBuilder.Entity<SysItems>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_items");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_ITEMS")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIsTree)
                    .HasColumnName("F_IsTree")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<SysItemsdetail>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_itemsdetail");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_ITEMDETAIL")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FIsDefault)
                    .HasColumnName("F_IsDefault")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FItemCode)
                    .HasColumnName("F_ItemCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FItemId)
                    .HasColumnName("F_ItemId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FItemName)
                    .HasColumnName("F_ItemName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSimpleSpelling)
                    .HasColumnName("F_SimpleSpelling")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<SysLog>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_log");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_LOG")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAccount)
                    .HasColumnName("F_Account")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDate).HasColumnName("F_Date");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FIpaddress)
                    .HasColumnName("F_IPAddress")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIpaddressName)
                    .HasColumnName("F_IPAddressName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FModuleId)
                    .HasColumnName("F_ModuleId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FModuleName)
                    .HasColumnName("F_ModuleName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FNickName)
                    .HasColumnName("F_NickName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FResult)
                    .HasColumnName("F_Result")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FType)
                    .HasColumnName("F_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysModule>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_module");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_MODULE")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAllowDelete)
                    .HasColumnName("F_AllowDelete")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FAllowEdit)
                    .HasColumnName("F_AllowEdit")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIcon)
                    .HasColumnName("F_Icon")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIsExpand)
                    .HasColumnName("F_IsExpand")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FIsMenu)
                    .HasColumnName("F_IsMenu")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FIsPublic)
                    .HasColumnName("F_IsPublic")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FTarget)
                    .HasColumnName("F_Target")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FUrlAddress)
                    .HasColumnName("F_UrlAddress")
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<SysModuleapp>(entity =>
            {
                entity.ToTable("sys_moduleapp");

                entity.Property(e => e.Id).HasColumnType("varchar(50)");

                entity.Property(e => e.AppCode).HasColumnType("varchar(50)");

                entity.Property(e => e.AppName).HasColumnType("varchar(50)");

                entity.Property(e => e.CreatorTime).HasColumnType("datetime");

                entity.Property(e => e.CreatorUserId).HasColumnType("varchar(50)");

                entity.Property(e => e.DeleteMark).HasColumnType("int(11)");

                entity.Property(e => e.DeleteTime).HasColumnType("datetime");

                entity.Property(e => e.DeleteUserId).HasColumnType("varchar(500)");

                entity.Property(e => e.Description).HasColumnType("varchar(500)");

                entity.Property(e => e.EnabledMark).HasColumnType("int(11)");

                entity.Property(e => e.LastModifyTime).HasColumnType("datetime");

                entity.Property(e => e.LastModifyUserId).HasColumnType("varchar(50)");

                entity.Property(e => e.SortCode).HasColumnType("int(11)");
            });

            modelBuilder.Entity<SysModulebutton>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_modulebutton");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_MODULEBUTTON")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAllowDelete)
                    .HasColumnName("F_AllowDelete")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FAllowEdit)
                    .HasColumnName("F_AllowEdit")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIcon)
                    .HasColumnName("F_Icon")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIsPublic)
                    .HasColumnName("F_IsPublic")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FJsEvent)
                    .HasColumnName("F_JsEvent")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FLocation)
                    .HasColumnName("F_Location")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FModuleId)
                    .HasColumnName("F_ModuleId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FSplit)
                    .HasColumnName("F_Split")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FUrlAddress)
                    .HasColumnName("F_UrlAddress")
                    .HasColumnType("varchar(500)");
            });

            modelBuilder.Entity<SysModulecolumn>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_modulecolumn");

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAllowDelete)
                    .HasColumnName("F_AllowDelete")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FAllowEdit)
                    .HasColumnName("F_AllowEdit")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FColumnAlign)
                    .HasColumnName("F_ColumnAlign")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FColumnWidth)
                    .HasColumnName("F_ColumnWidth")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FCreatorTime)
                    .HasColumnName("F_CreatorTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FDeleteTime)
                    .HasColumnName("F_DeleteTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FExpandJson)
                    .HasColumnName("F_ExpandJson")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.FFormatter)
                    .HasColumnName("F_Formatter")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIsExport)
                    .HasColumnName("F_IsExport")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FIsHide)
                    .HasColumnName("F_IsHide")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FIsPrint)
                    .HasColumnName("F_IsPrint")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FLastModifyTime)
                    .HasColumnName("F_LastModifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FModuleId)
                    .HasColumnName("F_ModuleId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.F)
                    .WithOne(p => p.SysModulecolumn)
                    .HasForeignKey<SysModulecolumn>(d => d.FId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relationship_5");
            });

            modelBuilder.Entity<SysModuleform>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_moduleform");

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime)
                    .HasColumnName("F_CreatorTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FDeleteTime)
                    .HasColumnName("F_DeleteTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("smallint(6)");

                entity.Property(e => e.FFormJson)
                    .HasColumnName("F_FormJson")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime)
                    .HasColumnName("F_LastModifyTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FModuleId)
                    .HasColumnName("F_ModuleId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.F)
                    .WithOne(p => p.SysModuleform)
                    .HasForeignKey<SysModuleform>(d => d.FId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relationship_7");
            });

            modelBuilder.Entity<SysModuleforminstance>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_moduleforminstance");

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime)
                    .HasColumnName("F_CreatorTime")
                    .HasColumnType("datetime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FFormId)
                    .IsRequired()
                    .HasColumnName("F_FormId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FInstanceJson)
                    .HasColumnName("F_InstanceJson")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.FObjectId)
                    .HasColumnName("F_ObjectId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.F)
                    .WithOne(p => p.SysModuleforminstance)
                    .HasForeignKey<SysModuleforminstance>(d => d.FId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Relationship_10");
            });

            modelBuilder.Entity<SysOrganize>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_organize");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_ORGANIZE")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAddress)
                    .HasColumnName("F_Address")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FAllowDelete)
                    .HasColumnName("F_AllowDelete")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FAllowEdit)
                    .HasColumnName("F_AllowEdit")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FAreaId)
                    .HasColumnName("F_AreaId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCategoryId)
                    .HasColumnName("F_CategoryId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEmail)
                    .HasColumnName("F_Email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFax)
                    .HasColumnName("F_Fax")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLayers)
                    .HasColumnName("F_Layers")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FManagerId)
                    .HasColumnName("F_ManagerId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FMobilePhone)
                    .HasColumnName("F_MobilePhone")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.FParentId)
                    .HasColumnName("F_ParentId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FShortName)
                    .HasColumnName("F_ShortName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FTelePhone)
                    .HasColumnName("F_TelePhone")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.FWeChat)
                    .HasColumnName("F_WeChat")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysRole>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_role");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_ROLE")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAllowDelete)
                    .HasColumnName("F_AllowDelete")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FAllowEdit)
                    .HasColumnName("F_AllowEdit")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FCategory)
                    .HasColumnName("F_Category")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEnCode)
                    .HasColumnName("F_EnCode")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFullName)
                    .HasColumnName("F_FullName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FOrganizeId)
                    .HasColumnName("F_OrganizeId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FType)
                    .HasColumnName("F_Type")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysRoleauthorize>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_roleauthorize");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_ROLEAUTHORIZE")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FItemId)
                    .HasColumnName("F_ItemId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FItemType)
                    .HasColumnName("F_ItemType")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FObjectId)
                    .HasColumnName("F_ObjectId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FObjectType)
                    .HasColumnName("F_ObjectType")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<SysUser>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_user");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_USER")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAccount)
                    .HasColumnName("F_Account")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FBirthday).HasColumnName("F_Birthday");

                entity.Property(e => e.FCreatorTime).HasColumnName("F_CreatorTime");

                entity.Property(e => e.FCreatorUserId)
                    .HasColumnName("F_CreatorUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FDeleteMark)
                    .HasColumnName("F_DeleteMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FDeleteTime).HasColumnName("F_DeleteTime");

                entity.Property(e => e.FDeleteUserId)
                    .HasColumnName("F_DeleteUserId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDepartmentId)
                    .HasColumnName("F_DepartmentId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDescription)
                    .HasColumnName("F_Description")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FDutyId)
                    .HasColumnName("F_DutyId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FEmail)
                    .HasColumnName("F_Email")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FEnabledMark)
                    .HasColumnName("F_EnabledMark")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FGender)
                    .HasColumnName("F_Gender")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FHeadIcon)
                    .HasColumnName("F_HeadIcon")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FIsAdministrator)
                    .HasColumnName("F_IsAdministrator")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FLastModifyTime).HasColumnName("F_LastModifyTime");

                entity.Property(e => e.FLastModifyUserId)
                    .HasColumnName("F_LastModifyUserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FManagerId)
                    .HasColumnName("F_ManagerId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FMobilePhone)
                    .HasColumnName("F_MobilePhone")
                    .HasColumnType("varchar(20)");

                entity.Property(e => e.FNickName)
                    .HasColumnName("F_NickName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FOrganizeId)
                    .HasColumnName("F_OrganizeId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FRealName)
                    .HasColumnName("F_RealName")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FRoleId)
                    .HasColumnName("F_RoleId")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FSecurityLevel)
                    .HasColumnName("F_SecurityLevel")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FSignature)
                    .HasColumnName("F_Signature")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FSortCode)
                    .HasColumnName("F_SortCode")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FWeChat)
                    .HasColumnName("F_WeChat")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<SysUserlogon>(entity =>
            {
                entity.HasKey(e => e.FId)
                    .HasName("PRIMARY");

                entity.ToTable("sys_userlogon");

                entity.HasIndex(e => e.FId)
                    .HasName("PK_SYS_USERLOGON")
                    .IsUnique();

                entity.Property(e => e.FId)
                    .HasColumnName("F_Id")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FAllowEndTime).HasColumnName("F_AllowEndTime");

                entity.Property(e => e.FAllowStartTime).HasColumnName("F_AllowStartTime");

                entity.Property(e => e.FAnswerQuestion)
                    .HasColumnName("F_AnswerQuestion")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.FChangePasswordDate).HasColumnName("F_ChangePasswordDate");

                entity.Property(e => e.FCheckIpaddress)
                    .HasColumnName("F_CheckIPAddress")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FFirstVisitTime).HasColumnName("F_FirstVisitTime");

                entity.Property(e => e.FLanguage)
                    .HasColumnName("F_Language")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FLastVisitTime).HasColumnName("F_LastVisitTime");

                entity.Property(e => e.FLockEndDate).HasColumnName("F_LockEndDate");

                entity.Property(e => e.FLockStartDate).HasColumnName("F_LockStartDate");

                entity.Property(e => e.FLogOnCount)
                    .HasColumnName("F_LogOnCount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.FMultiUserLogin)
                    .HasColumnName("F_MultiUserLogin")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FPreviousVisitTime).HasColumnName("F_PreviousVisitTime");

                entity.Property(e => e.FQuestion)
                    .HasColumnName("F_Question")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FTheme)
                    .HasColumnName("F_Theme")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FUserId)
                    .HasColumnName("F_UserId")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FUserOnLine)
                    .HasColumnName("F_UserOnLine")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.FUserPassword)
                    .HasColumnName("F_UserPassword")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.FUserSecretkey)
                    .HasColumnName("F_UserSecretkey")
                    .HasColumnType("varchar(50)");
            });
        }
    }
}
