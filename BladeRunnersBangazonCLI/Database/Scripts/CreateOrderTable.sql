USE [BladeRunners]
GO

ALTER TABLE [dbo].[Orders] DROP CONSTRAINT [FK_Orders_Payments]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 3/7/2018 2:41:43 PM ******/
DROP TABLE [dbo].[Orders]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 3/7/2018 2:41:43 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[OrderId] [int] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[PaymentId] [int] NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Payments] FOREIGN KEY([PaymentId])
REFERENCES [dbo].[Payments] ([PaymentId])
GO

ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Payments]
GO


