# Message Processing Application

This is a Message Processing Application implemented as part of a JPMorgan Tech Test.
The application is able to create or receive messages from oher sources, process them, generate appropriate reports and log various information.

## Dependencies
- The solution and projects were created in VS Community 2015.
- The targeted .NET framework is 4.5.2
- For the unit tests the nuget packages of NUnit v3.10.1 and NUnit3TestAdapter v.3.10.0 were used.

## Run
The application will try and generate random test data at startup. If successful it will try to process the incoming data. In case we are running outside VS, we simply execute the MessageApplication.exe. I suggest executing with Run As administrator for I/O permissions.

## Assumptions
- There will be no UI or database.
- All data are stored in memory.
- The message layout API is up to the developer. The API used for the Message layout is as follows:
  - The incoming message has a unique identifier
  - The incoming message has a type.
  - The incoming message has a Sale.
  - The incoming message has a Sale Adjustment.
  - The Message is a class and not an Interface because it is supposed to be supplied by another consistent system that has the class exposed.
It is possible according to some scenarios to leave without value the Sale adjustment.


## Enhancements
Added functionality to output all application messages to a file as well. The user will be prompted to open the file for review after the application has finished processing messages. The reason behind this is that by only reading the console window we may miss things. This enables us to review the file after we are done.

For auditing reasons each Message and Sale has a unique identifier that will be given to it at creation. This would ideally be a PK if data were stored in a database. In the case of a multi sale, new unique identifiers will be provided by the sytem.

For auditing reasons also, the system logs completed messages and failed messages with extendibility for reporting.

A message generator is provided for initial data creation. A new layer for data preparation/fetching should be provided if we wish to accept messages externally (file, web service, database)

