# Solusyon sa Foreign Key Constraint Error

## Problema
Lumabas ang error na ito kapag nag-add ka ng supplier items at nag-attempt mag-order:

```
Error placing order: ERROR [HY000] [MySQL][ODBC 3.51 Driver][mysqld-5.5.5-10.4.32-MariaDB]
Cannot add or update a child row: a foreign key constraint fails
(acebedo.tbl_productorder_items, CONSTRAINT tbl_productorder_items_ibfk_2 
FOREIGN KEY (productID) REFERENCES tbl_products (productID))
```

## Sanhi ng Problema
1. Ang `tbl_productorder_items` table ay may foreign key constraint na nag-require na ang `productID` ay dapat existing sa `tbl_products` table
2. Pero ang mga supplier items (galing sa `tbl_supplier_products`) ay hindi lahat naka-register sa `tbl_products`
3. Kaya kapag nag-order ka ng item na wala sa main inventory, nag-fail ang insert dahil sa foreign key constraint

## Solusyon

### Step 1: I-run ang SQL Script
Buksan ang MySQL/MariaDB client at i-run ang `fix_foreign_key.sql`:

```bash
mysql -u root -p acebedo < fix_foreign_key.sql
```

O kaya i-copy-paste ang mga command sa MySQL Workbench o phpMyAdmin:

```sql
USE acebedo;

-- Drop the foreign key constraint
ALTER TABLE tbl_productorder_items DROP FOREIGN KEY tbl_productorder_items_ibfk_2;

-- Make productID nullable
ALTER TABLE tbl_productorder_items MODIFY COLUMN productID INT NULL;
```

### Step 2: I-restart ang Application
Pagkatapos i-run ang SQL script, i-restart ang application para ma-trigger ang updated code.

## Ano ang Ginawa sa Code

### 1. Inayos ang `btnAdd_Click` method
**Dati:**
- Kumuha ng `sProductID` from `tbl_supplier_products`
- Nag-validate na dapat may productID (hindi 0)

**Ngayon:**
- Kumuha ng price at category from `tbl_supplier_products`
- Sinubukan hanapin ang productID sa `tbl_products` (main inventory)
- Kung wala, i-set as 0 (NULL sa database)

### 2. Improved ang `EnsureOrderItemsProductIDNullable` method
- Nag-check kung nullable na ba ang productID column
- Nag-drop ng foreign key constraint
- Ginawang nullable ang productID column
- May error logging na para sa debugging

### 3. Tama na ang `btnPlaceOrder_Click` method
- Nag-insert ng DBNull.Value kung productID = 0
- Nag-save ng productName para ma-identify ang item

## Paano Gumana ang Bagong System

1. **Supplier-only items** (wala sa main inventory):
   - productID = NULL
   - productName = saved (e.g., "Aluminum Frame")
   - Pwede na mag-order kahit wala sa inventory

2. **Items na naka-register sa inventory**:
   - productID = actual ID from tbl_products
   - productName = saved
   - Pwede pa rin mag-order normally

## Testing
Subukan ulit ang dating scenario:
1. Mag-add ng supplier items
2. Mag-attempt mag-order
3. Dapat successful na ang order placement

## Notes
- Ang foreign key constraint ay permanently removed na
- Ang productID ay nullable na, so pwede nang mag-order ng supplier-only items
- Ang productName ay laging naka-save para ma-identify ang item
- Walang effect sa existing orders
