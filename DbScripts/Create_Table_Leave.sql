USE [InnoSTARKSystem]
GO

/****** Object:  Table [dbo].[Leave]    Script Date: 9/30/2015 5:20:44 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Leave](
	[LeaveId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[LeaveAppliedFrom] [datetime] NOT NULL,
	[LeaveAppliedTo] [datetime] NOT NULL,
	[ApplicationDescription] [nvarchar](max) NOT NULL,
	[LeaveApprovedFrom] [datetime] NULL,
	[LeaveApprovedTo] [datetime] NULL,
	[LeaveApprovedBy] [int] NOT NULL,
	[LeaveApprovedDate] [datetime] NULL,
	[EditedDateTime] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
	[LeaveTypeId] [int] NOT NULL,
	[RecCreatedBy] [nvarchar](200) NOT NULL,
	[RecCreatedDate] [datetime] NOT NULL,
	[RecLastUpdatedBy] [nvarchar](200) NOT NULL,
	[RecLastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Leave] PRIMARY KEY CLUSTERED 
(
	[LeaveId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_Employee]
GO

ALTER TABLE [dbo].[Leave]  WITH CHECK ADD  CONSTRAINT [FK_Leave_Employee_LeaveApprovedBy] FOREIGN KEY([LeaveApprovedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[Leave] CHECK CONSTRAINT [FK_Leave_Employee_LeaveApprovedBy]
GO

