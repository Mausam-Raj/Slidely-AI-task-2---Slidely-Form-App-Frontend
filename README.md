# Slidely Form App (Frontend)

## Overview
The `Slidely Form App` is `Visual Basic` application designed to manage user submissions by interacting with a backend service. This application allows users to view and create submissions, ensuring a seamless user experience with real-time updates and functionalities such as a stopwatch.

## Features
- **Backend Connection**: Stores user form data in backend server.
- **View Submissions**: Browse through user submissions with navigation controls.
- **Create Submissions**: Submit new entries with form validation and stopwatch functionality.
- **Keyboard Shortcuts**: Enhanced user interaction with keyboard shortcuts for various actions.

## Getting Started

### Prerequisites
- `Visual Studio`
- `.Net Framework`

### Installation
- Clone the repository: 
    ``` sh
        https://github.com/Mausam-Raj/Slidely-AI-task-2-Slidely-Form-App-Frontend.git
    ```
- Open the project in Visual Studio.
- Build and Run the project.

## How To Use
1. **View Submissions**:
    - Press `Ctrl + V` to open the view submissions form.
    - Navigate through submissions using the Previous and Next buttons or use `Ctrl + P` and `Ctrl + N` for keyboard navigation.

2. **Create Submission**:
    - Press `Ctrl + N` to open the create submission form.
    - Fill in the required fields.
    - Use `Ctrl + T` to toggle the stopwatch.
    - Press `Ctrl + S` to submit the form.

## Code Structure
- **Form1**: 
    Main form that initializes the application and handles backend connectivity checks.
- **ViewSubmissionsForm**: 
    Form to view and navigate through submissions.
- **CreateSubmissionForm**: 
    Form to create new submissions with stopwatch functionality.
- **Submission**: 
    Class representing a submission entity.
- **BackendService**: 
    Class handling HTTP requests to the backend service.

## Dependencies
- Newtonsoft.Json
- System.Net.Http
