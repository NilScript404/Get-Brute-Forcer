# MultiThreaded Geph.io Brute Forcer

## Overview

This project is a multi-threaded brute-forcing tool developed for Geph.io. Using asynchronous requests and concurrent threads, it efficiently checks a list of user credentials to determine account validity and subscription type (free or premium). The UI is implemented with a simple form that provides live feedback on the brute-forcing process, displaying the count of valid, free, and invalid accounts.

## Features

- **Multi-threading Support:** Efficiently handles multiple accounts at once by dividing the workload across several threads.
- **Regex Pattern Matching:** Extracts authentication tokens and subscription types with Regex-based parsing.
- **Asynchronous Requests:** Utilizes HttpClient with asynchronous requests to send login data and retrieve account details.
- **Real-time UI Feedback:** Updates the UI with information on valid, free, and invalid accounts.

## Project Structure

- **Backend (Core Logic):** The backend class contains the main brute-forcing logic.
  - Main method splits the combo list and spawns multiple threads.
  - `check` method processes each thread's combo lines, sends login requests to Geph.io, and updates the UI.
  
- **UI Integration:** The form (Form1) provides a simple way to monitor and control the process with UI updates and options to pause threads.

## Dependencies

- Gephwin (if required, specify link to installation or use).
- .NET Framework compatible with HttpClient.
- JSON parsing libraries if needed (e.g., Newtonsoft.Json).

## Usage

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/yourusername/repo-name.git
   cd repo-name
