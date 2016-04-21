USE [InnoSTARKSystem]
GO

/****** Object:  Table [dbo].[Attendance]    Script Date: 9/30/2015 5:23:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Attendance](
	[AttendanceId] [bigint] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[CheckInTime] [datetime] NOT NULL,
	[AwayFromTime] [datetime] NULL,
	[AwayToTime] [datetime] NULL,
	[CheckOutTime] [datetime] NOT NULL,
	[IsEdited] [bit] NOT NULL,
	[EditedBy] [int] NULL,
	[EditedDate] [datetime] NULL,
	[Comments] [nvarchar](max) NULL,
	[IP] [nvarchar](max) NULL,
	[RecCreatedBy] [nvarchar](200) NOT NULL,
	[RecCreatedDate] [datetime] NOT NULL,
	[RecLastUpdatedBy] [nvarchar](200) NOT NULL,
	[RecLastUpdatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_Attendance] PRIMARY KEY CLUSTERED 
(
	[AttendanceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Employee_EditedBy] FOREIGN KEY([EditedBy])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Employee_EditedBy]
GO

ALTER TABLE [dbo].[Attendance]  WITH CHECK ADD  CONSTRAINT [FK_Attendance_Employee_EmployeeId] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO

ALTER TABLE [dbo].[Attendance] CHECK CONSTRAINT [FK_Attendance_Employee_EmployeeId]
GO

