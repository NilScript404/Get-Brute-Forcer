# MultiThreaded Geph.io Brute Forcer

## Overview

This project is a multi-threaded brute-forcing tool developed for Geph.io. Using asynchronous requests and concurrent threads, it efficiently checks a list of user credentials to determine account validity and subscription type (free or premium). The UI is implemented with a simple form that provides live feedback on the brute-forcing process, displaying the count of valid, free, and invalid accounts.

## Features

- **Multi-threading Support:** Efficiently handles multiple accounts at once by dividing the workload across several threads.
- **Regex Pattern Matching:** Extracts authentication tokens and subscription types with Regex-based parsing.
- **Asynchronous Requests:** Utilizes HttpClient with asynchronous requests to send login data and retrieve account details.
- **Real-time UI Feedback:** Updates the UI with information on valid, free, and invalid accounts.
## User Interface


<p align="center">

  <img src="https://github.com/NilScript404/Get-Brute-Forcer/blob/main/UI.PNG" alt="Application UI">

</p>

## Project Structure

- **Backend (Core Logic):** The backend class contains the main brute-forcing logic.
  - Main method splits the combo list and spawns multiple threads.
  - `check` method processes each thread's combo lines, sends login requests to Geph.io, and updates the UI.
  
- **UI Integration:** The form (Form1) provides a simple way to monitor and control the process with UI updates and options to pause threads.

## Dependencies

- .NET 8.
- .WINFORM 


## Usage

1. **Clone the Repository:**

   ```bash
   git clone https://github.com/NilScript404/Geph-Brute-Forcer.git
   cd Geph-Brute-Forcer
## ⚠️ Disclaimer


This software is provided for educational and research purposes only. The author does not endorse or encourage any malicious use of this tool. Users are responsible for ensuring their use of this software complies with all applicable laws, terms of service, and ethical guidelines.


- This tool should only be used on systems and accounts you own or have explicit permission to test.

- Unauthorized access to computer systems and accounts is illegal and unethical.

- The author assumes no liability for any misuse or damage caused by this software.

- Use at your own risk.
