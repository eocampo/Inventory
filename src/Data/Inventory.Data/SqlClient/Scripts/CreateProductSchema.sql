CREATE TABLE [inventory_product] (
	[product_id]	UNIQUEIDENTIFIER	NOT NULL DEFAULT (NEWID())
	,[display_name]	NVARCHAR(256)		NOT NULL
	,[code]			NVARCHAR(256)			NULL
	,[description]	NVARCHAR(2048)			NULL
	 ,CONSTRAINT [pk_inventory_product] PRIMARY KEY NONCLUSTERED (
		[product_id] ASC
	) ON [PRIMARY]
) ON [PRIMARY]
