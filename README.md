# How to create a .NET8 WebAPI for sending messages to Azure ServiceBus (Advance sample)

The provided applications demonstrate some **advanced** features and capabilities of Azure Service Bus

Here's an overview of these features:

**Sessions**: Azure Service Bus supports session-based messaging, which enables you to group related messages and process them in a specific order

In the provided applications, you can send messages with an optional session ID

When a session ID is specified, the message is associated with that session, and the receiver can process messages from the same session in order

**Scheduled messages**: Azure Service Bus allows you to schedule messages for future delivery

In the provided applications, you can send messages with an optional scheduled enqueue time in UTC format

When a scheduled enqueue time is specified, the message will not be available for processing until the specified time

This feature can be useful for implementing delayed processing or time-based workflows

**Message processing options**: The receiver application uses the ServiceBusProcessor class to process messages from the queue

The **ServiceBusProcessorOptions** class provides several configuration options to control how messages are processed, such as:

-**AutoCompleteMessages**: Automatically completes messages after they are processed, indicating that they should be removed from the queue

-**MaxConcurrentCalls**: Specifies the maximum number of concurrent message processing tasks. This can be useful for controlling the processing throughput and resource usage

-**PrefetchCount**: Specifies the number of messages that should be prefetched and cached locally for faster processing

-**ReceiveMode**: Specifies the receive mode for messages, either PeekLock (the default) or ReceiveAndDelete

The **PeekLock mode** allows for at-least-once message processing, while the **ReceiveAndDelete mode** provides simpler, but less reliable, message processing

**Error handling**: The receiver application includes an error handling mechanism to handle any exceptions or errors that occur during message processing

The **ErrorHandler** method is called when an error occurs, allowing you to log the error details, implement retry policies, or perform other error handling actions

**Swagger integration**: Both applications include Swagger (OpenAPI) integration for easy API documentation and testing

Swagger provides an interactive interface to explore and test the API endpoints, making it easier to understand and work with the applications

These advanced features and capabilities enable you to build more robust and flexible messaging solutions using Azure Service Bus

You can further customize and extend these applications to meet your specific requirements, such as implementing **custom message processing logic**,

adding **authentication and authorization**, or **integrating with other Azure services**
