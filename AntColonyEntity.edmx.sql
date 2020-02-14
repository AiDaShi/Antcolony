
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/14/2020 16:41:52
-- Generated from EDMX file: F:\蚁群团队项目\ConsoleApp1\ConsoleApp1\AntColonyEntity.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Antcolony];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_CompanyTeam]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Team] DROP CONSTRAINT [FK_CompanyTeam];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamTeam_Relation_User]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Team_Relation_User] DROP CONSTRAINT [FK_TeamTeam_Relation_User];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamTeamTypeTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamTypeTable] DROP CONSTRAINT [FK_TeamTeamTypeTable];
GO
IF OBJECT_ID(N'[dbo].[FK_RoleTableRole_Post_Power]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Role_Post_Power] DROP CONSTRAINT [FK_RoleTableRole_Post_Power];
GO
IF OBJECT_ID(N'[dbo].[FK_Role_Post_PowerPower]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Role_Post_Power] DROP CONSTRAINT [FK_Role_Post_PowerPower];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamTeamRoleTable]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamRoleTable] DROP CONSTRAINT [FK_TeamTeamRoleTable];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamRoleTableTeamRole_Post_Power]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[TeamRole_Post_Power] DROP CONSTRAINT [FK_TeamRoleTableTeamRole_Post_Power];
GO
IF OBJECT_ID(N'[dbo].[FK_TeamRole_Post_PowerPower]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Power] DROP CONSTRAINT [FK_TeamRole_Post_PowerPower];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectMessage]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectMessage] DROP CONSTRAINT [FK_ProjectProjectMessage];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTypeProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_ProjectTypeProject];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectFile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectFile] DROP CONSTRAINT [FK_ProjectProjectFile];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectFileTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectFileTag] DROP CONSTRAINT [FK_ProjectProjectFileTag];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectFileProjectFileTag]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectFile] DROP CONSTRAINT [FK_ProjectFileProjectFileTag];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_ProjectUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectProjectTaskList]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ProjectTaskList] DROP CONSTRAINT [FK_ProjectProjectTaskList];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectTaskListUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_ProjectTaskListUser];
GO
IF OBJECT_ID(N'[dbo].[FK_ProjectStateTableProject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Project] DROP CONSTRAINT [FK_ProjectStateTableProject];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO
IF OBJECT_ID(N'[dbo].[RootAdmin]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RootAdmin];
GO
IF OBJECT_ID(N'[dbo].[Company]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Company];
GO
IF OBJECT_ID(N'[dbo].[Team]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Team];
GO
IF OBJECT_ID(N'[dbo].[Team_Relation_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Team_Relation_User];
GO
IF OBJECT_ID(N'[dbo].[TeamTypeTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamTypeTable];
GO
IF OBJECT_ID(N'[dbo].[Power]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Power];
GO
IF OBJECT_ID(N'[dbo].[RoleTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RoleTable];
GO
IF OBJECT_ID(N'[dbo].[Role_Post_Power]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role_Post_Power];
GO
IF OBJECT_ID(N'[dbo].[Role_Post_User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Role_Post_User];
GO
IF OBJECT_ID(N'[dbo].[SpecialPermissionTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SpecialPermissionTable];
GO
IF OBJECT_ID(N'[dbo].[TeamRoleTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamRoleTable];
GO
IF OBJECT_ID(N'[dbo].[TeamRole_Post_Power]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamRole_Post_Power];
GO
IF OBJECT_ID(N'[dbo].[TeamSpecialPermissionTableSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TeamSpecialPermissionTableSet];
GO
IF OBJECT_ID(N'[dbo].[Project]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Project];
GO
IF OBJECT_ID(N'[dbo].[ProjectMessage]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectMessage];
GO
IF OBJECT_ID(N'[dbo].[ProjectType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectType];
GO
IF OBJECT_ID(N'[dbo].[ProjectFile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectFile];
GO
IF OBJECT_ID(N'[dbo].[ProjectFileTag]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectFileTag];
GO
IF OBJECT_ID(N'[dbo].[ProjectTaskList]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectTaskList];
GO
IF OBJECT_ID(N'[dbo].[ProjectStateTable]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProjectStateTable];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'User'
CREATE TABLE [dbo].[User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(124)  NOT NULL,
    [RealyName] nvarchar(124)  NOT NULL,
    [Pwd] nvarchar(64)  NOT NULL,
    [Sex] bit  NOT NULL,
    [Email] nvarchar(124)  NULL,
    [Phone] nvarchar(124)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] bit  NOT NULL,
    [Image] nvarchar(max)  NULL,
    [Project_Id] int  NULL,
    [ProjectTaskList_Id] int  NULL
);
GO

-- Creating table 'RootAdmin'
CREATE TABLE [dbo].[RootAdmin] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] bit  NOT NULL
);
GO

-- Creating table 'Company'
CREATE TABLE [dbo].[Company] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [CompanyName] nvarchar(124)  NOT NULL,
    [CompanyInfo] nvarchar(max)  NOT NULL,
    [CompanyIcon] nvarchar(max)  NULL,
    [CompanyUrl] nvarchar(max)  NULL,
    [CompanyAddress] nvarchar(max)  NOT NULL,
    [CorporaterepResentative] nvarchar(124)  NOT NULL,
    [CompanyMainUser] int  NOT NULL,
    [CompanyTerritory] nvarchar(max)  NULL,
    [CompanyYearOfEstablishment] datetime  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL
);
GO

-- Creating table 'Team'
CREATE TABLE [dbo].[Team] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TeamName] nvarchar(124)  NOT NULL,
    [TeamInfo] nvarchar(max)  NOT NULL,
    [TeamLogo] nvarchar(max)  NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [TeamAdmin] int  NOT NULL,
    [Company_Id] int  NULL
);
GO

-- Creating table 'Team_Relation_User'
CREATE TABLE [dbo].[Team_Relation_User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [TeamType] int  NULL,
    [UserRemark] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] bit  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- Creating table 'TeamTypeTable'
CREATE TABLE [dbo].[TeamTypeTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(124)  NOT NULL,
    [RemarkTag] nvarchar(max)  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- Creating table 'Power'
CREATE TABLE [dbo].[Power] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(124)  NOT NULL,
    [Image] nvarchar(max)  NULL,
    [Route] nvarchar(124)  NOT NULL,
    [Action] nvarchar(124)  NOT NULL,
    [Method] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] bit  NULL,
    [State] smallint  NOT NULL,
    [IsCompany] bit  NOT NULL,
    [TeamRole_Post_Power_Id] int  NULL
);
GO

-- Creating table 'RoleTable'
CREATE TABLE [dbo].[RoleTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(124)  NOT NULL,
    [Image] nvarchar(max)  NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL
);
GO

-- Creating table 'Role_Post_Power'
CREATE TABLE [dbo].[Role_Post_Power] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [State] smallint  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [RoleTable_Id] int  NULL,
    [Power_Id] int  NULL
);
GO

-- Creating table 'Role_Post_User'
CREATE TABLE [dbo].[Role_Post_User] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [RoleId] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [State] smallint  NOT NULL
);
GO

-- Creating table 'SpecialPermissionTable'
CREATE TABLE [dbo].[SpecialPermissionTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [SpecialId] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [State] smallint  NOT NULL
);
GO

-- Creating table 'TeamRoleTable'
CREATE TABLE [dbo].[TeamRoleTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(124)  NOT NULL,
    [Image] nvarchar(max)  NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [Team_Id] int  NOT NULL
);
GO

-- Creating table 'TeamRole_Post_Power'
CREATE TABLE [dbo].[TeamRole_Post_Power] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [State] smallint  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [TeamRoleTable_Id] int  NOT NULL
);
GO

-- Creating table 'TeamSpecialPermissionTableSet'
CREATE TABLE [dbo].[TeamSpecialPermissionTableSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserId] int  NOT NULL,
    [SpecialId] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [TeamId] int  NOT NULL
);
GO

-- Creating table 'Project'
CREATE TABLE [dbo].[Project] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProjectName] nvarchar(254)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [MainUserId] int  NOT NULL,
    [Teamid] int  NOT NULL,
    [ProjectInfo] nvarchar(max)  NOT NULL,
    [ProjectImg] nvarchar(max)  NOT NULL,
    [SpeedOfProgress] int  NOT NULL,
    [Edition] nvarchar(124)  NOT NULL,
    [GitHubUrl] nvarchar(max)  NULL,
    [Priority] smallint  NOT NULL,
    [EstimatedTime] datetime  NOT NULL,
    [WareHourseUrl] nvarchar(max)  NOT NULL,
    [Money] float  NOT NULL,
    [ProjectType_Id] int  NOT NULL,
    [ProjectStateTable_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectMessage'
CREATE TABLE [dbo].[ProjectMessage] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Message] nvarchar(max)  NOT NULL,
    [Userid] int  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [Parentid] int  NULL,
    [Project_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectType'
CREATE TABLE [dbo].[ProjectType] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL
);
GO

-- Creating table 'ProjectFile'
CREATE TABLE [dbo].[ProjectFile] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FileName] nvarchar(254)  NOT NULL,
    [FileUrl] nvarchar(max)  NOT NULL,
    [SuffixName] nvarchar(124)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [Project_Id] int  NOT NULL,
    [ProjectFileTag_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectFileTag'
CREATE TABLE [dbo].[ProjectFileTag] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TagName] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [Project_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectTaskList'
CREATE TABLE [dbo].[ProjectTaskList] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [TaskName] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [FromTime] datetime  NOT NULL,
    [ToTime] datetime  NOT NULL,
    [TaskMainUser] int  NOT NULL,
    [Project_Id] int  NOT NULL
);
GO

-- Creating table 'ProjectStateTable'
CREATE TABLE [dbo].[ProjectStateTable] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [CreateTime] datetime  NOT NULL,
    [UpdateTime] datetime  NULL,
    [DeleteTime] datetime  NULL,
    [State] smallint  NOT NULL,
    [Color] nvarchar(100)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [PK_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RootAdmin'
ALTER TABLE [dbo].[RootAdmin]
ADD CONSTRAINT [PK_RootAdmin]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Company'
ALTER TABLE [dbo].[Company]
ADD CONSTRAINT [PK_Company]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Team'
ALTER TABLE [dbo].[Team]
ADD CONSTRAINT [PK_Team]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Team_Relation_User'
ALTER TABLE [dbo].[Team_Relation_User]
ADD CONSTRAINT [PK_Team_Relation_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamTypeTable'
ALTER TABLE [dbo].[TeamTypeTable]
ADD CONSTRAINT [PK_TeamTypeTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Power'
ALTER TABLE [dbo].[Power]
ADD CONSTRAINT [PK_Power]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'RoleTable'
ALTER TABLE [dbo].[RoleTable]
ADD CONSTRAINT [PK_RoleTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role_Post_Power'
ALTER TABLE [dbo].[Role_Post_Power]
ADD CONSTRAINT [PK_Role_Post_Power]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Role_Post_User'
ALTER TABLE [dbo].[Role_Post_User]
ADD CONSTRAINT [PK_Role_Post_User]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecialPermissionTable'
ALTER TABLE [dbo].[SpecialPermissionTable]
ADD CONSTRAINT [PK_SpecialPermissionTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamRoleTable'
ALTER TABLE [dbo].[TeamRoleTable]
ADD CONSTRAINT [PK_TeamRoleTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamRole_Post_Power'
ALTER TABLE [dbo].[TeamRole_Post_Power]
ADD CONSTRAINT [PK_TeamRole_Post_Power]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TeamSpecialPermissionTableSet'
ALTER TABLE [dbo].[TeamSpecialPermissionTableSet]
ADD CONSTRAINT [PK_TeamSpecialPermissionTableSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [PK_Project]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectMessage'
ALTER TABLE [dbo].[ProjectMessage]
ADD CONSTRAINT [PK_ProjectMessage]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectType'
ALTER TABLE [dbo].[ProjectType]
ADD CONSTRAINT [PK_ProjectType]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectFile'
ALTER TABLE [dbo].[ProjectFile]
ADD CONSTRAINT [PK_ProjectFile]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectFileTag'
ALTER TABLE [dbo].[ProjectFileTag]
ADD CONSTRAINT [PK_ProjectFileTag]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectTaskList'
ALTER TABLE [dbo].[ProjectTaskList]
ADD CONSTRAINT [PK_ProjectTaskList]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProjectStateTable'
ALTER TABLE [dbo].[ProjectStateTable]
ADD CONSTRAINT [PK_ProjectStateTable]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Company_Id] in table 'Team'
ALTER TABLE [dbo].[Team]
ADD CONSTRAINT [FK_CompanyTeam]
    FOREIGN KEY ([Company_Id])
    REFERENCES [dbo].[Company]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CompanyTeam'
CREATE INDEX [IX_FK_CompanyTeam]
ON [dbo].[Team]
    ([Company_Id]);
GO

-- Creating foreign key on [Team_Id] in table 'Team_Relation_User'
ALTER TABLE [dbo].[Team_Relation_User]
ADD CONSTRAINT [FK_TeamTeam_Relation_User]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeam_Relation_User'
CREATE INDEX [IX_FK_TeamTeam_Relation_User]
ON [dbo].[Team_Relation_User]
    ([Team_Id]);
GO

-- Creating foreign key on [Team_Id] in table 'TeamTypeTable'
ALTER TABLE [dbo].[TeamTypeTable]
ADD CONSTRAINT [FK_TeamTeamTypeTable]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeamTypeTable'
CREATE INDEX [IX_FK_TeamTeamTypeTable]
ON [dbo].[TeamTypeTable]
    ([Team_Id]);
GO

-- Creating foreign key on [RoleTable_Id] in table 'Role_Post_Power'
ALTER TABLE [dbo].[Role_Post_Power]
ADD CONSTRAINT [FK_RoleTableRole_Post_Power]
    FOREIGN KEY ([RoleTable_Id])
    REFERENCES [dbo].[RoleTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleTableRole_Post_Power'
CREATE INDEX [IX_FK_RoleTableRole_Post_Power]
ON [dbo].[Role_Post_Power]
    ([RoleTable_Id]);
GO

-- Creating foreign key on [Power_Id] in table 'Role_Post_Power'
ALTER TABLE [dbo].[Role_Post_Power]
ADD CONSTRAINT [FK_Role_Post_PowerPower]
    FOREIGN KEY ([Power_Id])
    REFERENCES [dbo].[Power]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Role_Post_PowerPower'
CREATE INDEX [IX_FK_Role_Post_PowerPower]
ON [dbo].[Role_Post_Power]
    ([Power_Id]);
GO

-- Creating foreign key on [Team_Id] in table 'TeamRoleTable'
ALTER TABLE [dbo].[TeamRoleTable]
ADD CONSTRAINT [FK_TeamTeamRoleTable]
    FOREIGN KEY ([Team_Id])
    REFERENCES [dbo].[Team]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamTeamRoleTable'
CREATE INDEX [IX_FK_TeamTeamRoleTable]
ON [dbo].[TeamRoleTable]
    ([Team_Id]);
GO

-- Creating foreign key on [TeamRoleTable_Id] in table 'TeamRole_Post_Power'
ALTER TABLE [dbo].[TeamRole_Post_Power]
ADD CONSTRAINT [FK_TeamRoleTableTeamRole_Post_Power]
    FOREIGN KEY ([TeamRoleTable_Id])
    REFERENCES [dbo].[TeamRoleTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamRoleTableTeamRole_Post_Power'
CREATE INDEX [IX_FK_TeamRoleTableTeamRole_Post_Power]
ON [dbo].[TeamRole_Post_Power]
    ([TeamRoleTable_Id]);
GO

-- Creating foreign key on [TeamRole_Post_Power_Id] in table 'Power'
ALTER TABLE [dbo].[Power]
ADD CONSTRAINT [FK_TeamRole_Post_PowerPower]
    FOREIGN KEY ([TeamRole_Post_Power_Id])
    REFERENCES [dbo].[TeamRole_Post_Power]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TeamRole_Post_PowerPower'
CREATE INDEX [IX_FK_TeamRole_Post_PowerPower]
ON [dbo].[Power]
    ([TeamRole_Post_Power_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'ProjectMessage'
ALTER TABLE [dbo].[ProjectMessage]
ADD CONSTRAINT [FK_ProjectProjectMessage]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectMessage'
CREATE INDEX [IX_FK_ProjectProjectMessage]
ON [dbo].[ProjectMessage]
    ([Project_Id]);
GO

-- Creating foreign key on [ProjectType_Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_ProjectTypeProject]
    FOREIGN KEY ([ProjectType_Id])
    REFERENCES [dbo].[ProjectType]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTypeProject'
CREATE INDEX [IX_FK_ProjectTypeProject]
ON [dbo].[Project]
    ([ProjectType_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'ProjectFile'
ALTER TABLE [dbo].[ProjectFile]
ADD CONSTRAINT [FK_ProjectProjectFile]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectFile'
CREATE INDEX [IX_FK_ProjectProjectFile]
ON [dbo].[ProjectFile]
    ([Project_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'ProjectFileTag'
ALTER TABLE [dbo].[ProjectFileTag]
ADD CONSTRAINT [FK_ProjectProjectFileTag]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectFileTag'
CREATE INDEX [IX_FK_ProjectProjectFileTag]
ON [dbo].[ProjectFileTag]
    ([Project_Id]);
GO

-- Creating foreign key on [ProjectFileTag_Id] in table 'ProjectFile'
ALTER TABLE [dbo].[ProjectFile]
ADD CONSTRAINT [FK_ProjectFileProjectFileTag]
    FOREIGN KEY ([ProjectFileTag_Id])
    REFERENCES [dbo].[ProjectFileTag]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectFileProjectFileTag'
CREATE INDEX [IX_FK_ProjectFileProjectFileTag]
ON [dbo].[ProjectFile]
    ([ProjectFileTag_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_ProjectUser]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectUser'
CREATE INDEX [IX_FK_ProjectUser]
ON [dbo].[User]
    ([Project_Id]);
GO

-- Creating foreign key on [Project_Id] in table 'ProjectTaskList'
ALTER TABLE [dbo].[ProjectTaskList]
ADD CONSTRAINT [FK_ProjectProjectTaskList]
    FOREIGN KEY ([Project_Id])
    REFERENCES [dbo].[Project]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectProjectTaskList'
CREATE INDEX [IX_FK_ProjectProjectTaskList]
ON [dbo].[ProjectTaskList]
    ([Project_Id]);
GO

-- Creating foreign key on [ProjectTaskList_Id] in table 'User'
ALTER TABLE [dbo].[User]
ADD CONSTRAINT [FK_ProjectTaskListUser]
    FOREIGN KEY ([ProjectTaskList_Id])
    REFERENCES [dbo].[ProjectTaskList]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectTaskListUser'
CREATE INDEX [IX_FK_ProjectTaskListUser]
ON [dbo].[User]
    ([ProjectTaskList_Id]);
GO

-- Creating foreign key on [ProjectStateTable_Id] in table 'Project'
ALTER TABLE [dbo].[Project]
ADD CONSTRAINT [FK_ProjectStateTableProject]
    FOREIGN KEY ([ProjectStateTable_Id])
    REFERENCES [dbo].[ProjectStateTable]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProjectStateTableProject'
CREATE INDEX [IX_FK_ProjectStateTableProject]
ON [dbo].[Project]
    ([ProjectStateTable_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------