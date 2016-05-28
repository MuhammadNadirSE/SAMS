USE [HatanSystem]
GO

/****** Object:  Table [dbo].[Exclusions]    Script Date: 5/28/2016 11:25:30 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Exclusions](
	[ExclusionId] [INT] IDENTITY(1,1) NOT NULL,
	[Name] [VARCHAR](1000) NOT NULL,
	[CreatedBy] [NVARCHAR](128) NOT NULL,
	[CreatedDate] [DATETIME] NOT NULL,
	[UpdatedBy] [NVARCHAR](128) NOT NULL,
	[UpdatedDate] [DATETIME] NOT NULL,
 CONSTRAINT [PK_Exclusions] PRIMARY KEY CLUSTERED 
(
	[ExclusionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Exclusions]  WITH CHECK ADD  CONSTRAINT [FK_Exclusions_AspNetUsers] FOREIGN KEY([UpdatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Exclusions] CHECK CONSTRAINT [FK_Exclusions_AspNetUsers]
GO

ALTER TABLE [dbo].[Exclusions]  WITH CHECK ADD  CONSTRAINT [FK_Exclusions_CreatdBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Exclusions] CHECK CONSTRAINT [FK_Exclusions_CreatdBy]
GO


