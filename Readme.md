﻿# Outlook Appointment Scheduler 
![alt text](https://github.com/danmastrow/OutlookAppointmentScheduler/raw/master/OutlookAppointmentSchedulerGUI/img/bookingIcon.png "Logo")
[![Build Status](https://travis-ci.org/danmastrow/OutlookAppointmentScheduler.svg?branch=master)](https://travis-ci.org/danmastrow/OutlookAppointmentScheduler)
## Overview
![alt text](https://github.com/danmastrow/OutlookAppointmentScheduler/raw/master/OutlookAppointmentSchedulerGUI/img/example.png "Example")

This could be used for example to make Table Tennis bookings if perhaps they were only available from 7 days in advance.
Or to book Outlook rooms that are highly contested, or just an easier way to manage automatic bookings in an office type system.
The email account used will the the current user logged in.

## Getting Started NOW!
1. To get started immediately simply download the latest release and run the OutlookAppointmentSchedulerGUI.exe
   https://github.com/danmastrow/OutlookAppointmentScheduler/releases

## Building and the application
1. Build the solution.
2. Run the GUI project.
3. Select Install or Launch Service.
4. The service should now be running and the status of the service should now be displayed if installed.
5. Press the + button on the MainForm to create a new booking.
6. Fill out all the Booking Details and press Create to save the Booking as a JSON file.
<p>The contents of the created Booking JSON file created will look like this</p>

````
{"Name":"Example Booking","Enabled":true,"Type":0,"Times":["15:00:00","15:30:00","14:30:00"],"Location":"#AU MELY Room Table Tennis","DurationInMinutes":30,"NumberOfDaysInFuture":7,"Body":"Making a booking","Subject":"TT","Recipients":["Daniel M"],"DayBlackList":[],"FileRead":false,"FileName":"./bookings\\Example-Booking2018-Jul-24-09-55-21.json"}
````
7. To modify existing bookings, double click the booking on the MainForm.
8. Once the bookings are created and the Service is installed, they will automatically be booked at the specific time.

## Todo
- [ ] Implement Serilog logging and metrics in the service.
- [ ] Create installer for the release.
- [x] Setup Topshelf and Quartz scheduler.
- [x] Add config file to read appointment information.
- [x] Create booking and send based upon config information.
- [x] Attach a Windows Form project to the solution that manages the service and monitors the service status.
- [x] Write Appointment Bookings to JSON files and read from that in the Service.
- [x] Create GitHub release.
- [x] Resize the MainForm GUI to the size of the ListView on load.

## Backlog
- [ ] Read and write appointment information from database.
- [ ] Read logs of service from GUI and display them.
- [ ] Add Windows Form Functionality (Settings Page) that reads/writes to the config file for easy configurability.
- [ ] Replace service polling with event on service status.
- [ ] Move application to .NET Core

## Gotcha's
- Currently to Install the service you must be an Administrator on your Machine, or at least run the GUI as as Admin.
- When building the Service, make sure that it is not already running on your system, otherwise you may not be able to build.
  - This is only the case if you are installing the service from your build output folder.
- ~~A small quite annoying gotcha that I found with setting up Quartz and Topshelf is that the newer versions (3.0+) of Quartz has a lot of integration issues with the topshelf library used. So if you make a similiar Quartz and Topshelf project, use the v2.32 of Quartz.~~
  - Alternatively I fixed this by upgrading to Quartz 2.6.2

## Further Reading
For manual service installation/configuration for Topshelf help see the following link.
http://docs.topshelf-project.com/en/latest/overview/commandline.html

A Topshelf Service with a Windows Form GUI using Quartz Scheduler to automatically create and send Outlook bookings at specific times.
The service runs every 24 hours (configurable) at a specified time and reads all created bookings and sends them as Outlook Appointments.
