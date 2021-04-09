USE [HospitalDB]
GO
SET IDENTITY_INSERT [dbo].[tb_doctor] ON 

INSERT [dbo].[tb_doctor] ([NIDDOCTOR], [SFIRSTNAME], [SSECONDNAME], [SLASTNAME], [SLASTNAME1], [DBIRTHDATE], [SGENDER], [SSPECIALITY], [NPHONE], [SEMAIL], [SWEBSITE], [SABOUT], [SPATHIMAGE], [SACTIVE], [DREGISTER], [NUSERREGISTER], [DUPDATE], [NUSERUPDATE]) VALUES (18, N'Junior', N'Luis', N'Espinoza', N'Espinoza', CAST(N'1992-01-02' AS Date), N'M', N'Medicina General', N'994357401', N'jespinoza2292@gmail.com', N'jespinoza22.com', N'Doctor con mas de 20 años de experiencia en medicina general', N'26152021101509.jpg', N'A', CAST(N'2021-01-16' AS Date), 1, CAST(N'2021-01-26' AS Date), 1)
SET IDENTITY_INSERT [dbo].[tb_doctor] OFF
GO
SET IDENTITY_INSERT [dbo].[tb_user] ON 

INSERT [dbo].[tb_user] ([NIDUSER], [SUSER], [SPASSWORD], [NIDDOCTOR], [SACTIVE], [DREGISTER], [NUSERREGISTER], [DUPDATE], [NUSERUPDATE]) VALUES (5, N'jespinoza', N'e10adc3949ba59abbe56e057f20f883e', 18, N'A', CAST(N'2021-01-16' AS Date), 1, NULL, NULL)
SET IDENTITY_INSERT [dbo].[tb_user] OFF
GO
