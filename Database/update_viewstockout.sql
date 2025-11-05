-- Update db_viewstockout view to include cost columns
DROP VIEW IF EXISTS `db_viewstockout`;

CREATE VIEW `db_viewstockout` AS 
SELECT 
    `tbl_stock_out`.`stockOutID` AS `stockOutID`,
    `tbl_products`.`productName` AS `productName`,
    `tbl_stock_out`.`quantityIssued` AS `quantityIssued`,
    `tbl_stock_out`.`costPerItem` AS `costPerItem`,
    `tbl_stock_out`.`totalCost` AS `totalCost`,
    `tbl_stock_out`.`Reason` AS `Reason`,
    `tbl_stock_out`.`IssuedBy` AS `IssuedBy`,
    `tbl_stock_out`.`DateIssued` AS `DateIssued`
FROM `tbl_stock_out` 
JOIN `tbl_products` ON `tbl_stock_out`.`productID` = `tbl_products`.`productID`;
