USE [BackOffice]
GO
/****** Object:  Table [dbo].[Coin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coin](
	[CoinID] [int] IDENTITY(1,1) NOT NULL,
	[CoinName] [nvarchar](250) NULL,
	[IsDelete] [smallint] NULL,
 CONSTRAINT [PK_Coin] PRIMARY KEY CLUSTERED 
(
	[CoinID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExchangeRate]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExchangeRate](
	[ExchangeRateID] [int] NOT NULL,
	[ExchangeRateName] [nvarchar](250) NULL,
	[ExchangeValue] [numeric](18, 10) NULL,
	[IsActive] [smallint] NULL,
	[IsDelete] [smallint] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](250) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](250) NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteUser] [nvarchar](250) NULL,
 CONSTRAINT [PK_ExchangeRate] PRIMARY KEY CLUSTERED 
(
	[ExchangeRateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](250) NOT NULL,
	[Password] [nvarchar](250) NULL,
	[IsActive] [smallint] NULL,
	[IsDelete] [smallint] NULL,
	[CreateDate] [datetime] NULL,
	[FullName] [nvarchar](250) NULL,
	[Mobile] [nvarchar](50) NULL,
	[Avatar] [nvarchar](250) NULL,
	[Gender] [smallint] NULL,
	[Address] [nvarchar](250) NULL,
	[Birthday] [datetime] NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](250) NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteUser] [nvarchar](250) NULL,
	[LinkActive] [nvarchar](500) NULL,
	[ExpireTimeLink] [datetime] NULL,
 CONSTRAINT [PK_Member] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member_Wallet]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member_Wallet](
	[WalletID] [int] IDENTITY(1,1) NOT NULL,
	[MemberID] [int] NOT NULL,
	[IndexWallet] [int] NULL,
	[NumberCoin] [numeric](18, 8) NULL,
	[IsActive] [smallint] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](250) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](250) NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteUser] [nvarchar](250) NULL,
	[IsDelete] [smallint] NULL,
 CONSTRAINT [PK_Member_Wallet] PRIMARY KEY CLUSTERED 
(
	[WalletID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package](
	[PackageID] [int] IDENTITY(1,1) NOT NULL,
	[PackageName] [nvarchar](250) NULL,
	[PackageValue] [numeric](18, 10) NULL,
	[IsActive] [smallint] NULL,
	[IsDelete] [smallint] NULL,
	[CreateDate] [datetime] NULL,
	[CreateUser] [nvarchar](250) NULL,
	[UpdateDate] [datetime] NULL,
	[UpdateUser] [nvarchar](250) NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteUser] [nvarchar](250) NULL,
 CONSTRAINT [PK_Package] PRIMARY KEY CLUSTERED 
(
	[PackageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Package_Coin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Package_Coin](
	[PackageID] [int] NOT NULL,
	[CoinID] [int] NOT NULL,
	[PackageValue] [numeric](18, 10) NULL,
	[CreateDate] [datetime] NULL,
	[IsDelete] [smallint] NULL,
	[DeleteDate] [datetime] NULL,
	[DeleteUser] [nvarchar](250) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionCoin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionCoin](
	[TransactionID] [char](150) NOT NULL,
	[WalletAddressID] [nvarchar](250) NULL,
	[MemberID] [int] NULL,
	[ValueTransaction] [numeric](18, 10) NULL,
	[QRCode] [nvarchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[ExpireDate] [datetime] NULL,
	[Status] [int] NULL,
	[Note] [nvarchar](2000) NULL,
	[WalletID] [nvarchar](500) NULL,
	[TypeTransactionID] [int] NULL,
	[TransactionBitcoin] [nvarchar](500) NULL,
 CONSTRAINT [PK_TransactionCoin] PRIMARY KEY CLUSTERED 
(
	[TransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionPackage]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionPackage](
	[PackageID] [int] NOT NULL,
	[CoinID] [int] NOT NULL,
	[MemberID] [int] NOT NULL,
	[TransactionCode] [nvarchar](500) NULL,
	[CreateDate] [datetime] NULL,
	[ExpireDate] [datetime] NULL,
	[Status] [int] NULL,
	[Note] [nvarchar](2000) NULL,
	[TransactionBitcoin] [nvarchar](500) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TypeTransaction]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TypeTransaction](
	[TypeTransactionID] [int] IDENTITY(1,1) NOT NULL,
	[TypeTransactionName] [nvarchar](250) NULL,
	[IsActive] [smallint] NULL,
 CONSTRAINT [PK_TypeTransaction] PRIMARY KEY CLUSTERED 
(
	[TypeTransactionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Coin] ON 

INSERT [dbo].[Coin] ([CoinID], [CoinName], [IsDelete]) VALUES (1, N'BTC', 0)
INSERT [dbo].[Coin] ([CoinID], [CoinName], [IsDelete]) VALUES (3, N'USD', 0)
SET IDENTITY_INSERT [dbo].[Coin] OFF
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (1, N'test@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-23T21:22:09.167' AS DateTime), N'test', N'01987657345    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (2, N'test123@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-23T21:29:06.923' AS DateTime), N'test', N'01987534637    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (3, N'phatbui@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-23T21:33:34.613' AS DateTime), N'phatbui', N'01989765735    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (4, N'test1234@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-23T21:36:24.987' AS DateTime), N'test123', N'01984635674    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (5, N'abcd@gmail.com', N'25d55ad283aa400af464c76d713c07ad', 1, 0, CAST(N'2017-11-23T21:37:38.960' AS DateTime), N'abcd', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (6, N'test.123@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-23T21:51:56.470' AS DateTime), N'test123', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (7, N'test.12345@gmail.com', N'test.12345@gmail.com', 1, 0, CAST(N'2017-11-23T22:30:10.760' AS DateTime), N'test.12345', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (8, N'test123.123@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-23T22:31:29.520' AS DateTime), N'test123.123', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (9, N'testabcd@gmail.com', N'testabcd@gmail.com', 1, 0, CAST(N'2017-11-23T23:44:12.537' AS DateTime), N'testabcd@gmail.com', N'01834687584    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (10, N'asdf@gmail.com', N'asdf@gmail.com', 1, 0, CAST(N'2017-11-23T23:53:20.660' AS DateTime), N'asdf@gmail.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (11, N'', N'', 1, 0, CAST(N'2017-11-24T00:04:43.330' AS DateTime), N'', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (12, N'testabcdef@gmail.com', N'testabcdef@gmail.com', 1, 0, CAST(N'2017-11-24T00:29:23.607' AS DateTime), N'testabcdef@gmail.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (13, N'testasdf@gmail.com', N'testasdf@gmail.com', 1, 0, CAST(N'2017-11-24T12:42:39.277' AS DateTime), N'testasdf@gmail.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (14, N'abcde@gmail.com', N'abcde@gmail.com', 1, 0, CAST(N'2017-11-24T13:41:03.293' AS DateTime), N'abcde@gmail.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (15, N'abcdy@gmail.com', N'abcdy@gmail.com', 1, 0, CAST(N'2017-11-24T14:13:55.113' AS DateTime), N'abcdy@gmail.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (16, N'test1234567@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 1, 0, CAST(N'2017-11-24T14:23:32.577' AS DateTime), N'BBC.Core.Utils.Common', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (17, N'test123.abc@gmail.com', N'25d55ad283aa400af464c76d713c07ad', 1, 0, CAST(N'2017-11-24T14:31:57.740' AS DateTime), N'test123', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (23, N'test123123@gmail.com', N'25d55ad283aa400af464c76d713c07ad', 0, 0, CAST(N'2017-11-25T13:23:11.853' AS DateTime), N'test', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (24, N'123@gmial.com', N'e36f83d674656fcf81611b89e6dd59bb', 0, 0, CAST(N'2017-11-25T13:41:20.397' AS DateTime), N'123@gmial.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (25, N'ex@gmail.com', N'04a3e7fa428bb489b0cf2855d9ed8ce2', 0, 0, CAST(N'2017-11-25T14:08:38.250' AS DateTime), N'ex@gmail.com', N'               ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (26, N'abcd123123@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 0, 0, CAST(N'2017-11-25T15:27:45.970' AS DateTime), N'test', N'12312312334    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (27, N'abcd123123123@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 0, 0, CAST(N'2017-11-25T15:30:08.003' AS DateTime), N'test', N'123123123124   ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (28, N'testtest@gmial.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 0, 0, CAST(N'2017-11-25T15:34:29.747' AS DateTime), N'test', N'12312332423    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (29, N'abcsfdfdfd@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 0, 0, CAST(N'2017-11-25T15:37:00.923' AS DateTime), N'dfefdsfdsf', N'121212121212   ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (30, N'abcrerewrd@gmail.com', N'f5bb0c8de146c67b44babbf4e6584cc0', 0, 0, CAST(N'2017-11-25T15:41:29.287' AS DateTime), N'fweewrew', N'432432432432   ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Member] ([MemberID], [Email], [Password], [IsActive], [IsDelete], [CreateDate], [FullName], [Mobile], [Avatar], [Gender], [Address], [Birthday], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [LinkActive], [ExpireTimeLink]) VALUES (36, N'buitanphat1991@gmail.com', N'25d55ad283aa400af464c76d713c07ad', 1, 0, CAST(N'2017-11-27T09:29:28.027' AS DateTime), N'phatbui', N'54354356433    ', N'', 1, N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Member] OFF
SET IDENTITY_INSERT [dbo].[Member_Wallet] ON 

INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (1, 1, 1, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (2, 2, 2, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (3, 3, 3, CAST(2.48772195 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (4, 4, 4, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (5, 5, 5, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (6, 6, 6, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (7, 7, 7, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (8, 8, 8, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (9, 9, 9, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (10, 10, 10, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (11, 11, 11, CAST(0.00000000 AS Numeric(18, 8)), 0, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (12, 17, 17, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (13, 18, 18, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (14, 19, 19, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (15, 20, 20, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (16, 21, 21, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (17, 22, 22, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (18, 23, 23, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (19, 24, 24, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (20, 25, 25, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (21, 26, 26, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (22, 27, 27, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (23, 28, 28, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (24, 29, 29, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (25, 30, 30, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (26, 31, 31, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (27, 32, 32, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (28, 33, 33, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (29, 34, 34, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (30, 35, 35, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
INSERT [dbo].[Member_Wallet] ([WalletID], [MemberID], [IndexWallet], [NumberCoin], [IsActive], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser], [IsDelete]) VALUES (31, 36, 36, CAST(0.00000000 AS Numeric(18, 8)), 1, NULL, NULL, NULL, NULL, NULL, NULL, 0)
SET IDENTITY_INSERT [dbo].[Member_Wallet] OFF
SET IDENTITY_INSERT [dbo].[Package] ON 

INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (1, N'package1', CAST(100.0000000000 AS Numeric(18, 10)), 1, 0, CAST(N'2012-01-01T00:00:00.000' AS DateTime), N'', CAST(N'2017-11-28T13:55:19.480' AS DateTime), N'phatbui', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (2, N'package2', CAST(11.3230000000 AS Numeric(18, 10)), 1, 0, CAST(N'2017-11-28T09:26:05.973' AS DateTime), N'', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'', CAST(N'2017-11-28T15:31:07.143' AS DateTime), N'phatbui')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (3, N'package3', CAST(111.3230000000 AS Numeric(18, 10)), 1, 0, CAST(N'2017-11-28T10:13:31.260' AS DateTime), N'', CAST(N'1990-01-01T00:00:00.000' AS DateTime), N'', CAST(N'2017-11-28T15:07:26.620' AS DateTime), N'phatbui')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (4, N'package4', CAST(112.3230000000 AS Numeric(18, 10)), 1, 0, CAST(N'2017-11-28T10:15:27.597' AS DateTime), N'', CAST(N'2017-11-28T14:04:45.243' AS DateTime), N'phatbui', CAST(N'2017-11-28T17:17:00.790' AS DateTime), N'phatbui')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (5, N'package 5', CAST(113.3230000000 AS Numeric(18, 10)), 1, 0, CAST(N'2017-11-28T14:00:34.130' AS DateTime), N'phatbui', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (6, N'package 6', CAST(114.3230000000 AS Numeric(18, 10)), 1, 0, CAST(N'2017-11-28T14:00:46.123' AS DateTime), N'phatbui', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (7, N'package 7', CAST(115.3230000000 AS Numeric(18, 10)), 1, 0, CAST(N'2017-11-28T15:30:52.407' AS DateTime), N'phatbui', CAST(N'2017-11-28T15:31:00.383' AS DateTime), N'phatbui', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (8, N'test61', CAST(116.3230000000 AS Numeric(18, 10)), 1, 1, CAST(N'2017-11-28T17:16:49.623' AS DateTime), N'phatbui', CAST(N'2017-11-28T17:16:55.890' AS DateTime), N'phatbui', CAST(N'2017-12-03T16:04:58.550' AS DateTime), N'abcd')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (9, N'test6122', CAST(117.3230000000 AS Numeric(18, 10)), 1, 1, CAST(N'2017-11-28T17:37:23.107' AS DateTime), N'abcd', CAST(N'2017-11-30T17:28:24.230' AS DateTime), N'abcd', CAST(N'2017-11-30T17:30:42.000' AS DateTime), N'abcd')
INSERT [dbo].[Package] ([PackageID], [PackageName], [PackageValue], [IsActive], [IsDelete], [CreateDate], [CreateUser], [UpdateDate], [UpdateUser], [DeleteDate], [DeleteUser]) VALUES (10, N'test12345', CAST(22.3420000000 AS Numeric(18, 10)), 1, 1, CAST(N'2017-11-30T10:56:20.510' AS DateTime), N'phatbui', CAST(N'1900-01-01T00:00:00.000' AS DateTime), N'', CAST(N'2017-11-30T17:22:33.523' AS DateTime), N'abcd')
SET IDENTITY_INSERT [dbo].[Package] OFF
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (1, 1, CAST(1.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (3, 1, CAST(3.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (1, 3, CAST(100.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (2, 1, CAST(2.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (3, 3, CAST(300.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (2, 3, CAST(200.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (6, 3, CAST(123.0000000000 AS Numeric(18, 10)), CAST(N'2017-12-01T14:32:24.850' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (4, 3, CAST(4000.0000000000 AS Numeric(18, 10)), CAST(N'2000-01-01T00:00:00.000' AS DateTime), 0, CAST(N'2017-11-30T18:03:50.080' AS DateTime), N'')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (7, 1, CAST(12.1230000000 AS Numeric(18, 10)), CAST(N'2017-12-03T11:31:03.700' AS DateTime), 1, CAST(N'2017-12-03T11:31:18.420' AS DateTime), N'phatbui')
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (4, 1, CAST(123.0000000000 AS Numeric(18, 10)), CAST(N'2017-12-01T13:45:53.550' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (6, 1, CAST(32.0000000000 AS Numeric(18, 10)), CAST(N'2017-12-01T14:04:24.130' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (5, 3, CAST(32.0000000000 AS Numeric(18, 10)), CAST(N'2017-12-01T14:13:29.817' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (5, 1, CAST(23.3200000000 AS Numeric(18, 10)), CAST(N'2017-12-01T15:17:54.640' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[Package_Coin] ([PackageID], [CoinID], [PackageValue], [CreateDate], [IsDelete], [DeleteDate], [DeleteUser]) VALUES (7, 3, CAST(23.2130000000 AS Numeric(18, 10)), CAST(N'2017-12-02T22:55:27.743' AS DateTime), 0, NULL, NULL)
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'131c418ff61819fd9a09c00378d5107d                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0004882800 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.187' AS DateTime), CAST(N'2017-11-27T16:11:15.187' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'0598229213100e2b1c3770e7bddf636d3f87065c458decca3961745b7e4a43c8')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'54e823de6c14974da22d1ea8a19c7215                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0995000005 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.433' AS DateTime), CAST(N'2017-11-27T16:11:15.433' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'16c7ba57095aefdef1bd21327e937a588789418bc4abd9eabd77e124d569bd97')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'70930282ea983b81aec3e68c7a480df0                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.5500000119 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.313' AS DateTime), CAST(N'2017-11-27T16:11:15.313' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'717bd51bf0a23005eb9c76155bd96c323f09cea267f4b483f405d6f074782f48')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'969dbcdfa8e0e6b6921751b4c378be43                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0002441400 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.217' AS DateTime), CAST(N'2017-11-27T16:11:15.217' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'ba97dd1801bdfea6e80f4d36516f204dfa26acc4b97141f04f968e4d22519883')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'98dcd81c0bd3ba05d548fb20a3e10005                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.2750000060 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.380' AS DateTime), CAST(N'2017-11-27T16:11:15.380' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'cb0047ae09695ef2745d02f23261136ef161f545821c5247d3f620c662073944')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'a0eed9dca0772953140181f0227cc4bc                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0009765600 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.247' AS DateTime), CAST(N'2017-11-27T16:11:15.247' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'e67147b694e135019243a573fb5360dc560debb18e2784e2fa0b12d571472be3')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'aa1e3963ced07c3245a86c369c3dabb4                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.2240048498 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.490' AS DateTime), CAST(N'2017-11-27T16:11:15.490' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'ed3c998921f51e021adc4a5303149b60fc5784e2a516037c900bf920b3be07b2')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'abbda0b026afff3a375dd643dfe1596f                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0019531200 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.283' AS DateTime), CAST(N'2017-11-27T16:11:15.283' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'ea0f84303b4143d0b138dd5e09a6bd466a7cb48ef1ae97b15b1c005856a8b2d0')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'b14885592b7cf03a06b6bffe4e4c859c                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0979999974 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.460' AS DateTime), CAST(N'2017-11-27T16:11:15.460' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'07073e2a563b64ca72d58466767150e1aeafcfdadb719fb8dbf48da8f69a2ade')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'd2beb96b34c669b307cbb368726afde9                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(1.1000000238 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.410' AS DateTime), CAST(N'2017-11-27T16:11:15.410' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'8f2c7b85f140881b6fd9220910813024a17657c0d81c58f0b0f97af38c9024d1')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'f15633dccd7d32538f893249b126554b                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.1375000030 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.347' AS DateTime), CAST(N'2017-11-27T16:11:15.347' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'b16b5e963e95f93104051986bb509f92d47b2a7025d8227cb6975544f1d68ffc')
INSERT [dbo].[TransactionCoin] ([TransactionID], [WalletAddressID], [MemberID], [ValueTransaction], [QRCode], [CreateDate], [ExpireDate], [Status], [Note], [WalletID], [TypeTransactionID], [TransactionBitcoin]) VALUES (N'fdd74e897cf287925dc20768ee58b0f0                                                                                                                      ', N'moRZFDFetcWnygPKejjaCA9jjrir4tS6YU                                                                                                                    ', 3, CAST(0.0000550000 AS Numeric(18, 10)), N'', CAST(N'2017-11-27T15:56:15.107' AS DateTime), CAST(N'2017-11-27T16:11:15.107' AS DateTime), 0, N'Received Coins', N'mk2527QgkMgCyff1qinoZ3sPbnMHpQdsuv', 0, N'2d0493efd2dba31715ca2a01630c09bcff996fa4007fcfa2469b84dace441464')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'a3d211f87659ac97fa2207ad5c5d87b4', CAST(N'2017-11-30T15:17:40.420' AS DateTime), CAST(N'2017-12-30T15:17:40.420' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'd9d6c4d1dd0c71f569dc47d2623f46d3', CAST(N'2017-11-30T16:09:59.573' AS DateTime), CAST(N'2017-12-30T16:09:59.573' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'c94d163918ebaf3d81056091069f64a1', CAST(N'2017-11-30T16:16:52.753' AS DateTime), CAST(N'2017-12-30T16:16:52.753' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'7eb59275a4815ce58d2ad8b448932036', CAST(N'2017-11-30T16:19:30.423' AS DateTime), CAST(N'2017-12-30T16:19:30.423' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'42509d2f81bb865872ea6d87f773dcfa', CAST(N'2017-11-30T16:32:41.963' AS DateTime), CAST(N'2017-12-30T16:32:41.963' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'6db4f9f6611c921b3816fa244047b5ca', CAST(N'2017-11-30T16:37:07.097' AS DateTime), CAST(N'2017-12-30T16:37:07.097' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 3, 3, N'ec73a64d15469eed90c846f3dcea6683', CAST(N'2017-11-30T16:38:12.533' AS DateTime), CAST(N'2017-12-30T16:38:12.533' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (1, 1, 3, N'919a0d7731bc0c4c4b992a6f8dacdad5', CAST(N'2017-11-30T16:38:31.127' AS DateTime), CAST(N'2017-12-30T16:38:31.127' AS DateTime), 1, N'Buy package', N'')
INSERT [dbo].[TransactionPackage] ([PackageID], [CoinID], [MemberID], [TransactionCode], [CreateDate], [ExpireDate], [Status], [Note], [TransactionBitcoin]) VALUES (8, 1, 3, N'f8d2ebb558a973133e2666dba6bcf38d', CAST(N'2017-11-30T17:48:56.783' AS DateTime), CAST(N'2017-12-30T17:48:56.783' AS DateTime), 1, N'Buy package', N'')
ALTER TABLE [dbo].[Package_Coin] ADD  CONSTRAINT [DF_Package_Coin_IsDelete]  DEFAULT ((0)) FOR [IsDelete]
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckEmailExistsFE]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_CheckEmailExistsFE]
(
@email nvarchar(250)
)
as begin 
	select Email from member where Email=@email
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckExistTransactionBitcoinFE]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_CheckExistTransactionBitcoinFE]
(
@TransactionBitcoin nvarchar(500)
)
as begin
	select * from TransactionCoin where TransactionBitcoin = @TransactionBitcoin
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckPackageID_CoinIDExist]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_CheckPackageID_CoinIDExist]
(
	@packageID int,
	@coinID int
)
as begin
	select * from Package_Coin where PackageID=@packageID and CoinID=@coinID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_CheckPackageNameExists]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_CheckPackageNameExists]
(
	@packageName nvarchar(250)

)
as begin 
	select * from Package where PackageName=@packageName
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePackage]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_DeletePackage]
(
	@packageID int,
	--@packageName nvarchar(250),
	@isDelete smallint,	
	@deleteDate Datetime,
	@deleteUser nvarchar(250)
)
as begin 
	update Package 
	 set IsDelete=@isDelete,DeleteDate=@deleteDate,DeleteUser=@deleteUser
	 where PackageID=@packageID
	
end
GO
/****** Object:  StoredProcedure [dbo].[SP_DeletePackageCoin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_DeletePackageCoin]
(
	@packageID int,
	@coinID int,
	@isDelete int,
	@deleteDate Datetime,
	@deleteUser nvarchar(250)
)
as begin
	update Package_Coin
	set IsDelete=@isDelete,DeleteDate=@deleteDate,DeleteUser=@deleteUser
	where PackageID=@packageID and CoinID=@coinID 
	end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetListMember]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetListMember]
(
	@start int,
	@end int
)
 as begin
		select *from (SELECT ROW_NUMBER() OVER (ORDER BY m.MemberID DESC) as Row,SUM(1) OVER()AS TOTALROWS,m.* from  member m ) as Products
		  where Row>=@start and Row<=@end
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_GetMemberByEmail]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_GetMemberByEmail]
(
@email nvarchar(250)
)
as begin 
	select * from member where Email=@email
end
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertMember]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_InsertMember]
(
	@email nvarchar(250),
	@password nvarchar(250),
	@isActive smallint,
	@isDelete smallint,
	@createDate datetime,
	@fullName nvarchar(250),
	@mobile char(15),
	@avatar nvarchar(250),
	@gender smallint
	--@birthday datetime,
	--@linkActive nvarchar(500),
	--@expireTimeLink datetime,
	
	--@addRess nvarchar(250)
)
as begin 
	insert into member(Email,Password,IsActive,IsDelete,CreateDate,FullName,Mobile,Avatar,Gender,Birthday,LinkActive,ExpireTimeLink,UpdateDate,DeleteDate,DeleteUser,UpdateUser,AddRess)
	 values(@email,@password,@isActive,@isDelete,@createDate,@fullName,@mobile,@avatar,@gender,'','','','','','','','')
	  SELECT SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertMemberWallet]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_InsertMemberWallet]
(
	@IndexWallet int,
	@IsActive smallint,
	@IsDelete smallint,
	@MemberID int,
 	@NumberCoin float
)
as begin 
	insert into Member_Wallet(IndexWallet,IsActive,IsDelete,MemberID,NumberCoin) values(@IndexWallet,@IsActive,@IsDelete,@MemberID,@NumberCoin)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertPackage]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_InsertPackage]
(
	@packageName nvarchar(250),
	@packageValue numeric(18, 10),
	@isActive smallint,
	@isDelete smallint,
	@createDate datetime,
	@createUser nvarchar(250)
	--@updateDate Datetime,
	--@updateUser nvarchar(250),
	--@deleteDate Datetime,
	--@deleteUser nvarchar(250)

)
as begin 
	insert into Package(PackageName,PackageValue,IsActive,IsDelete,CreateDate,CreateUser,UpdateDate,UpdateUser,DeleteDate,DeleteUser)
	 values(@packageName,@packageValue,@isActive,@isDelete,@createDate,@createUser,'','','','')
end

GO
/****** Object:  StoredProcedure [dbo].[SP_InsertPackageCoin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_InsertPackageCoin]
(
	@packageID int,
	@coinID int,
	@packageValue numeric(18,10),
	@createDate DateTime,
	@isDelete int
)
as begin 
	insert into Package_Coin(PackageID,CoinID,PackageValue,CreateDate,IsDelete)
	 values(@packageID,@coinID,@packageValue,@createDate,@isDelete)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertTransactionCoinFE]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_InsertTransactionCoinFE]
(
	@MemberID int,
	@WalletAddressID char(150),
	@ValueTransaction numeric(18, 10),
	@QRCode  nvarchar(500),
	@CreateDate datetime,
	@ExpireDate datetime,
	@Status smallint,
	@Note nvarchar(2500),
	@WalletID nvarchar(500),
	@TypeTransactionID int,
	@TransactionBitcoin nvarchar(500),
	@TransactionID char(150)
)
as begin
	insert into TransactionCoin(TransactionID,WalletAddressID,MemberID,ValueTransaction,QRCode,CreateDate,ExpireDate,Status,Note,WalletID,TypeTransactionID,TransactionBitcoin) 
                                values(@TransactionID,@WalletAddressID,@MemberID,@ValueTransaction,@QRCode,@CreateDate,@ExpireDate,@Status,@Note,@WalletID,@TypeTransactionID,@TransactionBitcoin)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertTransactionPackageFE]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_InsertTransactionPackageFE]
(
	@memberid int,
	@packageid int,
	@coinid int,
	@createdate datetime,
	@expiredate datetime, 
	@status int,
	@transactioncode  nvarchar(250),
	@note nvarchar(3500),
	@transactionbitcoin nvarchar(250)
	
)
as begin 
	insert into transactionpackage(MemberID,PackageID,CoinID,CreateDate,ExpireDate,Status,TransactionCode,Note,TransactionBitcoin) values(@memberid,@packageid,@coinid,@createdate,@expiredate,@status,@transactioncode,@note,@transactionbitcoin)
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListAllCoin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE	proc [dbo].[SP_ListAllCoin]
 as begin
		select * from Coin where IsDelete=0
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListAllPackage]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[SP_ListAllPackage]
 (
	@start int,
	@end int
)

 as begin
		select *from (SELECT ROW_NUMBER() OVER (ORDER BY p.PackageID DESC) as Row,SUM(1) OVER()AS TOTALROWS,p.* from  Package p ) as Products
		  where Row>=@start and Row<=@end and IsDelete=0
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListAllPackage_Coin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_ListAllPackage_Coin]
 as begin 
		select pa.PackageName,c.CoinName,p.PackageValue,p.CreateDate from  Package_Coin p
								 left join Package pa on  p.PackageID = pa.PackageID
								left join Coin c on p.CoinID= c.CoinID
								 where p.IsDelete=0
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListAllPackageCoin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ListAllPackageCoin]
 (
	@start int,
	@end int
 )
 as begin
		select * from (
		SELECT ROW_NUMBER() OVER (ORDER BY p.PackageID DESC) as Row,SUM(1) OVER()AS TOTALROWS,
		p.PackageID,p.CoinID,pa.PackageName,c.CoinName,p.PackageValue,p.CreateDate
		from  Package_Coin p left join Package pa on  p.PackageID = pa.PackageID
								left join Coin c on p.CoinID= c.CoinID
								where p.IsDelete=0
		 ) as Products
		  where Row>=@start and Row<=@end 
 end
 --drop proc SP_ListAllPackage_Coin
 --create proc SP_ListAllPackage_Coin
 --as begin 
	--	select pa.PackageName,c.CoinName,p.PackageValue,p.CreateDate from  Package_Coin p
	--							 left join Package pa on  p.PackageID = pa.PackageID
	--							left join Coin c on p.CoinID= c.CoinID
	--							 where p.IsDelete=0
 --end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListAllPackageInformation]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[SP_ListAllPackageInformation]
 as begin
		select p.PackageID,p.PackageValue as Price,pa.PackageName,c.CoinID,c.CoinName, pa.PackageValue from Package_Coin p left join Package pa on  p.PackageID = pa.PackageID
								left join Coin c on p.CoinID= c.CoinID
		 where p.PackageID= pa.PackageID and p.CoinID= c.CoinID 
		 order by p.PackageID asc
		  
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListTransactionByMember]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[SP_ListTransactionByMember]
 (
	@memberID int
	)
 as begin
		select p.*, pk.PackageName from TransactionPackage p join Package pk on p.PackageID = pk.PackageID
		 where  p.MemberID = @memberID
		  
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListTransactionPackageByCode]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE proc [dbo].[SP_ListTransactionPackageByCode]
 (
	@memberID int,
	@transactioncode nvarchar(250)
	)
 as begin
		select p.*, pk.PackageName,pk.PackageValue,c.PackageValue as CoinValue, co.CoinName from TransactionPackage p ,Package pk, Package_Coin c, Coin co 																
		 where p.PackageID = pk.PackageID and p.CoinID = c.CoinID and p.PackageID = c.PackageID and  p.MemberID = @memberID and c.CoinID = co.CoinID and p.TransactionCode = @transactioncode
		  
 end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListTransactionWalletByMemberFE]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_ListTransactionWalletByMemberFE]
(
@memberID int,
@start int,
@end int
)
as begin
	select *from (SELECT ROW_NUMBER() OVER (ORDER BY tp.CreateDate DESC) as Row, SUM(1) OVER()AS TOTALROWS, tp.*,m.Email from TransactionCoin tp left join member m on tp.MemberID=m.MemberID 
	where tp.MemberID=@memberID) as Products  
	where Row>=@start and Row<=@end
end
GO
/****** Object:  StoredProcedure [dbo].[SP_ListTransactionWalletBySearchFrontEnd]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[SP_ListTransactionWalletBySearchFrontEnd]
(
	@start int,
	@end int,
	@memberID int,
	@fromDate datetime,
	@toDate datetime
	
)
as
begin
select *from (SELECT ROW_NUMBER() OVER (ORDER BY tp.CreateDate DESC) as Row,SUM(1) OVER()AS TOTALROWS, 
tp.*,m.Email 
from TransactionCoin tp left join member m on tp.MemberID=m.MemberID 
where (@memberID=0 or tp.MemberID=@memberID)

and (@fromDate='1/1/1990 12:00:00 AM' or tp.CreateDate between @fromDate and @toDate)
) as Products  where Row>=@start and Row<=@end
end;
GO
/****** Object:  StoredProcedure [dbo].[SP_LockAndUnlockPackage]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_LockAndUnlockPackage]
(
	@isActive smallint,
	@packageID int
)
as begin 

		update Package set IsActive=@isActive where PackageID=@packageID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_LoginAccount]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_LoginAccount]
(
	@email nvarchar(50),
	@pass nvarchar(250)
)
as begin
        select m.*,mw.IndexWallet,mw.NumberCoin, mw.WalletID from Member m, Member_Wallet mw
		 where m.MemberID = mw.MemberID and  Email = @email and Password = @pass and m.IsActive = 1 and m.IsDelete = 0;
end
GO
/****** Object:  StoredProcedure [dbo].[SP_TransactionWalletByID]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_TransactionWalletByID]
(
@transactionid char(150)
)
as begin
	select *from TransactionCoin where TransactionID = @transactionid
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateActiveByEmail]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_UpdateActiveByEmail]
(
	@email nvarchar(250),
	@isActive int
)
as begin 
	update member set IsActive=@isActive where Email=@email
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateMember]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_UpdateMember]
(
	@memberID int,
	@fullName nvarchar(250),
	@email nvarchar(250),
	@mobile char(50),
	@avatar nvarchar(250)
)
as begin
		update Member set FullName=@fullName,Email=@email,Mobile=@mobile,Avatar=@avatar where MemberID=@memberID
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePackage]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_UpdatePackage]
(
	@packageID int,
	@packageName nvarchar(250),
	@packageValue numeric(18, 10),
	@isActive smallint,
	--@isDelete smallint,
	--@createDate datetime
	--@createUser nvarchar(250),
	@updateDate Datetime,
	@updateUser nvarchar(250)
	--@deleteDate Datetime,
	--@deleteUser nvarchar(250)

)
as begin 
	update Package 
	 set PackageName=@packageName,PackageValue=@packageValue,IsActive=@isActive,UpdateDate=@updateDate,UpdateUser=@updateUser
	 where PackageID=@packageID
	
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePackageCoin]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[SP_UpdatePackageCoin]
(
	@packageID int,
	@coinID int,
	@packageValue numeric(18,10)
)
as begin 
	update Package_Coin 
	 set PackageValue=@packageValue
	 where  PackageID=@packageID and CoinID=@coinID

end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePasswordMember]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_UpdatePasswordMember]
(
	@password nvarchar(250),
	@email nvarchar(250)
)
as begin 
	update member set Password=@password where Email=@email
end
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdatePointsMember_FE]    Script Date: 12/04/17 9:54:00 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[SP_UpdatePointsMember_FE]
(
@memberID INT,
@points numeric(18, 10)
)
as begin 
	update Member_Wallet set NumberCoin=NumberCoin+@points where MemberID=@memberID
end
GO
