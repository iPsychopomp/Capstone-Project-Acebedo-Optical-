# Supplier Items Status - Auto-Update Based on Inventory

## Feature Description
Ang status ng supplier items sa `supplierItems.vb` ay automatic na nag-uupdate based sa quantity ng product sa inventory (`inventory.vb`).

## Status Logic

### 1. **Inactive** (Red)
- Condition: Ang product ay naka-register sa inventory PERO ang quantity = 0
- Display: Red background, dark red text, bold font
- Meaning: Kailangan na mag-reorder dahil ubos na ang stock
- **Auto-update**: Kapag naging 0 ang quantity sa inventory, automatic na magiging "Inactive"

### 2. **Active** (Green)
- Condition: Ang product ay may stock sa inventory O wala pa sa inventory
- Display: Light green background, dark green text, bold font
- Meaning: May available stock pa O default status ng supplier item
- **Default**: Kung walang specific status sa database, "Active" ang default

## Technical Implementation

### Database Query
Ang query ay nag-join ng `tbl_supplier_products` at `tbl_products` gamit ang product name:

```sql
SELECT sp.sProductID, sp.product_name, sp.category, sp.description, sp.product_price,
CASE 
  WHEN p.productID IS NOT NULL AND p.stockQuantity = 0 THEN 'Inactive'
  ELSE COALESCE(sp.status, 'Active')
END AS status
FROM tbl_supplier_products sp
LEFT JOIN tbl_products p ON UPPER(TRIM(p.productName)) = UPPER(TRIM(sp.product_name))
ORDER BY sp.product_name
```

### Key Points
1. **Case-insensitive matching**: Ginagamit ang `UPPER(TRIM())` para sa product name matching
2. **LEFT JOIN**: Para makita pa rin ang supplier items kahit wala sa inventory
3. **Real-time status**: Ang status ay computed on-the-fly based sa current inventory quantity

## Visual Indicators

| Status | Background Color | Text Color | Font Style |
|--------|-----------------|------------|------------|
| Inactive | Light Coral | Dark Red | Bold |
| Active | Light Green | Dark Green | Bold |

## Usage

### Automatic Updates
Ang status ay automatic na nag-uupdate kapag:
1. Nag-load ng supplier items form
2. Nag-search ng product
3. Nag-refresh ng data

### Manual Refresh
Para i-refresh ang status:
1. I-close at i-open ulit ang supplier items form
2. Mag-search ulit
3. I-click ang refresh button (kung meron)

## Benefits

1. **Real-time visibility**: Makikita agad kung ano ang status ng item sa inventory
2. **Better ordering decisions**: Alam mo kung kailangan na mag-order based sa stock level
3. **Visual feedback**: Color-coded para madaling makita ang critical items
4. **Automatic sync**: Hindi na kailangan manual na i-update ang status

## Example Scenarios

### Scenario 1: New Supplier Item
- Product: "Blue Light Blocking Lens"
- Status: "Active" (Green - default)
- Action: Pwede i-add sa inventory kung gusto

### Scenario 2: Out of Stock Item
- Product: "Plastic Frame"
- Inventory Quantity: 0
- Status: "Inactive" (Red - auto-updated)
- Action: Kailangan mag-order na

### Scenario 3: Available Item
- Product: "Photochromic Lens"
- Inventory Quantity: 50
- Status: "Active" (Green - from database or default)
- Action: May stock pa, no need to order yet

## Notes
- Ang matching ay based sa product name (case-insensitive)
- Kung may typo sa product name, hindi mag-match sa inventory
- Ang status ay read-only, hindi pwedeng i-edit manually
- Ang actual quantity ay hindi displayed sa supplier items, status lang
