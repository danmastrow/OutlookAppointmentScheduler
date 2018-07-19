# Outlook Appointment Scheduler 
![alt text](https://github.com/danmastrow/OutlookAppointmentScheduler/raw/master/OutlookAppointmentSchedulerGUI/img/bookingIcon.png "Logo")
[![Build Status](https://travis-ci.org/danmastrow/OutlookAppointmentScheduler.svg?branch=master)](https://travis-ci.org/danmastrow/OutlookAppointmentScheduler)
## Overview
A Topshelf Service with a Windows Form GUI using Quartz Scheduler to automatically create and send Outlook bookings at specific times.
The service reads from JSON files, that are generated from the GUI.
This could be used for example to make Table Tennis bookings if perhaps they were only available from 7 days in advance.

## Installation
**GUI Install**
1. Build the solution.
2. Run the GUI project.
3. Select Install or Launch Service.
4. The service should now be running and the status of the service should now be displayed if installed.

**Manual Install of Service:**
- Install the service with the following steps:
- Compile the project.
- Open up a console or terminal window.
- Change directory to the location of the .exe file.
````
cd OutlookAppointmentScheduler/bin
````

- Install the service using the following command
````
OutlookAppointmentScheduler.exe install --autostart
````
For further manual service installation/configuration help see the following link.
http://docs.topshelf-project.com/en/latest/overview/commandline.html

## Todo
- [x] Setup Topshelf and Quartz scheduler.
- [x] Add config file to read appointment information.
- [x] Create booking and send based upon config information.
- [x] Attach a Windows Form project to the solution that manages the service and monitors the service status.
- [x] Write Appointment Bookings to JSON files and read from that in the Service.
- [ ] 🔴Implement Serilog logging and metrics in the service.
- [ ] Resize the MainForm GUI to the size of the ListView on load.
- [ ] Provide feedback on common error messages (Admin Issues, FileNotFound, ServiceNotFound)
- [ ] Add Windows Form Functionality (Settings Page) that reads/writes to the config file for easy configurability.
- [ ] Read logs of service from GUI and display them.
- [ ] Read and write appointment information from database.

## Gotcha's
- Currently to Install the service you must be an Administrator on your Machine, or at least run the GUI as as Admin.
- When building the Service, make sure that it is not already running on your system, otherwise you may not be able to build.
  - This is only the case if you are installing the service from your build output folder.
- ~~A small quite annoying gotcha that I found with setting up Quartz and Topshelf is that the newer versions (3.0+) of Quartz has a lot of integration issues with the topshelf library used. So if you make a similiar Quartz and Topshelf project, use the v2.32 of Quartz.~~
- Alternatively I fixed this by upgrading to Quartz 2.6.2
