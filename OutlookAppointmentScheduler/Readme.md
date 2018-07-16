# OutlookAppointment Scheduler

## Overview
- A Topshelf Service using Quartz Scheduler to automatically create and send Outlook bookings.

## Todo
### In no particular order:
- [x] Setup Topshelf and Quartz scheduler.
- [x] Add config file to read appointment information.
- [ ] Attach a Windows Form project to the solution that reads/writes to the config file for easy configurability.
- [ ] Create booking and send based upon config information.
- [ ] Implement Serilog logging and metrics.
- [ ] Read appointment information from database/file.
      

## Gotcha's
- A small quite annoying gotcha that I found with setting up Quartz and Topshelf is that the newer versions (3.0+) of Quartz has a lot of integration issues with the topshelf library used. So if you make a similiar Quartz and Topshelf project, use the v2.32 of Quartz.
