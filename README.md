# Message Processing Application

This is a Message Processing Application implemented as part of a JPMorgan Tech Test.
The application is able to create or receive messages from oher sources, process them, generate appropriate reports and log various information.

## Dependencies
- The solution and projects were created in VS Community 2015.
- The targeted .NET framework is 4.5.2
- For the unit tests the nuget packages of NUnit v3.10.1 and NUnit3TestAdapter v.3.10.0 were used.

## Run
The application will try and generate random test data at startup. If successful it will try to process the incoming data. In case we are running outside VS, we simply execute the MessageApplication.exe.

## Assumptions
- There will be no UI or database.
- All data are stored in memory.
- The message layout API is up to the developer. The API used for the Message layout is as follows:
1. The incoming message has a unique identifier
2. The incoming message has a type.
3. The incoming message has a Sale.
4. The incoming message has a Sale Adjustment.
It is possible according to some scenarios to leave without value the Sale adjustment.

