if not exists(
        select *
        from sys.objects
        where object_id = OBJECT_ID(N'[dbo].[Animes]')
          and type in (N'U')
    )
    begin
        ---create table animes here
        create table [dbo].[Animes]
        (
            [Id]       uniqueidentifier not null,
            [Name]     varchar(100)     not null,
            [StudioId] uniqueidentifier not null,
            constraint [PK_ANIME] PRIMARY KEY CLUSTERED ([Id])
        )
    end
GO

if not exists(
        select *
        from sys.objects
        where object_id = OBJECT_ID(N'[dbo].[Studios]')
          and type in (N'U')
    )
    begin
        ---create table animes here
        create table [dbo].[Studios]
        (
            [Id]       uniqueidentifier not null,
            [Name]     varchar(100)     not null,
            [StudioId] uniqueidentifier not null,
            constraint [PK_STUDIO] PRIMARY KEY CLUSTERED ([Id])
        )
    end
GO
