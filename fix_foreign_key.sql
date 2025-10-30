-- Fix for foreign key constraint error in tbl_productorder_items
-- This script will drop the foreign key constraint and make productID nullable

USE acebedo;

-- Drop the foreign key constraint that requires productID to exist in tbl_products
ALTER TABLE tbl_productorder_items DROP FOREIGN KEY tbl_productorder_items_ibfk_2;

-- Make productID column nullable so supplier-only items can have NULL productID
ALTER TABLE tbl_productorder_items MODIFY COLUMN productID INT NULL;

-- Verify the changes
SELECT 
    COLUMN_NAME,
    IS_NULLABLE,
    DATA_TYPE,
    COLUMN_KEY
FROM INFORMATION_SCHEMA.COLUMNS 
WHERE TABLE_SCHEMA = 'acebedo' 
  AND TABLE_NAME = 'tbl_productorder_items' 
  AND COLUMN_NAME = 'productID';

-- Show remaining constraints
SELECT 
    CONSTRAINT_NAME,
    TABLE_NAME,
    COLUMN_NAME,
    REFERENCED_TABLE_NAME,
    REFERENCED_COLUMN_NAME
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE
WHERE TABLE_SCHEMA = 'acebedo'
  AND TABLE_NAME = 'tbl_productorder_items';
