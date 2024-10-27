MultiThreaded Geph.io Brute Forcer
Overview

This project is a multi-threaded brute-forcing tool developed for Geph.io. Using asynchronous requests and concurrent threads, it efficiently checks a list of user credentials to determine account validity and subscription type (free or premium). The UI is implemented with a simple form that provides live feedback on the brute-forcing process, displaying the count of valid, free, and invalid accounts.

Features

    Multi-threading Support: Efficiently handles multiple accounts at once by dividing the workload across several threads.
    Regex Pattern Matching: Extracts authentication tokens and subscription types with Regex-based parsing.
    Asynchronous Requests: Utilizes HttpClient with asynchronous requests to send login data and retrieve account details.
    Real-time UI Feedback: Updates the UI with information on valid, free, and invalid accounts.

Project Structure

    Backend (Core Logic): The backend class contains the main brute-forcing logic.
        Main method splits the combo list and spawns multiple threads.
        check method processes each thread's combo lines, sends login requests to Geph.io, and updates the UI.
    UI Integration: The form (Form1) provides a simple way to monitor and control the process with UI updates and options to pause threads.

Dependencies

    Gephwin (if required, specify link to installation or use).
    .NET Framework compatible with HttpClient.
    JSON parsing libraries if needed (e.g., Newtonsoft.Json).

Usage

    Clone the Repository:

    bash

    git clone https://github.com/yourusername/repo-name.git
    cd repo-name

    Prepare Combo List: Create a combo list of usernames and passwords in the format username:password, separated by new lines.

    Run the Application:
        Launch the app from your IDE or run it directly.
        Add your combo list and set the number of threads (bot parameter).
        Click "Start" to begin the brute-forcing process.

    UI Display: The UI displays:
        Total Accounts Checked.
        Valid Accounts: Accounts that logged in successfully.
        Free Accounts: Accounts that have free subscriptions.
        Invalid Accounts: Accounts with invalid credentials.

    Pause Threads: You can pause the threads using the pause feature, which temporarily suspends the brute-forcing process without closing the app.

Code Explanation

    Dependency Injection: The Form1 object is injected into the backend class to enable seamless updates to the UI.
    Concurrency: The Main method splits the combo list among the specified number of threads, allowing concurrent execution.
    Regex Matching: A Regex pattern matches the response to retrieve authentication tokens, allowing the system to validate subscription types (free or premium).

Disclaimer

This project is intended for educational and testing purposes only. Unauthorized use against real systems is prohibited and may be illegal.
