# Search Patient - Callback Pattern (Industry Standard)

## Overview
Implemented a **callback/delegate pattern** for patient selection to achieve loose coupling between forms. This is an industry-standard approach that makes the code more maintainable, testable, and reusable.

## Benefits of Callback Pattern

### 1. Loose Coupling
- `searchPatient` form doesn't need to know about specific parent forms
- No direct dependencies on `CreateCheckUp` or `addPatientTransaction`
- Easy to add new forms that need patient selection

### 2. Testability
- Can easily mock the callback for unit testing
- No need to create actual form instances for testing

### 3. Reusability
- Same `searchPatient` form works with any parent form
- Just provide a callback function

### 4. Maintainability
- Changes to parent forms don't affect `searchPatient`
- Clear contract via delegate signature

## Implementation

### Step 1: Define Delegate (in searchPatient.vb)

```vb
' Delegate for patient selection callback
Public Delegate Sub PatientSelectedCallback(patientID As Integer, fullname As String)

Public Class searchPatient
    ' Callback property
    Public Property OnPatientSelected As PatientSelectedCallback = Nothing
```

### Step 2: Invoke Callback (in searchPatient.vb)

```vb
Private Sub searchPatientDGV_CellDoubleClick(...)
    ' Get patient data
    Dim pid As Integer = ...
    Dim fullname As String = ...
    
    ' Use callback if provided (PRIORITY)
    If OnPatientSelected IsNot Nothing Then
        OnPatientSelected.Invoke(pid, fullname)
        Me.Close()
        Return
    End If
    
    ' Fallback to legacy form-finding approach
    ' ...
End Sub
```

### Step 3: Set Callback in Parent Form

#### Example: CreateCheckUp.vb
```vb
Private Sub btnSPatient_Click(...)
    Using searchForm As New searchPatient()
        ' Set callback using lambda/anonymous sub
        searchForm.OnPatientSelected = Sub(patientID As Integer, fullname As String)
                                           txtPName.Text = fullname
                                           txtPName.Tag = patientID
                                           UpdateSummary()
                                       End Sub
        
        searchForm.ShowDialog()
    End Using
End Sub
```

#### Example: addPatientTransaction.vb
```vb
Private Sub btnPSearch_Click(...)
    Using frm As New searchPatient()
        ' Set callback
        frm.OnPatientSelected = Sub(patientID As Integer, fullname As String)
                                    SetPatientInfo(patientID, fullname)
                                End Sub
        
        frm.ShowDialog(Me)
    End Using
End Sub
```

## Execution Flow

1. Parent form opens `searchPatient` and sets `OnPatientSelected` callback
2. User double-clicks a patient in the DataGridView
3. `searchPatient` invokes the callback with patient data
4. Parent form receives the data and updates its UI
5. `searchPatient` closes

## Fallback Support

The implementation includes fallback to the legacy form-finding approach for backward compatibility:
- If `OnPatientSelected` is set → use callback (modern approach)
- If not set → search for parent forms (legacy approach)

This ensures existing code continues to work while new code can use the better pattern.

## Why This is Industry Standard

1. **Separation of Concerns** - Each form has a single responsibility
2. **Dependency Inversion** - High-level modules don't depend on low-level details
3. **Open/Closed Principle** - Open for extension, closed for modification
4. **Single Source of Truth** - Callback defines the contract clearly

## Alternative Patterns (for future consideration)

### Event Pattern
```vb
Public Event PatientSelected(patientID As Integer, fullname As String)

' In double-click handler:
RaiseEvent PatientSelected(pid, fullname)
```

### Interface Pattern
```vb
Public Interface IPatientReceiver
    Sub ReceivePatient(patientID As Integer, fullname As String)
End Interface

Public Property ParentReceiver As IPatientReceiver
```

Both are also industry-standard approaches, but callbacks are simpler for this use case.
