# Requirements Document

## Introduction

This specification addresses a bug in the patient selection workflow within the transaction management system. When a user creates a new transaction and selects a patient, the patient name should populate in the text box. This works correctly on the first attempt, but after reloading the transaction form and attempting to select a patient again, the patient name fails to populate.

## Glossary

- **Transaction Form**: The `addPatientTransaction.vb` form used to create or edit patient transactions
- **Search Patient Dialog**: The `searchPatient.vb` form that displays a searchable list of patients
- **MainForm Container**: The `pnlContainer` control in `MainForm.vb` that hosts embedded forms
- **Patient Selection**: The process of double-clicking a patient row in the search dialog to populate patient information in the transaction form
- **Form Lifecycle**: The sequence of events from form creation, display, interaction, to disposal

## Requirements

### Requirement 1

**User Story:** As a receptionist, I want to select a patient for a new transaction after reloading the transaction list, so that I can consistently create transactions without restarting the application.

#### Acceptance Criteria

1. WHEN a user clicks the "New" button in the Transaction form THEN the system SHALL display the addPatientTransaction form in the MainForm container
2. WHEN a user clicks the patient search button in addPatientTransaction THEN the system SHALL display the searchPatient dialog
3. WHEN a user double-clicks a patient row in searchPatient THEN the system SHALL populate the patient name in the addPatientTransaction form's text box
4. WHEN a user closes the addPatientTransaction form and clicks "New" again THEN the system SHALL maintain the same patient selection behavior as the first attempt
5. WHEN the Transaction form is reloaded THEN subsequent patient selections SHALL populate the text box correctly

### Requirement 2

**User Story:** As a developer, I want the patient selection mechanism to maintain proper form references across multiple transaction creation attempts, so that the system behaves consistently.

#### Acceptance Criteria

1. WHEN searchPatient searches for the target addPatientTransaction form THEN the system SHALL check all possible locations (Owner, OpenForms, MainForm container)
2. WHEN searchPatient finds the addPatientTransaction form THEN the system SHALL verify the form is not disposed before calling SetPatientInfo
3. WHEN SetPatientInfo is called THEN the system SHALL update both txtPname and txtPatientName text boxes
4. WHEN the addPatientTransaction form is shown in the MainForm container THEN the system SHALL ensure proper parent-child relationships are established
5. WHEN the addPatientTransaction form is closed THEN the system SHALL properly clean up references to prevent stale form instances

### Requirement 3

**User Story:** As a system administrator, I want detailed logging of the patient selection process, so that I can diagnose issues when patient information fails to populate.

#### Acceptance Criteria

1. WHEN searchPatient attempts to find the addPatientTransaction form THEN the system SHALL log each search location checked
2. WHEN SetPatientInfo is called THEN the system SHALL log the patient ID and name being set
3. WHEN SetPatientInfo encounters an error THEN the system SHALL log the error message and stack trace
4. WHEN the form search fails to find addPatientTransaction THEN the system SHALL log which locations were checked
5. WHEN a form is disposed or unavailable THEN the system SHALL log this state before attempting operations

### Requirement 4

**User Story:** As a receptionist, I want the patient search dialog to always communicate with the correct transaction form instance, so that my selected patient appears in the right place.

#### Acceptance Criteria

1. WHEN searchPatient is opened from addPatientTransaction THEN the system SHALL establish a direct reference to the calling form
2. WHEN multiple addPatientTransaction forms could exist THEN the system SHALL prioritize the most recently active instance
3. WHEN searchPatient closes after patient selection THEN the system SHALL ensure the calling form receives focus
4. WHEN the addPatientTransaction form is embedded in MainForm container THEN the system SHALL correctly locate it among container controls
5. WHEN searchPatient cannot find a valid target form THEN the system SHALL display an error message to the user
