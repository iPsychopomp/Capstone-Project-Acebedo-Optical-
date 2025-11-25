# Implementation Plan

- [ ] 1. Add logging infrastructure to diagnose the issue
  - Add Debug.WriteLine statements in searchPatient.searchPatientDGV_CellDoubleClick to log each step of the form search process
  - Add logging in addPatientTransaction.SetPatientInfo to track when it's called and with what parameters
  - Add logging in addPatientTransaction.btnPSearch_Click to track dialog creation
  - _Requirements: 3.1, 3.2, 3.3, 3.4, 3.5_

- [ ] 2. Implement direct reference mechanism in searchPatient
  - [ ] 2.1 Add CallingTransactionForm property to searchPatient class
    - Add public property: `Public Property CallingTransactionForm As addPatientTransaction = Nothing`
    - _Requirements: 2.4, 4.2_
  
  - [ ] 2.2 Modify searchPatientDGV_CellDoubleClick to prioritize direct reference
    - Check `CallingTransactionForm` property FIRST before other search methods
    - Add disposal state validation before calling SetPatientInfo
    - Add logging for each search path attempted
    - _Requirements: 2.1, 2.2, 4.1, 4.4_

- [ ] 3. Fix addPatientTransaction.btnPSearch_Click to establish proper reference
  - Remove the `Using` block that causes immediate disposal
  - Create searchPatient instance and store in local variable
  - Set `CallingTransactionForm` property to `Me`
  - Call `ShowDialog(Me)` to establish Owner relationship
  - Add proper cleanup after dialog closes
  - _Requirements: 1.1, 1.2, 1.3, 2.4_

- [ ] 4. Add form instance tracking to addPatientTransaction
  - Add private field `currentSearchDialog As searchPatient = Nothing`
  - Update btnPSearch_Click to store reference in this field
  - Clear reference when dialog closes
  - _Requirements: 2.4, 4.2_

- [ ] 5. Enhance error handling in patient selection flow
  - Add try-catch blocks around SetPatientInfo calls
  - Show user-friendly error messages when form is disposed
  - Show error message when no valid form instance is found
  - Log all exceptions with full stack traces
  - _Requirements: 2.2, 4.5_

- [ ] 6. Checkpoint - Test basic patient selection flow
  - Ensure all tests pass, ask the user if questions arise
  - Manually test: Open transaction → select patient → verify it works
  - Check Debug output for logging messages

- [ ]* 7. Write property test for form reference persistence
  - **Property 1: Form Reference Persistence**
  - **Validates: Requirements 2.4**
  - Create test that opens searchPatient dialog multiple times
  - Verify CallingTransactionForm is always set and not disposed
  - Run test with 100 iterations
  - _Requirements: 2.4_

- [ ]* 8. Write property test for patient selection idempotence
  - **Property 2: Patient Selection Idempotence**
  - **Validates: Requirements 1.4, 1.5**
  - Generate random patient data
  - Perform 1-10 cycles of form open/close
  - Verify patient selection succeeds every time
  - Run test with 100 iterations
  - _Requirements: 1.4, 1.5_

- [ ]* 9. Write property test for form instance uniqueness
  - **Property 3: Form Instance Uniqueness**
  - **Validates: Requirements 2.1, 4.4**
  - Create scenarios with 0-3 form instances in container
  - Verify search finds exactly one active instance when expected
  - Run test with 100 iterations
  - _Requirements: 2.1, 4.4_

- [ ]* 10. Write property test for disposal state validation
  - **Property 4: Disposal State Validation**
  - **Validates: Requirements 2.2, 4.5**
  - Create mix of disposed and active form references
  - Verify SetPatientInfo only called on non-disposed forms
  - Verify no exceptions thrown
  - Run test with 100 iterations
  - _Requirements: 2.2, 4.5_

- [ ]* 11. Write integration tests for end-to-end flow
  - Test: Create transaction → select patient → close → repeat 5 times
  - Test: Create transaction → close without selection → create again → select
  - Test: Multiple rapid open/close cycles followed by selection
  - Verify patient name populates correctly in all scenarios
  - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5_

- [ ] 12. Add comprehensive documentation comments
  - Document CallingTransactionForm property purpose
  - Document the search priority order in searchPatientDGV_CellDoubleClick
  - Add XML comments for public methods
  - _Requirements: 4.1_

- [ ] 13. Final checkpoint - Comprehensive testing
  - Ensure all tests pass, ask the user if questions arise
  - Perform manual testing of the complete workflow
  - Verify logging output is helpful for debugging
  - Test with multiple rapid open/close cycles
  - Verify no memory leaks or disposed object exceptions
