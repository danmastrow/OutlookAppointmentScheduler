# Outlook Appointment Scheduler 
[![Build Status](https://travis-ci.org/danmastrow/OutlookAppointmentScheduler.svg?branch=master)](https://travis-ci.org/danmastrow/OutlookAppointmentScheduler)
## Overview
- A Topshelf Service using Quartz Scheduler to automatically create and send Outlook bookings.
- This could be used for example to make Table Tennis bookings if perhaps they were only available from 7 days in advance.

## Installation
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
For further service installation/configuration help see the following link.
http://docs.topshelf-project.com/en/latest/overview/commandline.html

## Todo
### In no particular order:
- [x] Setup Topshelf and Quartz scheduler.
- [x] Add config file to read appointment information.
- [x] Create booking and send based upon config information.
- [ ] Attach a Windows Form project to the solution that reads/writes to the config file for easy configurability.
- [ ] Refactor the configuration reading to be on startup, rather than on Job execute (provide the option for both).
- [ ] Implement Serilog logging and metrics.
- [ ] Read appointment information from database/file not just config file.
      

## Gotcha's
~~A small quite annoying gotcha that I found with setting up Quartz and Topshelf is that the newer versions (3.0+) of Quartz has a lot of integration issues with the topshelf library used. So if you make a similiar Quartz and Topshelf project, use the v2.32 of Quartz.~~
- Alternatively I fixed this by upgrading to Quartz 2.6.2
