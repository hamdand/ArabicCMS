
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1000', N'administrator')
INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1001', N'user')
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([Id], [NameEnglish], [NameArabic], [DescriptionEnglish], [DescriptionArabic], [SortId], [IsDeleted], [Created], [Modified], [UserId], [ImageUrl]) VALUES (1, N'Portal news', N'إطلاق المنصة', N'إطلاق المنصة', N'إطلاق المنصة', 0, 0, CAST(0x070000000000000000 AS DateTime2), CAST(0x077B993A431419410B AS DateTime2), N'907a6881-e7c6-4e73-b3ac-c4aa41039f62', N'NewsImages/f095f8fd-65fa-4c3d-a0d8-1c8aa74e5313.jpg')
SET IDENTITY_INSERT [dbo].[News] OFF
SET IDENTITY_INSERT [dbo].[PageContentType] ON 

INSERT [dbo].[PageContentType] ([Id], [Name], [IsDeleted], [Created], [Modified], [UserId]) VALUES (1, N'Text', 0, NULL, NULL, NULL)
INSERT [dbo].[PageContentType] ([Id], [Name], [IsDeleted], [Created], [Modified], [UserId]) VALUES (2, N'Files', 0, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[PageContentType] OFF
