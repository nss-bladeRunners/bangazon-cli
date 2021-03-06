USE [BladeRunners]
GO
/****** Object:  Table [dbo].[Payments]    Script Date: 3/6/2018 20:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Payments](
	[PaymentId] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
	[AccountNumber] [nvarchar](50) NOT NULL,
	[CustomerId] [int] NOT NULL,
 CONSTRAINT [PK_Payments] PRIMARY KEY CLUSTERED 
(
	[PaymentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Payments] ON 

INSERT [dbo].[Payments] ([PaymentId], [Type], [AccountNumber], [CustomerId]) VALUES (2, N'Amex', N'12345', 1)
INSERT [dbo].[Payments] ([PaymentId], [Type], [AccountNumber], [CustomerId]) VALUES (3, N'0', N'0', 1)
INSERT [dbo].[Payments] ([PaymentId], [Type], [AccountNumber], [CustomerId]) VALUES (4, N'Monster', N'123123', 1)
INSERT [dbo].[Payments] ([PaymentId], [Type], [AccountNumber], [CustomerId]) VALUES (5, N'Visa', N'1234567', 1)
SET IDENTITY_INSERT [dbo].[Payments] OFF
ALTER TABLE [dbo].[Payments]  WITH CHECK ADD  CONSTRAINT [FK_Payments_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([CustomerId])
GO
ALTER TABLE [dbo].[Payments] CHECK CONSTRAINT [FK_Payments_Customers]
GO
