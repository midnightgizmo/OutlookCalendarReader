This is an Outlook plugin.

What does it do?
It backs up (in json format) some calendar information for the last month to a folder called CalendarEvents in the users windows my documents folder.

More details
I created this over the span of a few hours one night to help solve a problem I have been having with my calendar events disappearing.

Every time outlook starts up the plugin will look for all calendar events from the past 30 days. It will then save those events in a json file.

PLEASE NOTE:
A new json file is created every time outlook is started up. This was done by design for my specific needs. Over time a lot of files will be created which you may need to delete.


What Data does it back up?
Currently it backs up the following data.
Start date/time
End date/time
Description
Location
Body text.

