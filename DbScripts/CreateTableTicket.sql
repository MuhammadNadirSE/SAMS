USE [InnoSTARKSystem]
GO

/****** Object:  Table [dbo].[Ticket]    Script Date: 9/15/2015 6:51:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Ticket](
	[TicketId] [bigint] IDENTITY(1,1) NOT NULL,
	[DateFrom] [datetime] NOT NULL,
	[DateTo] [datetime] NOT NULL,
	[Reason] [nvarchar](max) NOT NULL,
	[UserId] [nvarchar](128) NOT NULL,
	[TicketTypeId] [int] NOT NULL,
	[RecCreatedBy] [varchar](50) NOT NULL,
	[RecCreatedOn] [datetime] NOT NULL,
	[RecLastUpdatedBy] [varchar](50) NOT NULL,
	[RecLastUpdateOn] [datetime] NOT NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[TicketId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_AspNetUsers] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO

ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_AspNetUsers]
GO

ALTER TABLE [dbo].[Ticket]  WITH CHECK ADD  CONSTRAINT [FK_Ticket_TicketType] FOREIGN KEY([TicketTypeId])
REFERENCES [dbo].[TicketType] ([TicketTypeId])
GO

ALTER TABLE [dbo].[Ticket] CHECK CONSTRAINT [FK_Ticket_TicketType]
GO

