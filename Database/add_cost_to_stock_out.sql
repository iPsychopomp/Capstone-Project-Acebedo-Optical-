-- Add cost columns to tbl_stock_out table
ALTER TABLE `tbl_stock_out` 
ADD COLUMN `costPerItem` DECIMAL(10,2) DEFAULT 0.00 AFTER `quantityIssued`,
ADD COLUMN `totalCost` DECIMAL(10,2) DEFAULT 0.00 AFTER `costPerItem`;
