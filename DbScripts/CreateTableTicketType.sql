USE [InnoSTARKSystem]
GO

/****** Object:  Table [dbo].[TicketType]    Script Date: 9/15/2015 6:51:35 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TicketType](
	[TicketTypeId] [int] IDENTITY(1,1) NOT NULL,
	[TickTitle] [varchar](50) NOT NULL,
	[TicketDescription] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[RecCreatedBy] [varchar](50) NOT NULL,
	[RecCreatedOn] [datetime] NOT NULL,
	[RecLastUpdatedBy] [varchar](50) NOT NULL,
	[RecLastUpdateOn] [datetime] NOT NULL,
 CONSTRAINT [PK_TicketType] PRIMARY KEY CLUSTERED 
(
	[TicketTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TicketType] ADD  CONSTRAINT [DF_TicketType_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

