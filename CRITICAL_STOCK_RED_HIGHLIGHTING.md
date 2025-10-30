# Critical Stock Red Highlighting Feature

## Overview
Kapag nag-click sa **pnlCritical** panel sa dashboard, automatic na pupunta sa inventory at mag-highlight ng **RED** ang lahat ng low stock at out of stock items.

## Visual Indicators

### Red Highlighted Rows
Ang mga items na naka-highlight ng red ay:
1. **Out of Stock ONLY** - stockQuantity = 0 (ubos na)

**Note:** Low stock items (quantity <= reorderLevel) ay **HINDI** naka-red, normal colors lang.

### Color Scheme
- **Background**: Light Coral (light red)
- **Text Color**: Dark Red
- **Selection Background**: Indian Red
- **Selection Text**: White
- **Font**: Bold (emphasized)

## How It Works

### 1. Dashboard Click Event
```vb
Private Sub pnlCritical_Click(sender As Object, e As EventArgs)
    ' Navigate to inventory
    mainForm.btnInventory.PerformClick()
    
    ' Show low stock items with red highlighting
    inv.ShowLowStockItems()
End Sub
```

### 2. Inventory Display Logic
```vb
Public Sub ShowLowStockItems()
    ' Load products sorted by:
    ' 1. Low stock items first (isLowStock = 1)
    ' 2. Then by quantity (0 first, then ascending)
    ' 3. Then by product name
    
    ORDER BY isLowStock DESC, p.stockQuantity ASC, p.productName ASC
End Sub
```

### 3. Red Highlighting Logic
```vb
Private Sub ProductDGV_RowPrePaint(...)
    ' Highlight ONLY if stockQuantity = 0 (out of stock)
    
    If stockQuantity = 0 Then
        row.DefaultCellStyle.BackColor = Color.LightCoral
        row.DefaultCellStyle.ForeColor = Color.DarkRed
    End If
End Sub
```

## Sorting Priority

Ang items ay naka-sort sa order na ito:
1. **Critical items first** (isLowStock = 1)
   - Out of stock (quantity = 0) - **MOST CRITICAL**
   - Low stock (quantity <= reorderLevel)
2. **Normal stock items** (isLowStock = 0)
3. Within each group, sorted by:
   - Quantity (ascending - lowest first)
   - Product name (alphabetical)

## Example Display

```
┌─────────────────────────────────────────────────────────┐
│ Product Name      │ Quantity │ Reorder Level │ Status   │
├─────────────────────────────────────────────────────────┤
│ 🔴 Plastic Frame  │    0     │      10       │ OUT      │ <- RED (0 qty)
│ 🔴 Eye Solution   │    0     │      10       │ OUT      │ <- RED (0 qty)
├─────────────────────────────────────────────────────────┤
│ Reading Glasses   │    5     │      10       │ LOW      │ <- Normal (low but not 0)
│ Photochromic Lens │   50     │      10       │ OK       │ <- Normal
│ Metal Frame       │  100     │      20       │ OK       │ <- Normal
└─────────────────────────────────────────────────────────┘
```

## User Experience Flow

1. **User sees critical count** on dashboard (e.g., "5 Critical Items")
2. **User clicks pnlCritical panel**
3. **System navigates** to Inventory module
4. **System displays** all products with:
   - Critical items at the top
   - Red highlighting for easy identification
   - Sorted by urgency (0 quantity first)
5. **User can immediately see** which items need reordering

## Benefits

### 1. Visual Priority
- Red color immediately draws attention to critical items
- No need to scan through entire list
- Clear distinction between critical and normal stock

### 2. Efficient Workflow
- One click from dashboard to critical items
- Items already sorted by urgency
- Focus on most critical items first (quantity = 0)

### 3. Better Inventory Management
- Quick identification of out-of-stock items
- Proactive reordering before stock runs out
- Reduced risk of stockouts

## Technical Details

### SQL Query Enhancement
```sql
-- Include both out of stock AND low stock items
CASE WHEN p.stockQuantity = 0 OR p.stockQuantity <= p.reorderLevel 
     THEN 1 
     ELSE 0 
END AS isLowStock

-- Sort to show most critical first
ORDER BY isLowStock DESC, p.stockQuantity ASC, p.productName ASC
```

### Event Handlers
- `ProductDGV_RowPrePaint` - Applies red highlighting to rows
- `OnProductGridUpdated` - Refreshes highlighting when data changes
- `ShowLowStockItems` - Loads and displays critical items

### Refresh Mechanism
```vb
' Force refresh to trigger RowPrePaint events
productDGV.Refresh()
```

## Notes

- Ang red highlighting ay **automatic** - walang manual intervention needed
- Ang highlighting ay **persistent** - kahit mag-scroll o mag-sort
- Ang highlighting ay **dynamic** - nag-update based sa current stock levels
- Ang 0 quantity items ay **always highlighted** kahit walang reorder level

## Testing Scenarios

### Scenario 1: Out of Stock Item
- Product: "Plastic Frame"
- Quantity: 0
- Reorder Level: 10
- **Result**: RED highlighted, appears first in list

### Scenario 2: Low Stock Item (Not Zero)
- Product: "Eye Solution"
- Quantity: 5
- Reorder Level: 10
- **Result**: NORMAL colors (not red), appears in low stock section

### Scenario 3: Normal Stock Item
- Product: "Photochromic Lens"
- Quantity: 50
- Reorder Level: 10
- **Result**: Normal colors, appears after critical items
