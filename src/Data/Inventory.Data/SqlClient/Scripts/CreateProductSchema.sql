CREATE TABLE [inventory_product] (
	[product_id]	UNIQUEIDENTIFIER	NOT NULL DEFAULT (NEWID())
	,[display_name]	NVARCHAR(256)		NOT NULL
	,[product_code]	NVARCHAR(256)			NULL
	,[description]	NVARCHAR(2048)			NULL
	,[comments]		NVARCHAR(2048)			NULL

	 ,CONSTRAINT [pk_sacpi_supplier_contract_item] PRIMARY KEY NONCLUSTERED (
		[contract_item_id] ASC
	) ON [PRIMARY]
) ON [PRIMARY]
