IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[inventory_product_view]'))
DROP VIEW [inventory_product_view]

IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[inventory_product]') AND type in (N'U'))
DROP TABLE [inventory_product]