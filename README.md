# Message Processing Application

This is a Message Processing Application implemented as part of a JPMorgan Tech Test.
The application is able to create or receive messages from oher sources, process them, generate appropriate reports and log various information.

## Dependencies
- The solution and projects were created in VS Community 2015.
- The targeted .NET framework is 4.5.2
- For the unit tests the nuget packages of NUnit v3.10.1 and NUnit3TestAdapter v.3.10.0 were used.

## Run
The application will try and generate random test data at startup. If successful it will try to process the incoming data. In case we are running outside VS, we simply execute the MessageApplication.exe. 
I suggest executing with Run As administrator for I/O permissions.

## The problem
Implement a small message processing application that satisfies the below requirements for processing sales notification messages. 
You should assume that an external company will be sending you the input messages, but for the purposes of this exercise you are free to define the interfaces.
Processing requirements
- All sales must be recorded
- All messages must be processed
- After every 10th message received your application should log a report detailing the number of sales of each product and their total value.
- After 50 messages your application should log that it is pausing, stop accepting new messages and log a report of the adjustments that have been made to each sale type while the application was running.

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
- The messages have already entered our pending message queue. This means we assume there is an entity feeding messages. Whether the message data is valid will be evaluated from this application though.
- We are in a single threaded environment (no locks/thread safety used when managing data)
- All decimal values when displayed have been formatted to n2 to limit decimals to 2.

## The Approach
The application consists of an ApplicationEngine which is tasked with the fetching of pending message. 
This means that we assume that there is a layer/functionality feeding the messages as we process them. The application will exit if there are no messages pending. If we need to remain running and wait to listen to new messages we must extend the engine.

The message consists of a message type to understand the actions we need to undertake, a sale to hold the sale characteristics and a sale adjustment containing instructions on any needed adjustments. The adjustment may be empty. 
We assume that the appropriate types are exposed to the mechanism that produces the messages.

For each message received from our pending messages we will first examine their validity according to each message type.
If the validity checks pass, we will use an appropriate sale handler to manage the sale; perform any actions needed as per instructions and store it.

At the end of each processed message we will check if the completed messages are enough to trigger a report.

The application will log completed sales, completed messages, failed messages and sale adjustments.

** Note **
When examining the sales per product report we must keep in mind that this report occurs every 10 messages. The total sum we may see per product may seem odd initialy but we must always remember that a sale adjustment may have occurred. 
This will become evident when we will review the sale adjustment report.

## Enhancements
Added functionality to output all application messages to a file as well. The user will be prompted to open the file for review after the application has finished processing messages. 
The reason behind this is that by only reading the console window we may miss things. This enables us to review the file after the application finished execution. 
At each application startup, the file gets deleted and recreated.

For auditing reasons each Message and Sale has a unique identifier that will be given to it at creation. This would ideally be a PK if data were stored in a database. In the case of a multi sale, new unique identifiers will be provided by the sytem.

For auditing reasons also, the system logs completed messages and failed messages with extendibility for reporting.

A message generator is provided for initial data creation. A new layer for data preparation/fetching should be provided if we wish to accept messages externally (file, web service, database)

