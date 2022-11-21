USE [Reimbursement];
GO

set identity_insert [Products] on
insert into [Products] ([ProductID],[API_ID],[ProductName],[Brand],[Inventory],[Price], [Description],[Image],[ColourName],[HexValue]) values (,309,'Maybelline Expert Wear Eye Shadow Quad ','maybelline',20,8.99, 'Easy to use, lots to choose!Maybelline Expert Wear Eye Shadow \nQuads have 4 coordinating shades with step by step application guide \nmakes shadow easier than ever. The eyeshadows glide on effortlessly with\n superior smoothness and the velvet-tip applicator blends without \ntugging or pulling. Safe for sensitive eyes and contact lens wearers, \nophthalmologist-tested.For best results sweep the brush 4 times:Apply base color. Sweep shade on lid. Contour crease and blend. Line around eye.','https://d3t32hsnjxo7q6.cloudfront.net/i/c924006882e8e313d445a3a5394e4729_ra,w158,h184_pa,w158,h184.png','Audacious Asphalt','#515552');
set identity_insert [Products] off